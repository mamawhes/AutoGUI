namespace AutoGUI
{
    namespace API
    {
        internal class KeyboardAPI
        {
            public virtual void KeyDown(KeyCode keyCode)
            {
                Console.WriteLine("KeyDown: " + keyCode);
            }

            public virtual void KeyUp(KeyCode keyCode)
            {
                Console.WriteLine("KeyUp: " + keyCode);
            }

            public virtual void KeyClick(KeyCode keyCode)
            {
                this.KeyDown(keyCode);
                System.Threading.Thread.Sleep(100);
                this.KeyUp(keyCode);
            }
        }
    }
    public enum KeyCode
    {    // 字母键
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
    
        // 数字键
        D0,
        D1,
        D2,
        D3,
        D4,
        D5,
        D6,
        D7,
        D8,
        D9,
    
        // 功能键
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
    
        // 控制键
        Escape,
        Tab,
        CapsLock,
        Shift,
        Control,
        Alt,
        Space,
        Enter,
        Backspace,
        Delete,
        Insert,
        Home,
        End,
        PageUp,
        PageDown,
    
        // 方向键
        UpArrow,
        DownArrow,
        LeftArrow,
        RightArrow,
    
        // 其他键
        PrintScreen,
        ScrollLock,
        Pause,
        NumLock,
        LeftShift,
        RightShift,
        LeftControl,
        RightControl,
        LeftAlt,
        RightAlt,
        LeftWindows,
        RightWindows,
        Menu
    }
}
