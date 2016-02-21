using Ninject;
using Repositories.Configs.IOC;
using Repositories.Interfaces;
using Services.Configs;

namespace Services.Core
{
    public partial class Service
    {
        private IGateway Gateway { get; set; }
        
        public Service()
        {
            MapperInitiator.InitializeMapper();
            Gateway = new StandardKernel(new BootstrapModule()).Get<IGateway>();
        }
    }
}
