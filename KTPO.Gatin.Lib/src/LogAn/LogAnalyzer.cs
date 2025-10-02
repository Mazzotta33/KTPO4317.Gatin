namespace KTPO.Gatin.Lib.LogAn;

public class LogAnalyzer
{
    public bool WasLastFileNameValid { get; set; }
    public bool IsValidLogFileName(string fileName)
    {
        WasLastFileNameValid = false;
        
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException("Имя файла должно быть задано");
        }
        
        if (!fileName.EndsWith(".Gatin", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }
        WasLastFileNameValid = true;
        
        return true;
    }
}