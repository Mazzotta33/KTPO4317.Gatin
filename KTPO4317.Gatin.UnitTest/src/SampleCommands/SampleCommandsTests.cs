using KTPO.Gatin.Lib.LogAn;
using KTPO.Gatin.Lib.SampleCommands;
using NSubstitute;

namespace KTPO4317.Gatin.UnitTest.SampleCommands;

public class SampleCommandsTests
{
    [Test]
    public void FirstCommand_CallsExecute_CallsRender()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommand sampleCommand = new FirstCommand(mockView);
        
        sampleCommand.Execute();
        
        mockView.Received().Render(Arg.Any<string>());
    }
    
    [Test]
    public void SampleCommandDecorator_CallsDecoratorExecute_CallsExecute()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommand sampleCommand = Substitute.For<ISampleCommand>();
        SampleCommandDecorator sampleCommandDecorator = new SampleCommandDecorator(sampleCommand, mockView);
        
        sampleCommandDecorator.Execute();
        
        sampleCommand.Received().Execute();
    }
    
    [Test]
    public void SampleCommandDecorator_CallsExecute_CallsRender()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommand sampleCommand = Substitute.For<ISampleCommand>();
        SampleCommandDecorator sampleCommandDecorator = new SampleCommandDecorator(sampleCommand, mockView);
        
        sampleCommandDecorator.Execute();
        
        mockView.Received().Render(Arg.Any<string>());
    }
    
    [Test]
    public void IndependentDecorator_CallsDecoratorExecute_CallsExecute()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommand sampleCommand = Substitute.For<ISampleCommand>();
        IndependentDecorator independentDecorator = new IndependentDecorator(sampleCommand, mockView);
        
        independentDecorator.Execute();
            
        
        sampleCommand.Received().Execute();
    }
    
    [Test]
    public void IndependentDecorator_ThrowException_CatchException()
    {
        IView mockView = Substitute.For<IView>();
        ISampleCommand sampleCommand = new SecondCommand(mockView);
        IndependentDecorator independentDecorator = new IndependentDecorator(sampleCommand, mockView);
        
        independentDecorator.Execute();
        
        mockView.Received().Render(Arg.Any<string>());
    }
}