using AutoGUI.API;

namespace AutoGUI;

internal class KeyboardAPIForWindows:KeyboardAPI
{
    public override void KeyUp(KeyCode keyCode)
    {
        base.KeyUp(keyCode);
    }
    public override void KeyDown(KeyCode keyCode)
    {
        base.KeyDown(keyCode);
    }
}