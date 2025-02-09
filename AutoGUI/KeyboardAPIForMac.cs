using System.Runtime.InteropServices;
using AutoGUI.API;

namespace AutoGUI;

internal class KeyboardAPIForMac: KeyboardAPI
{
    private const string CoreGraphicsLibrary = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";

    // 定义 macOS API 的函数
    [DllImport(CoreGraphicsLibrary)]
    private static extern IntPtr CGEventCreateKeyboardEvent(IntPtr source, ushort virtualKey, bool keyDown);

    [DllImport(CoreGraphicsLibrary)]
    private static extern void CGEventPost(int tap, IntPtr evt);

    [DllImport(CoreGraphicsLibrary)]
    private static extern void CFRelease(IntPtr obj);

    // 定义按键事件的位置（kCGHIDEventTap 表示全局事件）
    private const int kCGHIDEventTap = 0;

    // 定义虚拟键码（这里以字母 A 为例）
    private const ushort kVK_ANSI_A = 0x00;
    public override void KeyClick(KeyCode keyCode)
    {
        base.KeyClick(keyCode);
    }

    public override void KeyDown(KeyCode keyCode)
    {
        ushort virtualKey = KeyToVirtualKeyCode[keyCode];
        IntPtr eventRef = CGEventCreateKeyboardEvent(IntPtr.Zero, virtualKey, true);
        if (eventRef != IntPtr.Zero)
        {
            CGEventPost(kCGHIDEventTap, eventRef);
            CFRelease(eventRef);
        }
    }

    public override void KeyUp(KeyCode keyCode)
    {
        ushort virtualKey = KeyToVirtualKeyCode[keyCode];
        IntPtr eventRef = CGEventCreateKeyboardEvent(IntPtr.Zero, virtualKey, false);
        if (eventRef != IntPtr.Zero)
        {
            CGEventPost(kCGHIDEventTap, eventRef);
            CFRelease(eventRef);
        }
    }

    public static readonly Dictionary<KeyCode, ushort> KeyToVirtualKeyCode = new Dictionary<KeyCode, ushort>
    {
        // 字母键
        { KeyCode.A, 0x00 },
        { KeyCode.B, 0x0B },
        { KeyCode.C, 0x08 },
        { KeyCode.D, 0x02 },
        { KeyCode.E, 0x0E },
        { KeyCode.F, 0x03 },
        { KeyCode.G, 0x05 },
        { KeyCode.H, 0x04 },
        { KeyCode.I, 0x22 },
        { KeyCode.J, 0x26 },
        { KeyCode.K, 0x28 },
        { KeyCode.L, 0x25 },
        { KeyCode.M, 0x2E },
        { KeyCode.N, 0x2D },
        { KeyCode.O, 0x1F },
        { KeyCode.P, 0x23 },
        { KeyCode.Q, 0x0C },
        { KeyCode.R, 0x0F },
        { KeyCode.S, 0x01 },
        { KeyCode.T, 0x11 },
        { KeyCode.U, 0x20 },
        { KeyCode.V, 0x09 },
        { KeyCode.W, 0x0D },
        { KeyCode.X, 0x07 },
        { KeyCode.Y, 0x10 },
        { KeyCode.Z, 0x06 },

        // 数字键
        { KeyCode.D0, 0x1D },
        { KeyCode.D1, 0x12 },
        { KeyCode.D2, 0x13 },
        { KeyCode.D3, 0x14 },
        { KeyCode.D4, 0x15 },
        { KeyCode.D5, 0x17 },
        { KeyCode.D6, 0x16 },
        { KeyCode.D7, 0x1A },
        { KeyCode.D8, 0x1C },
        { KeyCode.D9, 0x19 },

        // 功能键
        { KeyCode.F1, 0x7A },
        { KeyCode.F2, 0x78 },
        { KeyCode.F3, 0x63 },
        { KeyCode.F4, 0x76 },
        { KeyCode.F5, 0x60 },
        { KeyCode.F6, 0x61 },
        { KeyCode.F7, 0x62 },
        { KeyCode.F8, 0x64 },
        { KeyCode.F9, 0x65 },
        { KeyCode.F10, 0x6D },
        { KeyCode.F11, 0x67 },
        { KeyCode.F12, 0x6F },

        // 控制键
        { KeyCode.Escape, 0x35 },
        { KeyCode.Tab, 0x30 },
        { KeyCode.CapsLock, 0x39 },
        { KeyCode.Shift, 0x38 }, // 左 Shift
        { KeyCode.Control, 0x3B }, // 左 Control
        { KeyCode.Alt, 0x3A }, // 左 Option (Alt)
        { KeyCode.Space, 0x31 },
        { KeyCode.Enter, 0x24 },
        { KeyCode.Backspace, 0x33 },
        { KeyCode.Delete, 0x75 },
        { KeyCode.Insert, 0x72 },
        { KeyCode.Home, 0x73 },
        { KeyCode.End, 0x77 },
        { KeyCode.PageUp, 0x74 },
        { KeyCode.PageDown, 0x79 },

        // 方向键
        { KeyCode.UpArrow, 0x7E },
        { KeyCode.DownArrow, 0x7D },
        { KeyCode.LeftArrow, 0x7B },
        { KeyCode.RightArrow, 0x7C },

        // 其他键
        { KeyCode.PrintScreen, 0x69 }, // F13 (PrintScreen)
        { KeyCode.ScrollLock, 0x6B }, // F14 (ScrollLock)
        { KeyCode.Pause, 0x71 }, // F15 (Pause)
        { KeyCode.NumLock, 0x47 },
        { KeyCode.LeftShift, 0x38 }, // 左 Shift
        { KeyCode.RightShift, 0x3C }, // 右 Shift
        { KeyCode.LeftControl, 0x3B }, // 左 Control
        { KeyCode.RightControl, 0x3E }, // 右 Control
        { KeyCode.LeftAlt, 0x3A }, // 左 Option (Alt)
        { KeyCode.RightAlt, 0x3D }, // 右 Option (Alt)
        { KeyCode.LeftWindows, 0x37 }, // 左 Command
        { KeyCode.RightWindows, 0x36 }, // 右 Command
        { KeyCode.Menu, 0x32 } // Menu 键
    };
}