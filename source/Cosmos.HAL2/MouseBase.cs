﻿namespace Cosmos.HAL;

/// <summary>
///     The base class for mouse implementations.
/// </summary>
public abstract class MouseBase : Device
{
    public delegate void MouseChangedEventHandler(int aDeltaX, int aDeltaY, int aMouseState, int aScrollWheel);

    public MouseChangedEventHandler OnMouseChanged;
    public abstract void Initialize();
}
