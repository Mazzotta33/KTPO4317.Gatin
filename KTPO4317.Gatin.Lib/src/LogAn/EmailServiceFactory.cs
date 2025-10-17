namespace KTPO.Gatin.Lib.LogAn;

public class EmailServiceFactory
{
    public static IEmailService customManager = null;

    /// <summary>Создание объектов</summary>
    public static IEmailService Create()
    {
        if (customManager != null)
            return customManager;

        return new EmailService();
    }
    
    
    /// <summary>Метод позволит тестам контроллировать
    /// что возвращает фабрика
    /// </summary>
    public static void SetEmailService(IEmailService service)
    {
        customManager = service;
    }
}