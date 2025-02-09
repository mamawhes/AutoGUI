namespace ConsoleApp;
using AutoGUI;
class Program
{
    static void Main(string[] args)
    {
        MouseController.MouseMove(100,10);
       
        MouseController.MouseClick(MouseButton.Left);
        System.Threading.Thread.Sleep(1000);
        MouseController.MouseMove(100,50);
        MouseController.MouseClick(MouseButton.Left);
        //MouseController.MouseDoubleClick(MouseButton.Left);
        
        Console.WriteLine("Hello, World!");
    }
}