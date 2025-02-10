using System.Runtime.InteropServices;
using AutoGUI.API;
namespace AutoGUI;


internal class MouseAPIForMac: MouseAPI
{
    // 导入 macOS 的 Core Graphics 框架
    private const string CoreGraphicsLibrary = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";

    // 定义鼠标事件类型
    private enum CGEventType
    {
        MouseMoved = 5,
        LeftMouseDown = 1,
        LeftMouseUp = 2,
        RightMouseDown = 3,
        RightMouseUp = 4,
        MiddleMouseDown = 25,
        MiddleMouseUp = 26,
        ScrollWheel = 22
    }
    // 定义鼠标滚轮事件类型
    private enum CGScrollEventUnit
    {
        Line = 0,
        Pixel = 1
    }
    // 导入 Core Graphics 函数
    [DllImport(CoreGraphicsLibrary)]
    private static extern IntPtr CGEventCreate(IntPtr source);
    [DllImport(CoreGraphicsLibrary)]
    private static extern IntPtr CGEventCreateMouseEvent(IntPtr source, CGEventType mouseType, CGPoint position, MouseButton button);
    [DllImport(CoreGraphicsLibrary)]
    private static extern IntPtr CGEventCreateScrollWheelEvent(IntPtr source, CGScrollEventUnit units, uint wheelCount, int wheel1, int wheel2);
    [DllImport(CoreGraphicsLibrary)]
    private static extern void CGEventPost(int tap, IntPtr evt);

    [DllImport(CoreGraphicsLibrary)]
    private static extern void CFRelease(IntPtr obj);

    [DllImport(CoreGraphicsLibrary)]
    private static extern void CGEventSetIntegerValueField(IntPtr evt, int field, long value);

    // 导入获取鼠标位置的函数
    [DllImport(CoreGraphicsLibrary)]
    private static extern CGPoint CGEventGetLocation(IntPtr eventRef);
    
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
    public static (double X, double Y) GetMousePosition()
    {
        // 创建一个空事件
        IntPtr eventRef = CGEventCreate(IntPtr.Zero);
        if (eventRef == IntPtr.Zero)
        {
            throw new InvalidOperationException("Failed to create CGEvent.");
        }

        // 获取鼠标位置
        CGPoint point = CGEventGetLocation(eventRef);

        // 释放事件
        CFRelease(eventRef);

        return (point.X, point.Y);
    }

    public override (double x, double y) pos
    {
        get => GetMousePosition();
        set
        {
            IntPtr eventRef = CGEventCreateMouseEvent(IntPtr.Zero, CGEventType.MouseMoved, new CGPoint(0, 0), MouseButton.Left);
            CGEventPost(0, eventRef);
            CFRelease(eventRef);
            //value = GetMousePosition();
        }
    }

    private static CGPoint _pos
    {
        get
        {
            var xy= GetMousePosition();
            return new CGPoint(xy.X, xy.Y);
        }
    }
    public override void MouseMove(int x, int y)
    {
        var new_pos = new CGPoint(_pos.X + x, _pos.Y + y);
        IntPtr eventRef = CGEventCreateMouseEvent(IntPtr.Zero, CGEventType.MouseMoved, new_pos, MouseButton.Left);
        CGEventPost(0, eventRef);
        CFRelease(eventRef);
    }

    public override void MouseDown(MouseButton mouseButton)
    {

        CGEventType eventType=CGEventType.LeftMouseDown;
        if (mouseButton == MouseButton.Left)
        {
            eventType = CGEventType.LeftMouseDown;
        }else if (mouseButton == MouseButton.Right)
        {
            eventType = CGEventType.RightMouseDown;
        }else if (mouseButton == MouseButton.Middle)
        {
            eventType = CGEventType.MiddleMouseDown;
        }
        IntPtr eventRef = CGEventCreateMouseEvent(IntPtr.Zero, eventType, _pos, mouseButton);
        CGEventPost(0, eventRef);
        CFRelease(eventRef);
    }

    public override void MouseUp(MouseButton mouseButton)
    {
        CGEventType eventType=CGEventType.LeftMouseUp;
        if (mouseButton == MouseButton.Left)
        {
            eventType = CGEventType.LeftMouseUp;
        }else if (mouseButton == MouseButton.Right)
        {
            eventType = CGEventType.RightMouseUp;
        }else if (mouseButton == MouseButton.Middle)
        {
            eventType = CGEventType.MiddleMouseUp;
        }
        IntPtr eventRef = CGEventCreateMouseEvent(IntPtr.Zero, eventType, _pos, mouseButton);
        CGEventPost(0, eventRef);
        CFRelease(eventRef);
    }

    public override void  MouseWheel(int delta)
    {
       // IntPtr eventRef = CGEventCreateMouseEvent(IntPtr.Zero, CGEventType.ScrollWheel, _pos, MouseButton.Middle);
        //CGEventSetIntegerValueField(eventRef, 88, delta); // 88 是滚轮事件的字段值
        IntPtr eventRef =CGEventCreateScrollWheelEvent(IntPtr.Zero, CGScrollEventUnit.Pixel, 1, delta, 0);
        CGEventPost(0, eventRef);
        CFRelease(eventRef);
    }

  
        

}