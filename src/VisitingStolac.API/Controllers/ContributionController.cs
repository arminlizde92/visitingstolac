using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.Common;

namespace VisitingStolac.API.Controllers
{
    /// <summary> contribution controller </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionController : ControllerBase
    {
        /// <summary> private instance of <see cref="IUnitOfWork"/></summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="uow">instance of <see cref="IUnitOfWork"/></param>
        public ContributionController(IUnitOfWork uow) => _uow = uow;

        /// <summary> Gets all contribution </summary>
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ContributionDto> contributions = await _uow.Contributions.GetAllAsync();
            return Ok(contributions);
        }
    }
}
