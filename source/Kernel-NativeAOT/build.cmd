@set DROPPATH=%USERPROFILE%\.nuget\packages\runtime.win-x64.microsoft.dotnet.ilcompiler\6.0.0-preview.7.21327.1
@set ILCPATH=%DROPPATH%\tools
@if not exist %ILCPATH%\ilc.exe (
  echo ilc.exe not found.
  exit /B
)
@where csc >nul 2>&1
@if ERRORLEVEL 1 (
  echo CSC not on the PATH.
  exit /B
)

@del *.ilexe >nul 2>&1
@del *.obj >nul 2>&1
@del *.map >nul 2>&1
@del *.pdb >nul 2>&1
@del *.EFI >nul 2>&1
@del *.log >nul 2>&1
@del *.o >nul 2>&1
@rmdir /s /q bin
@rmdir /s /q obj

@if "%1" == "clean" exit /B

nasm -f elf64 asm/multiboot2.asm -o multiboot2.o
nasm -f elf64 asm/boot.asm -o boot.o
nasm -f elf64 asm/dotnet.asm -o dotnet.o
nasm -f elf64 asm/modules.asm -o modules.o

dotnet restore
dotnet build

%ILCPATH%\ilc bin/x64/Debug/net5.0/Kernel.dll -o Kernel.o --systemmodule Kernel --map Kernel.map


@if not "%1" == "start" exit /B

xcopy BOOTX64.EFI build\EFI\BOOT\BOOTX64.EFI* /Y

@if not exist os_drive (
  mkdir os_drive
)

 tools\\qemu\\qemu-system-x86_64 -s -d cpu_reset -D ./qemu.log -L ".\\tools\\qemu\\" -bios bios64.bin -k en-gb -m 512M -drive file=fat:rw:".\\build\\",format=raw,media=disk -drive file=fat:rw:".\\os_drive\\",format=raw,media=disk -serial file:serial.log