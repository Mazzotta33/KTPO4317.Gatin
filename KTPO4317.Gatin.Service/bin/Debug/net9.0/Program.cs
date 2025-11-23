using KTPO.Gatin.Lib.Common;
using KTPO.Gatin.Lib.LogAn;
using KTPO.Gatin.Lib.SampleCommands;
using KTPO4317.Gatin.Service.WindsorInstallers;




class Program
{
    static void Main()
    {
        CastleFactory.container.Install(new SampleCommandInstaller(), new ViewInstaller());
        for (int i = 0; i < 3; i++)
        {
            ISampleCommand someCommand = CastleFactory.container.Resolve<ISampleCommand>();
            someCommand.Execute();
        }
    }
}