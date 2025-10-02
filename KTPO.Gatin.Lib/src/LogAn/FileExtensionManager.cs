namespace KTPO.Gatin.Lib.LogAn;

public interface IExtensionManager
{
    /// <summary>
    /// Проверяет, валидно ли расширение файла
    /// </summary>
    bool IsValid(string fileName);
}

/// <summary>
/// Менеджер проверки расширений файлов
/// </summary>
public class FileExtensionManager : IExtensionManager
{
    /// <summary>
    /// Проверяет, валидно ли расширение файла
    /// </summary>
    public bool IsValid(string fileName)
    {
        throw new NotImplementedException();
    }
}