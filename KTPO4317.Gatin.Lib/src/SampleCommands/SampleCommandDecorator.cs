using KTPO.Gatin.Lib.LogAn;

namespace KTPO.Gatin.Lib.SampleCommands;

public class SampleCommandDecorator: ISampleCommand
{
    private readonly ISampleCommand _sampleCommand;
    private readonly IView _view;
    
    public SampleCommandDecorator(ISampleCommand sampleCommand, IView view)
    {
        _sampleCommand = sampleCommand;
        _view = view;
    }

    public void Execute()
    {
        _view.Render("Начало: " + this.GetType().ToString());
        try
        {
            _sampleCommand.Execute();
        }
        finally
        {
            _view.Render("Конец: " + this.GetType().ToString());
        }
    }
}