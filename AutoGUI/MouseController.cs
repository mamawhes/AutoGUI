using System.Numerics;
using System.Runtime.InteropServices;

namespace AutoGUI
{
    
    public static class MouseController
    {
        private static MouseAPI _api ;

        private static void _Init()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (_api == null)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    _api = new MouseAPI();
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    _api = new MouseAPIForMac();
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    _api = new MouseAPI();
                }
                else
                {
                    _api = new MouseAPI();
                }
            }
        }

        public static void MouseDown(MouseButton mouseButton)
        {
            _Init();
            _api.MouseDown(mouseButton);
        }

        public static void MouseMove(int x, int y)
        {
            _Init();
            _api.MouseMove(x,y);
        }

        public static void MouseUp(MouseButton mouseButton)
        {
            _Init();
            _api.MouseUp(mouseButton);
        }

        public static void MouseWheel(int delta)
        {
            _Init();
            _api.MouseWheel(delta);
        }

        public static void MouseClick(MouseButton mouseButton)
        {
            _Init();
            _api.MouseClick(mouseButton);
        }

        public static void MouseDoubleClick(MouseButton mouseButton)
        {
            _Init();
            _api.MouseDoubleClick(mouseButton);
        }
    }
}

