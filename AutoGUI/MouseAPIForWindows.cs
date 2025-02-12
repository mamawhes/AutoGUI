using AutoGUI.API;
using System.Runtime.InteropServices;

namespace AutoGUI;
internal class MouseAPIForWindows: MouseAPI
{
    // 导入 user32.dll 中的函数
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point lpPoint);
    
    // 定义Point结构体，用于存储鼠标位置
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }
    }
    // 鼠标事件常量
    private const uint MOUSEEVENTF_MOVE = 0x0001;
    private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const uint MOUSEEVENTF_LEFTUP = 0x0004;
    private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
    private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
    private const uint MOUSEEVENTF_WHEEL = 0x0800; // 鼠标滚轮事件
    public sealed override void MouseMove(int x, int y)
    {

        mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
    }

    public override (double x, double y) pos
    {
        get
        {
            GetCursorPos(out var p);
            return (p.X, p.Y);
        }
        set
        {
            MouseMove(-10000, -10000);
            MouseMove((int)value.x,(int)value.y);
        }
    }

    public override void MouseDown(MouseButton mouseButton)
    {
        if(mouseButton == MouseButton.Left)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }else if(mouseButton == MouseButton.Right)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
        }else if(mouseButton == MouseButton.Middle)
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
        }
        else
        {
            base.MouseDown(mouseButton);
        }
        
    }

    public override void MouseUp(MouseButton mouseButton)
    {
        if (mouseButton == MouseButton.Left)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        else if (mouseButton == MouseButton.Right)
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }
        else if (mouseButton == MouseButton.Middle)
        {
            mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }
        else
        {
            base.MouseDown(mouseButton);
        }
    }

    public override void MouseWheel(int delta)
    {
        mouse_event(MOUSEEVENTF_WHEEL, 0, 0, (uint)delta, 0);
    }
    
    
}