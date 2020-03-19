using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Repositories
{
    /// <summary>
    /// implementation of contribution repository
    /// </summary>
    public class ContributionRepository : IContributionRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">instance of <see cref="VisitingStolacDbContext"/></param>
        public ContributionRepository(VisitingStolacDbContext context) => _context = context;

        /// <summary>
        /// Gets all contributions "/>
        /// </summary>
        /// <returns><see cref="IEnumerable{ContactDto}</returns>
        public async Task<IEnumerable<ContributionDto>> GetAllAsync()
        {
            IEnumerable<ContributionDto> contributions = await _context.Contributions.Select(c => new ContributionDto {
                Id = c.Id
            }).ToListAsync();

            return contributions;
        }
    }
}
