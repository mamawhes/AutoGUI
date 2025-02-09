﻿using System.Runtime.InteropServices;
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
    public class MouseAPI
    {
        public virtual void MouseMove(int x, int y)
        {
            Console.WriteLine($"mouse move to ({x},{y})");
        }

        public virtual void MouseDown(MouseButton mouseButton)
        {
            Console.WriteLine($"mouse down to ({(int)mouseButton})");
        }
        public virtual void MouseUp(MouseButton mouseButton)
        {
            Console.WriteLine($"mouse up to ({(int)mouseButton})");
        }

        public void MouseClick(MouseButton mouseButton)
        {
            MouseDown(mouseButton); 
            MouseUp(mouseButton);
        }

        public void MouseDoubleClick(MouseButton mouseButton=MouseButton.Left)
        {
            MouseClick(mouseButton);
            System.Threading.Thread.Sleep(100);
            MouseClick(mouseButton);
        }
    }

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

  
        

    }
}