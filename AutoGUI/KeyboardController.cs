using System.Runtime.InteropServices;

namespace AutoGUI;
using AutoGUI.API;
public static class KeyboardController
{
    private static KeyboardAPI _api;

    private static void _Init()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (_api == null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _api = new KeyboardAPI();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                _api = new KeyboardAPIForMac();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _api = new KeyboardAPI();
            }
            else
            {
                _api = new KeyboardAPI();
            }
        }
    }

    public static void KeyDown(KeyCode keyCode)
    {
        _Init();
        _api.KeyDown(keyCode);
    }

    public static void KeyUp(KeyCode keyCode)
    {
        _Init();
        _api.KeyUp(keyCode);
    }

    public static void KeyClick(KeyCode keyCode)
    {
        _Init();
        _api.KeyClick(keyCode);
    }
}