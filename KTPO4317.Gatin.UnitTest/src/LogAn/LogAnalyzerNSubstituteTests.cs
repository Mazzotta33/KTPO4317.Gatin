using KTPO.Gatin.Lib.LogAn;
using NSubstitute;

namespace KTPO4317.Gatin.UnitTest.LogAn;

[TestFixture]
public class LogAnalyzerNSubstituteTests
{
    [TearDown]
    public void AfterEachTest()
    {
        ExtensionManagerFactory.SetManager(null);
        WebServiceFactory.SetWebService(null);
        EmailServiceFactory.SetEmailService(null);
    }
    
    [Test]
    public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
    {
        IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
        fakeExtensionManager.IsValid("short.ext").Returns(true);
        ExtensionManagerFactory.SetManager(fakeExtensionManager);
        LogAnalyzer log = new LogAnalyzer();
        
        bool result = log.IsValidLogFileName("short.ext");

        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsValidFileName_NotSupportedExtension_ReturnsFalse()
    {
        IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
        fakeExtensionManager.IsValid("invalid.ext").Returns(false);
        ExtensionManagerFactory.SetManager(fakeExtensionManager);
        
        LogAnalyzer log = new LogAnalyzer();
        
        bool result = log.IsValidLogFileName("invalid.ext");

        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
    {
        IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
        fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
            .Do(context => { throw new Exception("fake exception"); });
        ExtensionManagerFactory.SetManager(fakeExtensionManager);
        
        LogAnalyzer log = new LogAnalyzer();
        bool result = log.IsValidLogFileName("throws.rxt");

        Assert.That(result, Is.False);
    }
    
    [Test]
    public void Analyze_TooShortFileName_CallsWebService()
    {
        IWebService mockWebService = Substitute.For<IWebService>();
        WebServiceFactory.SetWebService(mockWebService);
        LogAnalyzer log = new LogAnalyzer();
        string fileName = "short";
        log.Analyze(fileName);
    
        mockWebService.Received().LogError("Too short filename: short");
    }
    
    [Test]
    public void Analyze_WebServiceThrows_SendsEmail()
    {
        IWebService stubWebService = Substitute.For<IWebService>();
        stubWebService.When(x => x.LogError(Arg.Any<string>()))
            .Do(context => { throw new Exception("Это подделка"); });
        WebServiceFactory.SetWebService(stubWebService);  
        
        IEmailService mockEmailService = Substitute.For<IEmailService>();
        EmailServiceFactory.SetEmailService(mockEmailService);
        
        LogAnalyzer log = new LogAnalyzer();
        string fileName = "short";
        
        log.Analyze(fileName);
    
        mockEmailService.Received().SendEmail("someone@somewhere.com", "EmailService error", "Это подделка");
    }
}