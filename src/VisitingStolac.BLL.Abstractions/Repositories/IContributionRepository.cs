using System.Collections.Generic;
using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary> interface IContributionRepository </summary>
    public interface IContributionRepository
    {
        /// <summary> Gets all medias async </summary>
        Task<IEnumerable<ContributionDto>> GetAllAsync();
    }
}
