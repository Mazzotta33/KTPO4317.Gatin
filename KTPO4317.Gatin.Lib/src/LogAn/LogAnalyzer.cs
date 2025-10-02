namespace KTPO.Gatin.Lib.LogAn;

public class LogAnalyzer
{
    public bool IsValidLogFileName(string fileName)
    {
        var mgr = ExtensionManagerFactory.Create();
        try
        {
            return mgr.IsValid(fileName);
        }
        catch
        {
            return false;
        }
    }
}