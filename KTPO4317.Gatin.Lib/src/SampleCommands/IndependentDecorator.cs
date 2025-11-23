using KTPO.Gatin.Lib.LogAn;

namespace KTPO.Gatin.Lib.SampleCommands;

public class IndependentDecorator: ISampleCommand
{
    private readonly ISampleCommand _sampleCommand;
    private readonly IView _view;
    
    public IndependentDecorator(ISampleCommand sampleCommand, IView view)
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
        catch(Exception ex)
        {
            _view.Render("Отловлена ошибка: " + ex.Message);
        }
        finally
        {
            _view.Render("Конец: " + this.GetType().ToString());
        }
    }
}