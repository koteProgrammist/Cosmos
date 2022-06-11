using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using Console = Cosmos.System.Console;
using Global = Cosmos.System.Global;
using PCSpeaker = Cosmos.System.PCSpeaker;

namespace Cosmos.System_Plugs.System;

[Plug(Target = typeof(global::System.Console))]
public static class ConsoleImpl
{
    private static ConsoleColor mForeground = ConsoleColor.White;
    private static ConsoleColor mBackground = ConsoleColor.Black;
    private static Encoding ConsoleInputEncoding = Encoding.ASCII;
    private static Encoding ConsoleOutputEncoding = Encoding.ASCII;

    private static readonly Console mFallbackConsole = new(null);

    private static Console GetConsole() => mFallbackConsole;

    public static ConsoleColor get_BackgroundColor() => mBackground;

    public static void set_BackgroundColor(ConsoleColor value)
    {
        mBackground = value;
        //Cosmos.HAL.Global.TextScreen.SetColors(mForeground, mBackground);
        if (GetConsole() != null)
        {
            GetConsole().Background = value;
        }
    }

    public static int get_BufferHeight() => throw new NotImplementedException("Not implemented: get_BufferHeight");

    public static void set_BufferHeight(int aHeight) =>
        throw new NotImplementedException("Not implemented: set_BufferHeight");

    public static int get_BufferWidth() => throw new NotImplementedException("Not implemented: get_BufferWidth");

    public static void set_BufferWidth(int aWidth) =>
        throw new NotImplementedException("Not implemented: set_BufferWidth");

    public static bool get_CapsLock() => Global.CapsLock;

    public static int get_CursorLeft()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return 0;
        }

        return GetConsole().X;
    }

    public static void set_CursorLeft(int x)
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return;
        }

        if (x < 0)
        {
            throw new ArgumentException("The value x must be at least 0!");
        }

        if (x < get_WindowWidth())
        {
            xConsole.X = x;
        }
        else
        {
            throw new ArgumentException("The value x must be lower than the console width!");
        }
    }

    public static int get_CursorSize()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return 0;
        }

        return xConsole.CursorSize;
    }

    public static void set_CursorSize(int aSize)
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return;
        }

        xConsole.CursorSize = aSize;
    }

    public static int get_CursorTop()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return 0;
        }

        return GetConsole().Y;
    }

    public static void set_CursorTop(int y)
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return;
        }

        if (y < 0)
        {
            throw new ArgumentException("The value y must be at least 0!");
        }

        if (y < get_WindowHeight())
        {
            xConsole.Y = y;
        }
        else
        {
            throw new ArgumentException("The value y must be lower than the console height!");
        }
    }

    public static bool get_CursorVisible()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            return false;
        }

        return GetConsole().CursorVisible;
    }

    public static void set_CursorVisible(bool value)
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return;
        }

        xConsole.CursorVisible = value;
    }


    //public static TextWriter get_Error() {
    //    WriteLine("Not implemented: get_Error");
    //    return null;
    //}

    public static ConsoleColor get_ForegroundColor() => mForeground;

    public static void set_ForegroundColor(ConsoleColor value)
    {
        mForeground = value;
        //Cosmos.HAL.Global.TextScreen.SetColors(mForeground, mBackground);
        if (GetConsole() != null)
        {
            GetConsole().Foreground = value;
        }
    }

    //public static TextReader get_In()
    //{
    //    WriteLine("Not implemented: get_In");
    //    return null;
    //}

    public static Encoding get_InputEncoding() => ConsoleInputEncoding;

    public static void set_InputEncoding(Encoding value) => ConsoleInputEncoding = value;

    public static Encoding get_OutputEncoding() => ConsoleOutputEncoding;


    public static void set_OutputEncoding(Encoding value) => ConsoleOutputEncoding = value;

    public static bool get_KeyAvailable() => KeyboardManager.KeyAvailable;

    public static int get_LargestWindowHeight() =>
        throw new NotImplementedException("Not implemented: get_LargestWindowHeight");

    public static int get_LargestWindowWidth() =>
        throw new NotImplementedException("Not implemented: get_LargestWindowWidth");

    public static bool get_NumberLock() => Global.NumLock;

    //public static TextWriter get_Out() {
    //    WriteLine("Not implemented: get_Out");
    //    return null;
    //}

    public static string get_Title() => throw new NotImplementedException("Not implemented: get_Title");

    public static void set_Title(string value) => throw new NotImplementedException("Not implemented: set_Title");

    public static bool get_TreatControlCAsInput() =>
        throw new NotImplementedException("Not implemented: get_TreatControlCAsInput");

    public static void set_TreatControlCAsInput(bool value) =>
        throw new NotImplementedException("Not implemented: set_TreatControlCAsInput");

    public static int get_WindowHeight()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return 25;
        }

        return GetConsole().Rows;
    }

    public static void set_WindowHeight(int value) =>
        throw new NotImplementedException("Not implemented: set_WindowHeight");

    public static int get_WindowLeft() => throw new NotImplementedException("Not implemented: get_WindowLeft");

    public static void set_WindowLeft(int value) =>
        throw new NotImplementedException("Not implemented: set_WindowLeft");

    public static int get_WindowTop() => throw new NotImplementedException("Not implemented: get_WindowTop");

    public static void set_WindowTop(int value) => throw new NotImplementedException("Not implemented: set_WindowTop");

    public static int get_WindowWidth()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return 85;
        }

        return GetConsole().Cols;
    }

    public static void set_WindowWidth(int value) =>
        throw new NotImplementedException("Not implemented: set_WindowWidth");

    /// <summary>
    ///     The ArgumentOutOfRangeException check is now done at driver level in PCSpeaker - is it still needed here?
    /// </summary>
    /// <param name="aFrequency"></param>
    /// <param name="aDuration"></param>
    public static void Beep(int aFrequency, int aDuration)
    {
        if (aFrequency < 37 || aFrequency > 32767)
        {
            throw new ArgumentOutOfRangeException("Frequency must be between 37 and 32767Hz");
        }

        if (aDuration <= 0)
        {
            throw new ArgumentOutOfRangeException("Duration must be more than 0");
        }

        PCSpeaker.Beep((uint)aFrequency, (uint)aDuration);
    }

    /// <summary>
    ///     Beep() is pure CIL
    ///     Default implementation beeps for 200 milliseconds at 800 hertz
    ///     In Cosmos, these are Cosmos.System.Duration.Default and Cosmos.System.Notes.Default respectively,
    ///     and are used when there are no params
    ///     https://docs.microsoft.com/en-us/dotnet/api/system.console.beep?view=netcore-2.0
    /// </summary>
    public static void Beep() => PCSpeaker.Beep();

    //TODO: Console uses TextWriter - intercept and plug it instead
    public static void Clear()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return;
        }

        GetConsole().Clear();
    }

    //  MoveBufferArea(int, int, int, int, int, int) is pure CIL

    public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
        int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor) =>
        throw new NotImplementedException("Not implemented: MoveBufferArea");

    //public static Stream OpenStandardError() {
    //    WriteLine("Not implemented: OpenStandardError");
    //}

    //public static Stream OpenStandardError(int bufferSize) {
    //    WriteLine("Not implemented: OpenStandardError");
    //}

    //public static Stream OpenStandardInput(int bufferSize) {
    //    WriteLine("Not implemented: OpenStandardInput");
    //}

    //public static Stream OpenStandardInput() {
    //    WriteLine("Not implemented: OpenStandardInput");
    //}

    //public static Stream OpenStandardOutput(int bufferSize) {
    //    WriteLine("Not implemented: OpenStandardOutput");
    //}

    //public static Stream OpenStandardOutput() {
    //    WriteLine("Not implemented: OpenStandardOutput");
    //}

    public static int Read()
    {
        // TODO special cases, if needed, that returns -1
        KeyEvent xResult;

        if (KeyboardManager.TryReadKey(out xResult))
        {
            return xResult.KeyChar;
        }

        return -1;
    }

    public static ConsoleKeyInfo ReadKey() => ReadKey(false);

    // ReadKey() pure CIL

    public static ConsoleKeyInfo ReadKey(bool intercept)
    {
        var key = KeyboardManager.ReadKey();
        if (intercept == false && key.KeyChar != '\0')
        {
            Write(key.KeyChar);
        }

        //TODO: Plug HasFlag and use the next 3 lines instead of the 3 following lines

        //bool xShift = key.Modifiers.HasFlag(ConsoleModifiers.Shift);
        //bool xAlt = key.Modifiers.HasFlag(ConsoleModifiers.Alt);
        //bool xControl = key.Modifiers.HasFlag(ConsoleModifiers.Control);

        var xShift = (key.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift;
        var xAlt = (key.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt;
        var xControl = (key.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control;

        return new ConsoleKeyInfo(key.KeyChar, key.Key.ToConsoleKey(), xShift, xAlt, xControl);
    }

    public static string ReadLine()
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return null;
        }

        var chars = new List<char>(32);
        KeyEvent current;
        var currentCount = 0;

        while ((current = KeyboardManager.ReadKey()).Key != ConsoleKeyEx.Enter)
        {
            if (current.Key == ConsoleKeyEx.NumEnter)
            {
                break;
            }

            //Check for "special" keys
            if (current.Key == ConsoleKeyEx.Backspace) // Backspace
            {
                if (currentCount > 0)
                {
                    var curCharTemp = GetConsole().X;
                    chars.RemoveAt(currentCount - 1);
                    GetConsole().X = GetConsole().X - 1;

                    //Move characters to the left
                    for (var x = currentCount - 1; x < chars.Count; x++)
                    {
                        Write(chars[x]);
                    }

                    Write(' ');

                    GetConsole().X = curCharTemp - 1;

                    currentCount--;
                }

                continue;
            }

            if (current.Key == ConsoleKeyEx.LeftArrow)
            {
                if (currentCount > 0)
                {
                    GetConsole().X = GetConsole().X - 1;
                    currentCount--;
                }

                continue;
            }

            if (current.Key == ConsoleKeyEx.RightArrow)
            {
                if (currentCount < chars.Count)
                {
                    GetConsole().X = GetConsole().X + 1;
                    currentCount++;
                }

                continue;
            }

            if (current.KeyChar == '\0')
            {
                continue;
            }

            //Write the character to the screen
            if (currentCount == chars.Count)
            {
                chars.Add(current.KeyChar);
                Write(current.KeyChar);
                currentCount++;
            }
            else
            {
                //Insert the new character in the correct location
                //For some reason, List.Insert() doesn't work properly
                //so the character has to be inserted manually
                var temp = new List<char>();

                for (var x = 0; x < chars.Count; x++)
                {
                    if (x == currentCount)
                    {
                        temp.Add(current.KeyChar);
                    }

                    temp.Add(chars[x]);
                }

                chars = temp;

                //Shift the characters to the right
                for (var x = currentCount; x < chars.Count; x++)
                {
                    Write(chars[x]);
                }

                GetConsole().X -= chars.Count - currentCount - 1;
                currentCount++;
            }
        }

        WriteLine();

        var final = chars.ToArray();
        return new string(final);
    }

    public static void ResetColor()
    {
        set_BackgroundColor(ConsoleColor.Black);
        set_ForegroundColor(ConsoleColor.White);
    }

    public static void SetBufferSize(int width, int height) =>
        throw new NotImplementedException("Not implemented: SetBufferSize");

    public static void SetCursorPosition(int left, int top)
    {
        set_CursorLeft(left);
        set_CursorTop(top);
    }

    public static (int Left, int Top) GetCursorPosition()
    {
        var Left = get_CursorLeft();
        var Top = get_CursorTop();

        return (Left, Top);
    }

    //public static void SetError(TextWriter newError) {
    //    WriteLine("Not implemented: SetError");
    //}

    //public static void SetIn(TextReader newIn) {
    //    WriteLine("Not implemented: SetIn");
    //}

    //public static void SetOut(TextWriter newOut) {
    //    WriteLine("Not implemented: SetOut");
    //}

    public static void SetWindowPosition(int left, int top) =>
        throw new NotImplementedException("Not implemented: SetWindowPosition");

    public static void SetWindowSize(int width, int height)
    {
        if (width == 40 && height == 25)
        {
            mFallbackConsole.mText.Cols = 40;
            mFallbackConsole.mText.Rows = 25;
            VGAScreen.SetTextMode(VGADriver.TextSize.Size40x25);
        }
        else if (width == 40 && height == 50)
        {
            mFallbackConsole.mText.Cols = 40;
            mFallbackConsole.mText.Rows = 50;
            VGAScreen.SetTextMode(VGADriver.TextSize.Size40x50);
        }
        else if (width == 80 && height == 25)
        {
            mFallbackConsole.mText.Cols = 80;
            mFallbackConsole.mText.Rows = 25;
            VGAScreen.SetTextMode(VGADriver.TextSize.Size80x25);
        }
        else if (width == 80 && height == 50)
        {
            mFallbackConsole.mText.Cols = 80;
            mFallbackConsole.mText.Rows = 50;
            VGAScreen.SetTextMode(VGADriver.TextSize.Size80x50);
        }
        else if (width == 90 && height == 30)
        {
            mFallbackConsole.mText.Cols = 90;
            mFallbackConsole.mText.Rows = 30;
            VGAScreen.SetTextMode(VGADriver.TextSize.Size90x30);
        }
        else if (width == 90 && height == 60)
        {
            mFallbackConsole.mText.Cols = 90;
            mFallbackConsole.mText.Rows = 60;
            VGAScreen.SetTextMode(VGADriver.TextSize.Size90x60);
        }
        else
        {
            throw new Exception("Invalid text size.");
        }

        mFallbackConsole.Cols = mFallbackConsole.mText.Cols;
        mFallbackConsole.Rows = mFallbackConsole.mText.Rows;

        ((TextScreen)mFallbackConsole.mText).UpdateWindowSize();

        Clear();
    }

    #region Write

    public static void Write(bool aBool) => Write(aBool.ToString());

    /*
     * A .Net character can be effectevily more can one byte so calling the low level Console.Write() will be wrong as
     * it accepts only bytes, we need to convert it using the specified OutputEncoding but to do this we have to convert
     * it ToString first
     */
    public static void Write(char aChar) => Write(aChar.ToString());

    public static void Write(char[] aBuffer) => Write(aBuffer, 0, aBuffer.Length);

    /* Decimal type is not working yet... */
    //public static void Write(decimal aDecimal) => Write(aDecimal.ToString());

    public static void Write(double aDouble) => Write(aDouble.ToString());

    public static void Write(float aFloat) => Write(aFloat.ToString());

    public static void Write(int aInt) => Write(aInt.ToString());

    public static void Write(long aLong) => Write(aLong.ToString());

    /* Correct behaviour printing null should not throw NRE or do nothing but should print an empty string */
    public static void Write(object value) => Write(value ?? String.Empty);

    public static void Write(string aText)
    {
        var xConsole = GetConsole();
        if (xConsole == null)
        {
            // for now:
            return;
        }

        var aTextEncoded = ConsoleOutputEncoding.GetBytes(aText);
        GetConsole().Write(aTextEncoded);
    }

    public static void Write(uint aInt) => Write(aInt.ToString());

    public static void Write(ulong aLong) => Write(aLong.ToString());

    public static void Write(string format, object arg0) => Write(String.Format(format, arg0));

    public static void Write(string format, object arg0, object arg1) => Write(String.Format(format, arg0, arg1));

    public static void Write(string format, object arg0, object arg1, object arg2) =>
        Write(String.Format(format, arg0, arg1, arg2));

    public static void Write(string format, params object[] arg) => Write(String.Format(format, arg));

    public static void Write(char[] aBuffer, int aIndex, int aCount)
    {
        if (aBuffer == null)
        {
            throw new ArgumentNullException("aBuffer");
        }

        if (aIndex < 0)
        {
            throw new ArgumentOutOfRangeException("aIndex");
        }

        if (aCount < 0)
        {
            throw new ArgumentOutOfRangeException("aCount");
        }

        if (aBuffer.Length - aIndex < aCount)
        {
            throw new ArgumentException();
        }

        for (var i = 0; i < aCount; i++)
        {
            Write(aBuffer[aIndex + i]);
        }
    }

    //You'd expect this to be on System.Console wouldn't you? Well, it ain't so we just rely on Write(object value)
    //public static void Write(byte aByte) {
    //    Write(aByte.ToString());
    //}

    #endregion

    #region WriteLine

    public static void WriteLine() => Write(Environment.NewLine);

    public static void WriteLine(bool aBool) => WriteLine(aBool.ToString());

    public static void WriteLine(char aChar) => WriteLine(aChar.ToString());

    public static void WriteLine(char[] aBuffer) => WriteLine(new string(aBuffer));

    /* Decimal type is not working yet... */
    //public static void WriteLine(decimal aDecimal) => WriteLine(aDecimal.ToString());

    public static void WriteLine(double aDouble) => WriteLine(aDouble.ToString());

    public static void WriteLine(float aFloat) => WriteLine(aFloat.ToString());

    public static void WriteLine(int aInt) => WriteLine(aInt.ToString());

    public static void WriteLine(long aLong) => WriteLine(aLong.ToString());

    /* Correct behaviour printing null should not throw NRE or do nothing but should print an empty line */
    public static void WriteLine(object value) => Write((value ?? String.Empty) + Environment.NewLine);

    public static void WriteLine(string aText) => Write(aText + Environment.NewLine);

    public static void WriteLine(uint aInt) => WriteLine(aInt.ToString());

    public static void WriteLine(ulong aLong) => WriteLine(aLong.ToString());

    public static void WriteLine(string format, object arg0) => WriteLine(String.Format(format, arg0));

    public static void WriteLine(string format, object arg0, object arg1) =>
        WriteLine(String.Format(format, arg0, arg1));

    public static void WriteLine(string format, object arg0, object arg1, object arg2) =>
        WriteLine(String.Format(format, arg0, arg1, arg2));

    public static void WriteLine(string format, params object[] arg) => WriteLine(String.Format(format, arg));

    public static void WriteLine(char[] aBuffer, int aIndex, int aCount)
    {
        Write(aBuffer, aIndex, aCount);
        WriteLine();
    }

    #endregion
}
