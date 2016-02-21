using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Root Domain Object
    /// To access the domain model methods it is needed to call one of this properties
    /// The domain model is separated in three fields, Services, Factories and Repositories
    /// </summary>
    public interface IGateway
    {
        IRepositories Repositories { get; }
    }

    /// <summary>
    /// WareBlocks Repositories
    /// They give access to CRUD operations on the entities
    /// </summary>
    public interface IRepositories
    {
        ICategoryRepository Category { get; }

        IDareRepository Dare { get; }

        IUserRepository User { get; }

        IResponseRepository Response { get; }
    }

}
