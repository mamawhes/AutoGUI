namespace ConsoleApp;
using AutoGUI;
class Program
{
    static void Main(string[] args)
    {
        
        MouseController.MouseMove(1500,550);
        //MouseController.MouseWheel(300);
        MouseController.MouseClick(MouseButton.Left);
        System.Threading.Thread.Sleep(1000);
        KeyboardController.KeyClick(KeyCode.A);
        KeyboardController.KeyClick(KeyCode.P);
        KeyboardController.KeyClick(KeyCode.P);
        KeyboardController.KeyClick(KeyCode.L);
        KeyboardController.KeyClick(KeyCode.E);
        KeyboardController.KeyClick(KeyCode.Enter);
        //MouseController.MouseWheel(30);
        // MouseController.MouseMove(100,50);
        // MouseController.MouseClick(MouseButton.Left);
        // //MouseController.MouseDoubleClick(MouseButton.Left);

        Console.WriteLine("Hello, World!");
    }
}