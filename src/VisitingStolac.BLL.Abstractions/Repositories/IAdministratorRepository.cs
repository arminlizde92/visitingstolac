using System.Collections.Generic;
using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary> interface IAdministratorRepository </summary>
    public interface IAdministratorRepository
    {
        /// <summary> Gets all administrators async </summary>
        Task<IEnumerable<AdministratorDto>> GetAllAsync();
    }
}
