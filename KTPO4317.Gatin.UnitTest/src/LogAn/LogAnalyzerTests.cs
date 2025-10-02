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