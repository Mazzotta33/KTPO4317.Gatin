using KTPO.Gatin.Lib.LogAn;
using NSubstitute;

namespace KTPO4317.Gatin.UnitTest.sample;

public class SampleNSubstituteTests
{
    [Test]
    public void Returns_ParticularArg_Works()
    {
        IExtensionManager fakExtensionManager = Substitute.For<IExtensionManager>();
        fakExtensionManager.IsValid("validfile.txt").Returns(true);
        bool result = fakExtensionManager.IsValid("validfile.txt");
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Returns_ArgAny_Works()
    {
        IExtensionManager fakExtensionManager = Substitute.For<IExtensionManager>();
        fakExtensionManager.IsValid(Arg.Any<string>()).Returns(true);
        bool result = fakExtensionManager.IsValid("anyfile.ext");
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Returns_ArgAny_Throws()
    {
        IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();
        fakeExtensionManager.When(x => x.IsValid(Arg.Any<string>()))
            .Do(context => { throw new Exception("fake exception"); });
        
        Action act = () => fakeExtensionManager.IsValid("anyfile.ext");

        Assert.Throws<Exception>(() => fakeExtensionManager.IsValid("anything"));
    }
    
    [Test]
    public void Received_ParticularArg_Saves()
    {
        IWebService mockWebService = Substitute.For<IWebService>();
        mockWebService.LogError("Поддельное сообщение");
        
        mockWebService.Received().LogError("Поддельное сообщение");
    }
    
}