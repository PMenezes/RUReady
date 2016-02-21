using Ninject.Modules;
using Repositories.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configs.IOC
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEntityValidation>().To<EntityValidation>();
        }
    }
}
