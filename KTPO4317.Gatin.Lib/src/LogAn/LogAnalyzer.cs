namespace KTPO.Gatin.Lib.LogAn;

public interface IWebService
{
    void LogError(string message);
}

public class LogAnalyzer : ILogAnalyze
{
    public event LogAnalyzerAction Analyzed = null;
    
    public void Analyze(string fileName)
    {
        if (fileName.Length < 8)
        {
            try
            {
                var svc = WebServiceFactory.Create();
                svc.LogError("Too short filename: " + fileName);
            }
            catch (Exception e)
            {
                IEmailService emailService = EmailServiceFactory.Create();
                emailService.SendEmail("someone@somewhere.com", "EmailService error", e.Message);
            }
            
        }
        
        //Вызов события
        if (Analyzed != null)
            Analyzed();
    }

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
    
    protected void RaiseAnalyzedEvent()
    {
        if (Analyzed != null)
            Analyzed(); 
    }
}