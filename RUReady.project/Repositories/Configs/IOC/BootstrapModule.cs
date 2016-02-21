using Ninject.Modules;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace Repositories.Configs.IOC
{
    public class BootstrapModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGateway>().To<Gateway>();
            Bind<IRepositories>().To<RepositoriesImpl>();
        }
    }
}
