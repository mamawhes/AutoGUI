using System.Runtime.InteropServices;

namespace AutoGUI;

public class MouseAPIForMac: MouseAPI
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
    private static extern IntPtr CGEventCreateMouseEvent(IntPtr source, CGEventType mouseType, CGPoint position, MouseButton button);
    [DllImport(CoreGraphicsLibrary)]
    private static extern IntPtr CGEventCreateScrollWheelEvent(IntPtr source, CGScrollEventUnit units, uint wheelCount, int wheel1, int wheel2);
    [DllImport(CoreGraphicsLibrary)]
    private static extern void CGEventPost(int tap, IntPtr evt);

    [DllImport(CoreGraphicsLibrary)]
    private static extern void CFRelease(IntPtr obj);

    [DllImport(CoreGraphicsLibrary)]
    private static extern void CGEventSetIntegerValueField(IntPtr evt, int field, long value);

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
    private static CGPoint _pos=new CGPoint(0,0);
    public override void MouseMove(int x, int y)
    {
        _pos = new CGPoint(x, y);
        IntPtr eventRef = CGEventCreateMouseEvent(IntPtr.Zero, CGEventType.MouseMoved, _pos, MouseButton.Left);
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
        IntPtr eventRef =CGEventCreateScrollWheelEvent(IntPtr.Zero, CGScrollEventUnit.Line, 1, delta, 0);
        CGEventPost(0, eventRef);
        CFRelease(eventRef);
    }

  
        

}