using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO.Gatin.Lib.SampleCommands;

namespace KTPO4317.Gatin.Service.WindsorInstallers;

public class SampleCommandInstaller: IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifestyleSingleton(),
            Component.For<ISampleCommand>().ImplementedBy<IndependentDecorator>().LifestyleSingleton(),
            Component.For<ISampleCommand>().ImplementedBy<SecondCommand>().LifestyleSingleton()
        );
    }
}