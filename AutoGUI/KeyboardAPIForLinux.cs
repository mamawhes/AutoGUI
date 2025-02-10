using AutoGUI.API;

namespace AutoGUI;

internal class KeyboardAPIForLinux: KeyboardAPI
{
    public override void KeyDown(KeyCode keyCode)
    {
        base.KeyDown(keyCode);
    }

    public override void KeyUp(KeyCode keyCode)
    {
        base.KeyUp(keyCode);
    }
    
}