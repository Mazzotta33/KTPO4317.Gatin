namespace KTPO.Gatin.Lib.LogAn;

public class Presenter
{
    private LogAnalyzer _logAnalyzer;
    private IView _view;

    public Presenter(LogAnalyzer logAnalyzer, IView view)
    {
        _logAnalyzer = logAnalyzer;
        _view = view;

        _logAnalyzer.Analyzed += OnLogAnalyzed;
    }

    private void OnLogAnalyzed()
    {
        _view.Render("Обработка завершена");
    }
}