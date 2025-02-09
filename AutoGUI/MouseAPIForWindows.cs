using AutoGUI.API;

namespace AutoGUI;
//using System.Windows;
internal class MouseAPIForWindows: MouseAPI
{
    public override void MouseMove(int x, int y)
    {
        base.MouseMove(x, y);
    }

    public override void MouseDown(MouseButton mouseButton)
    {
        base.MouseDown(mouseButton);
    }

    public override void MouseUp(MouseButton mouseButton)
    {
        base.MouseUp(mouseButton);
    }

    public override void MouseWheel(int delta)
    {
        base.MouseWheel(delta);
    }
    
}