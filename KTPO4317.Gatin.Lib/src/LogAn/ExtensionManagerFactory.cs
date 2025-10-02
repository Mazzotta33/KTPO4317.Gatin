namespace KTPO.Gatin.Lib.LogAn;

public static class ExtensionManagerFactory
{
    private static IExtensionManager customManager = null;

    public static IExtensionManager Create()
    {
        if (customManager != null)
        {
            return customManager;
        }
        return new FileExtensionManager();
    }

    public static void SetManager(IExtensionManager mgr)
    {
        customManager = mgr;
    }
}