using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.Common;

namespace VisitingStolac.API.Controllers
{
    /// <summary> administrator controller </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        /// <summary> private instance of <see cref="IUnitOfWork"/></summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="uow">instance of <see cref="IUnitOfWork"/></param>
        public AdministratorController(IUnitOfWork uow) => _uow = uow;

        /// <summary> Gets all Administrators </summary>
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<AdministratorDto> administrators = await _uow.Administrators.GetAllAsync();
            return Ok(administrators);
        }
    }
}
