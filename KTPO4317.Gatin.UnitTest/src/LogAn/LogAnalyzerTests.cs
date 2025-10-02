using KTPO.Gatin.Lib.LogAn;
using NUnit.Framework.Legacy;

namespace KTPO4317.Gatin.UnitTest.LogAn;

[TestFixture]
public class LogAnalyzerTests
{
    [Test]
    public void IsValidLogFileName_BadExtension_ReturnsFalse()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        
        bool result = analyzer.IsValidLogFileName(@"C:\log\log.txt");
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
    {
        var analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName("file.GATIN");
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
    {
        var analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName("file.gatin");
        Assert.That(result, Is.True);
    }
    
    [TestCase("file.GATIN")]
    [TestCase("file.gatin")]
    public void IsValidLogFileName_ValidExtension_ReturnsTrue( string fileName)
    {
        var analyzer = new LogAnalyzer();
        bool result = analyzer.IsValidLogFileName(fileName);
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsValidFileName_EmptyFileName_Throws()
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        var ex = Assert.Catch<ArgumentException>(() => analyzer.IsValidLogFileName(""));
        StringAssert.Contains("Имя файла должно быть задано", ex.Message);
    }

    [TestCase("file.foo", false)]
    [TestCase("file.Gatin", true)]
    public void IsValidFilename_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
    {
        LogAnalyzer analyzer = new LogAnalyzer();
        analyzer.IsValidLogFileName(file);
        Assert.That(analyzer.WasLastFileNameValid, Is.EqualTo(expected));
    }
}