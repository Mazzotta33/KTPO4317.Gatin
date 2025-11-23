using KTPO.Gatin.Lib.LogAn;

namespace KTPO.Gatin.Lib.SampleCommands;

public class FirstCommand: ISampleCommand
{
    private readonly IView _view;
    private int _executeCounter = 0;
    
    public FirstCommand(IView view)
    {
        _view = view;
    }
    
    public void Execute()
    {
        _executeCounter++;
        _view.Render(this.GetType().ToString() + "\n ExecuteCounter = " + _executeCounter);
    }
}