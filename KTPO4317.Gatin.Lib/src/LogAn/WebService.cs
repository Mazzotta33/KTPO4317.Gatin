namespace KTPO.Gatin.Lib.LogAn;

public class WebService: IWebService
{
    public void LogError(string message)
    {
        Console.WriteLine("WebService.LogError: " + message);
    }
}