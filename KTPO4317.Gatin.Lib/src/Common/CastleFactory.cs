using Castle.Windsor;

namespace KTPO.Gatin.Lib.Common;

public class CastleFactory
{
    /// <summary> Контейнер </summary>
    public static IWindsorContainer container { get; private set; }

    static CastleFactory()
    {
        //создаем объект контейнер
        container = new WindsorContainer();
    }
}