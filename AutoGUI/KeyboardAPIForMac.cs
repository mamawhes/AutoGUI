using AutoGUI.API;

namespace AutoGUI;

internal class KeyboardAPIForMac: KeyboardAPI
{
    public override void KeyClick(KeyCode keyCode)
    {
        base.KeyClick(keyCode);
    }

    public override void KeyDown(KeyCode keyCode)
    {
        base.KeyDown(keyCode);
    }

    public override void KeyUp(KeyCode keyCode)
    {
        base.KeyUp(keyCode);
    }
}