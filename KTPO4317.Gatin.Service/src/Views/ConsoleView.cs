using KTPO.Gatin.Lib.LogAn;

namespace KTPO4317.Gatin.Service.Views;

public class ConsoleView: IView
{
    public void Render(String text)
    {
        Console.WriteLine(text);
    }
}