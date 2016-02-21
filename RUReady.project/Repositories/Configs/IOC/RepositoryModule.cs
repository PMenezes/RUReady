using Ninject.Modules;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace Repositories.Configs.IOC
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            //Unit Of Work and DbContext wrapper
            Bind<IContext>().To<InternalDbContext<RuReadyContext>>();
            
            Bind<IDareRepository>().To<DareRepository>();
            Bind<IResponseRepository>().To<ResponseRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            
        }
    }
}
