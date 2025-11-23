using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO.Gatin.Lib.LogAn;
using KTPO4317.Gatin.Service.Views;

namespace KTPO4317.Gatin.Service.WindsorInstallers;

public class ViewInstaller: IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<IView>().ImplementedBy<ConsoleView>().LifestyleTransient());
    }
}