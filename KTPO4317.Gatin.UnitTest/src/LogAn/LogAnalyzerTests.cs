using KTPO.Gatin.Lib.LogAn;
using NUnit.Framework.Legacy;

namespace KTPO4317.Gatin.UnitTest.LogAn
{
    
    
    [TestFixture]
    public class LogAnalyzerTests
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
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;
            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();
            var result = log.IsValidLogFileName("file.Gatin");
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void IsValidFileName_NameUnsupportedExtension_ReturnsFalse()
        {
            var fakeMgr = new FakeExtensionManager { WillBeValid = false };
            ExtensionManagerFactory.SetManager(fakeMgr);
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("file.txt");

            Assert.That(result, Is.False);
        }
        
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            var fakeMgr = new FakeExtensionManager { WillThrow = new Exception("Ошибка") };
            ExtensionManagerFactory.SetManager(fakeMgr);
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("file.Gatin");

            Assert.That(result, Is.False);
        }
        
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string fileName = "short";
        
            log.Analyze(fileName);

            Assert.That(mockWebService.LastError, Is.EqualTo("Too short filename: " + fileName));
        }
        
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            //Arrange
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.SetWebService(stubWebService);
            stubWebService.WillThrow = new Exception("Это подделка");   
        
            FakeEmailService mockEmailService = new FakeEmailService();
            EmailServiceFactory.SetEmailService(mockEmailService);
        
            LogAnalyzer log = new LogAnalyzer();
            string fileName = "short";
        
            //Act
            log.Analyze(fileName);

            //Assert
            Assert.That(mockEmailService.LastTo, Is.EqualTo("someone@somewhere.com"));
            Assert.That(mockEmailService.LastSubject, Is.EqualTo("EmailService error"));
            Assert.That(mockEmailService.LastBody, Is.EqualTo("Это подделка"));
        }
    }

    internal class FakeWebService : IWebService
    {
        /// <summary>   
        /// Это поле запоминает состояние
        /// после вызова метода LogError при тестировании
        /// взаимодействия утверждения высказываются относительно
        /// </summary>
        public string LastError;
        
        
        /// <summary>
        /// Это поле позволяет настроить поддельное
        /// исключение вызываемое в методе LogError
        /// </summary>
        public Exception WillThrow = null;
        
        public void LogError(string message)
        {
            if (WillThrow != null)
                throw WillThrow;
            
            LastError = message;
        }
    }
    
    internal class FakeEmailService : IEmailService
    {
        public string LastTo;
        public string LastSubject;
        public string LastBody;
    
        /// <summary>
        /// Это поле позволяет настроить поддельное
        /// исключение вызываемое в методе IsValid
        /// </summary>
        public Exception WillThrow = null;

        public void SendEmail(string to, string subject, string body)
        {
            LastTo = to;
            LastSubject = subject;
            LastBody = body;
        }
    }

    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public Exception WillThrow = null;
        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }

            return WillBeValid;
        }
    }
}