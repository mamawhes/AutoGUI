using System.Runtime.InteropServices;
using System;
using System.Runtime.CompilerServices;

namespace AutoGUI
{
    public enum MouseButton
    {
        Left = 0,
        Right = 1,
        Middle = 2,
    }
    public interface IMouseAPI
    {
        public static void MouseMove(int x, int y)
        {
            Console.WriteLine($"mouse move to ({x},{y})");
        }

        public static void MouseDown(MouseButton mouseButton)
        {
            Console.WriteLine($"mouse down to ({(int)mouseButton})");
        }
        public static void MouseUp(MouseButton mouseButton)
        {
            Console.WriteLine($"mouse up to ({(int)mouseButton})");
        }

        public static void MouseClick(MouseButton mouseButton)
        {
            MouseDown(mouseButton); 
            MouseUp(mouseButton);
        }

        public static void MouseDoubleClick(MouseButton mouseButton=MouseButton.Left)
        {
            MouseClick(mouseButton);
            System.Threading.Thread.Sleep(100);
            MouseClick(mouseButton);
        }
    }

    public class MouseAPIForMac: IMouseAPI
    {
        // 导入 Core Graphics 函数
        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        private static extern IntPtr CGEventCreateMouseEvent(IntPtr source, uint mouseType, CGPoint point, uint mouseButton);

        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        private static extern void CGEventPost(uint tap, IntPtr eventRef);

        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        private static extern void CFRelease(IntPtr obj);

        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        private static extern void CGEventSetIntegerValueField(IntPtr eventRef, uint field, long value);

        // 定义鼠标事件类型
        private const uint kCGEventMouseMoved = 5;
        private const uint kCGEventLeftMouseDown = 1;
        private const uint kCGEventLeftMouseUp = 2;
        private const uint kCGEventRightMouseDown = 3;
        private const uint kCGEventRightMouseUp = 4;
        private const uint kCGEventOtherMouseDown = 25;
        private const uint kCGEventOtherMouseUp = 26;
        private const uint kCGEventScrollWheel = 22;
        private const uint kCGHIDEventTap = 0;

        // 定义鼠标滚轮字段
        private const uint kCGScrollWheelEventDeltaAxis1 = 11;

        // 定义 CGPoint 结构
        [StructLayout(LayoutKind.Sequential)]
        private struct CGPoint
        {
            public double X;
            public double Y;

            public CGPoint(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        public static void MouseMove(int x, int y)
        {
            IMouseAPI.MouseMove(x, y);
        }

        public static void MouseDown(MouseButton mouseButton)
        {
            IMouseAPI.MouseDown(mouseButton);
        }

        public static void MouseUp(MouseButton mouseButton)
        {
            IMouseAPI.MouseUp(mouseButton);
        }

        public static void MouseClick(MouseButton mouseButton)
        {
            IMouseAPI.MouseClick(mouseButton);
        }

        public static void MouseDoubleClick(MouseButton mouseButton)
        {
            IMouseAPI.MouseDoubleClick(mouseButton);
        }
        

    }
}