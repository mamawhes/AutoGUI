using System.Runtime.InteropServices;

namespace AutoGUI;

public static class TouchpadController
{
    public static void LightClick()
    {
        MouseController.MouseClick(MouseButton.Left);
    }

    public static void DoubleClick()
    {
        MouseController.MouseClick(MouseButton.Right);
    }

    public static void Move(int x, int y)
    {
        MouseController.MouseMove(x, y);
    }

    public static void Slide(int delta)
    {
        MouseController.MouseWheel(delta);
    }

    public static void Zoom(int delta)
    {
        var key = KeyCode.LeftControl;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            key = KeyCode.LeftWindows;
        }
        KeyboardController.KeyDown(key);
        System.Threading.Thread.Sleep(10);
        
        MouseController.MouseWheel(delta);
        //System.Threading.Thread.Sleep(100);
        KeyboardController.KeyUp(key);
    }
    
}