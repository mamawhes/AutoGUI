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

        public virtual void MouseWheel(int delta)
        {
            Console.WriteLine($"mouse wheel to ({delta})");
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
}