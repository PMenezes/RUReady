using Ninject;
using Repositories.Configs.IOC;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class Gateway : IGateway
    {
        private readonly StandardKernel _blocksKernel;

        public Gateway()
            : this(new StandardKernel(new BootstrapModule()))
        {
        }

        private Gateway(StandardKernel kernel)
        {
            _blocksKernel = kernel;
        }

        public IRepositories Repositories
        {
            get { return _blocksKernel.Get<IRepositories>(); }
        }
    }

    public class RepositoriesImpl : IRepositories
    {
        private readonly StandardKernel _repKernel;

        public RepositoriesImpl()
            : this(new StandardKernel(new RepositoryModule()))
        {
        }

        private RepositoriesImpl(StandardKernel kernel)
        {
            _repKernel = kernel;
        }

        public IDareRepository Dare
        {
            get { return _repKernel.Get<IDareRepository>(); }
        }

        public IResponseRepository Response
        {
            get { return _repKernel.Get<ResponseRepository>(); }
        }

        public IUserRepository User
        {
            get { return _repKernel.Get<IUserRepository>(); }
        }

        public ICategoryRepository Category
        {
            get { return _repKernel.Get<CategoryRepository>(); }
        }
    }
}
