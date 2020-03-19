using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.Common;

namespace VisitingStolac.API.Controllers
{
    /// <summary> contact controller </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        /// <summary> private instance of <see cref="IUnitOfWork"/></summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="uow">instance of <see cref="IUnitOfWork"/></param>
        public ContactController(IUnitOfWork uow) => _uow = uow;

        /// <summary> Gets all contacts </summary>
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            // TODO: Pagination in the future ?
            IEnumerable<ContactDto> contacts = await _uow.Contacts.GetAllAsync();
            return Ok(contacts);
        }

        /// <summary>
        /// gets contact by id
        /// </summary>
        /// <param name="id">contact id</param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ContactDto contactDto = await _uow.Contacts.GetByIdAsync(id);
            return Ok(contactDto);
        }

        /// <summary>
        /// creates contact
        /// </summary>
        /// <param name="createDto">instance of <see cref="ContactCreateDto"/></param>
        /// <returns>id if contact created</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ContactCreateDto createDto)
        {
            int id = await _uow.Contacts.CreateAsync(createDto);
            _uow.Commit();

            return Ok(id);
        }

        /// <summary>
        /// updates contact
        /// </summary>
        /// <param name="updateDto">instance of <see cref="ContactUpdateDto"/></param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ContactUpdateDto updateDto)
        {
            ContactDto contactDto = await _uow.Contacts.UpdateAsync(updateDto);
            _uow.Commit();

            return Ok(contactDto);
        }

        /// <summary>
        /// deletes contact by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>200</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _uow.Contacts.DeleteByIdAsync(id);
            _uow.Commit();

            return Ok();
        }
    }
}
