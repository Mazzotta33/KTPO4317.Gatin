namespace KTPO.Gatin.Lib.LogAn;

public static class WebServiceFactory
{
    public static IWebService customService = null;

    /// <summary>Создание объектов</summary>
    public static IWebService Create()
    {
        if (customService != null)
            return customService;

        return new WebService();
    }
    
    
    /// <summary>Метод позволит тестам контроллировать
    /// что возвращает фабрика
    /// </summary>
    public static void SetWebService(IWebService service)
    {
        customService = service;
    }
}