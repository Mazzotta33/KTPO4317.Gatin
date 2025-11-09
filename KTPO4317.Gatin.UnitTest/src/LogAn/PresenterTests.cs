using KTPO.Gatin.Lib.LogAn;
using NSubstitute;

namespace KTPO4317.Gatin.UnitTest.LogAn;

[TestFixture]
public class PresenterTests
{
    [Test]
    public void ctor_WhenAnalyzed_CallsViewRender()
    {
        //Arrange
        FakeLogAnalyzer fakeLogAnalyzer = new FakeLogAnalyzer();
        IView mockView = Substitute.For<IView>();
        Presenter presenter = new Presenter(fakeLogAnalyzer, mockView);
        
        //Act
        fakeLogAnalyzer.CallRaiseAnalyzedEvent();
        
        //Assert
        mockView.Received().Render("Обработка завершена");
    }
    
    [Test]
    public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
    {
        //Arrange
        ILogAnalyze mockLogAnalyzer = Substitute.For<ILogAnalyze>();
        IView mockView = Substitute.For<IView>();
        Presenter presenter = new Presenter(mockLogAnalyzer, mockView);
        
        //Act
        mockLogAnalyzer.Analyzed += Raise.Event<LogAnalyzerAction>();
        
        //Assert
        mockView.Received().Render("Обработка завершена");
    }
}

class FakeLogAnalyzer : LogAnalyzer
{
    public void CallRaiseAnalyzedEvent()
    {
        base.RaiseAnalyzedEvent();
    }
}