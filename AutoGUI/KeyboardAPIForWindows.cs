using AutoGUI.API;
using System.Runtime.InteropServices;

namespace AutoGUI;

internal class KeyboardAPIForWindows:KeyboardAPI
{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    // 键盘事件常量
    private const uint KEYEVENTF_KEYDOWN = 0x0000;
    private const uint KEYEVENTF_KEYUP = 0x0002;


    public override void KeyUp(KeyCode keyCode)
    {
        keybd_event((byte)_keyCodeMapping[keyCode], 0, KEYEVENTF_KEYUP, 0);
    }
    public override void KeyDown(KeyCode keyCode)
    {
        keybd_event((byte)_keyCodeMapping[keyCode], 0, KEYEVENTF_KEYDOWN, 0);
    }

    private readonly Dictionary<KeyCode, int> _keyCodeMapping = new Dictionary<KeyCode, int>
        {
            // 字母键
            { KeyCode.A, 0x41 },
            { KeyCode.B, 0x42 },
            { KeyCode.C, 0x43 },
            { KeyCode.D, 0x44 },
            { KeyCode.E, 0x45 },
            { KeyCode.F, 0x46 },
            { KeyCode.G, 0x47 },
            { KeyCode.H, 0x48 },
            { KeyCode.I, 0x49 },
            { KeyCode.J, 0x4A },
            { KeyCode.K, 0x4B },
            { KeyCode.L, 0x4C },
            { KeyCode.M, 0x4D },
            { KeyCode.N, 0x4E },
            { KeyCode.O, 0x4F },
            { KeyCode.P, 0x50 },
            { KeyCode.Q, 0x51 },
            { KeyCode.R, 0x52 },
            { KeyCode.S, 0x53 },
            { KeyCode.T, 0x54 },
            { KeyCode.U, 0x55 },
            { KeyCode.V, 0x56 },
            { KeyCode.W, 0x57 },
            { KeyCode.X, 0x58 },
            { KeyCode.Y, 0x59 },
            { KeyCode.Z, 0x5A },
            // 数字键
            { KeyCode.D0, 0x30 },
            { KeyCode.D1, 0x31 },
            { KeyCode.D2, 0x32 },
            { KeyCode.D3, 0x33 },
            { KeyCode.D4, 0x34 },
            { KeyCode.D5, 0x35 },
            { KeyCode.D6, 0x36 },
            { KeyCode.D7, 0x37 },
            { KeyCode.D8, 0x38 },
            { KeyCode.D9, 0x39 },
            // 功能键
            { KeyCode.F1, 0x70 },
            { KeyCode.F2, 0x71 },
            { KeyCode.F3, 0x72 },
            { KeyCode.F4, 0x73 },
            { KeyCode.F5, 0x74 },
            { KeyCode.F6, 0x75 },
            { KeyCode.F7, 0x76 },
            { KeyCode.F8, 0x77 },
            { KeyCode.F9, 0x78 },
            { KeyCode.F10, 0x79 },
            { KeyCode.F11, 0x7A },
            { KeyCode.F12, 0x7B },
            // 控制键
            { KeyCode.Escape, 0x1B },
            { KeyCode.Tab, 0x09 },
            { KeyCode.CapsLock, 0x14 },
            { KeyCode.Shift, 0x10 },
            { KeyCode.Control, 0x11 },
            { KeyCode.Alt, 0x12 },
            { KeyCode.Space, 0x20 },
            { KeyCode.Enter, 0x0D },
            { KeyCode.Backspace, 0x08 },
            { KeyCode.Delete, 0x2E },
            { KeyCode.Insert, 0x2D },
            { KeyCode.Home, 0x24 },
            { KeyCode.End, 0x23 },
            { KeyCode.PageUp, 0x21 },
            { KeyCode.PageDown, 0x22 },
            // 方向键
            { KeyCode.UpArrow, 0x26 },
            { KeyCode.DownArrow, 0x28 },
            { KeyCode.LeftArrow, 0x25 },
            { KeyCode.RightArrow, 0x27 },
            // 其他键
            { KeyCode.PrintScreen, 0x2C },
            { KeyCode.ScrollLock, 0x91 },
            { KeyCode.Pause, 0x13 },
            { KeyCode.NumLock, 0x90 },
            { KeyCode.LeftShift, 0xA0 },
            { KeyCode.RightShift, 0xA1 },
            { KeyCode.LeftControl, 0xA2 },
            { KeyCode.RightControl, 0xA3 },
            { KeyCode.LeftAlt, 0xA4 },
            { KeyCode.RightAlt, 0xA5 },
            { KeyCode.LeftWindows, 0x5B },
            { KeyCode.RightWindows, 0x5C },
            { KeyCode.Menu, 0x5D }
        };
}