namespace ConsoleApp;
using AutoGUI;
class Program
{
    static void Main(string[] args)
    {
        
        MouseController.MouseMove(100,400);
       
        MouseController.MouseClick(MouseButton.Left);
        System.Threading.Thread.Sleep(1000);
        MouseController.MouseWheel(30);
        // MouseController.MouseMove(100,50);
        // MouseController.MouseClick(MouseButton.Left);
        // //MouseController.MouseDoubleClick(MouseButton.Left);
        
        Console.WriteLine("Hello, World!");
    }
}