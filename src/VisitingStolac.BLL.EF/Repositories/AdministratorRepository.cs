using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Repositories
{
    /// <summary> implementation of media repository </summary>
    public class AdministratorRepository : IAdministratorRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">instance of <see cref="VisitingStolacDbContext"/></param>
        public AdministratorRepository(VisitingStolacDbContext context) => _context = context;

        /// <summary>
        /// Gets all administrators "/>
        /// </summary>
        /// <returns><see cref="IEnumerable{AdministratorDto}</returns>
        public async Task<IEnumerable<AdministratorDto>> GetAllAsync()
        {
            IEnumerable<AdministratorDto> administrators = await _context.Administrators.Select(a => new AdministratorDto {
                Email = a.Email,
                Id = a.Id
            }).ToListAsync();

            return administrators;
        }
    }
}
