using Microsoft.Extensions.Configuration;

namespace KTPO.Gatin.Lib.LogAn;

public interface IExtensionManager
{
    bool IsValid(string fileName);
}

/// <summary>
/// Менеджер проверки расширений файлов
/// </summary>
public class FileExtensionManager : IExtensionManager
{
    private readonly string _allowedExtension;

    public FileExtensionManager()
    {
        // Загружаем конфигурацию
        var config = new ConfigurationBuilder()
            .SetBasePath("D:/Лабы/KTPO4317.Gatin/KTPO4317.Gatin.Service")
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _allowedExtension = config["AllowedExtension"] 
                            ?? throw new InvalidOperationException("AllowedExtension не задан в appsettings.json");
    }

    /// <summary>
    /// Проверяет, валидно ли расширение файла
    /// </summary>
    public bool IsValid(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("Имя файла должно быть задано");
        }

        return fileName.EndsWith(_allowedExtension, StringComparison.CurrentCultureIgnoreCase);
    }
}