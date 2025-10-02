namespace KTPO.Gatin.Lib.LogAn;

public class LogAnalyzer
{
    private readonly IExtensionManager _extensionManager;

    public LogAnalyzer(IExtensionManager extensionManager)
    {
        _extensionManager = extensionManager;
    }

    public bool IsValidLogFileName(string fileName)
    {
        try
        {
            return _extensionManager.IsValid(fileName);
        }
        catch
        {
            return false;
        }
    }
}