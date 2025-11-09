namespace KTPO.Gatin.Lib.LogAn;

public interface ILogAnalyze
{
    public event LogAnalyzerAction Analyzed;
    public bool IsValidLogFileName(string fileName);
    public void Analyze(string fileName);
}