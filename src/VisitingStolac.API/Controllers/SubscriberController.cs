using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.Common;

namespace VisitingStolac.API.Controllers
{
    /// <summary> subscriber controller </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController : ControllerBase
    {
        /// <summary> private instance of <see cref="IUnitOfWork"/></summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="uow">instance of <see cref="IUnitOfWork"/></param>
        public SubscriberController(IUnitOfWork uow) => _uow = uow;

        /// <summary> gets all values </summary>
        /// <returns><see cref="IEnumerable{SubscriberDto}"/></returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            // TODO: Pagination in the future ? -> discuss
            IEnumerable<SubscriberDto> subscribers = await _uow.Subscribers.GetAllAsync();
            return Ok(subscribers);
        }

        /// <summary>
        /// gets subscriber by id
        /// </summary>
        /// <param name="id">subscriber id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SubscriberDto subscriberDto = await _uow.Subscribers.GetByIdAsync(id);
            return Ok(subscriberDto);
        }

        /// <summary>
        /// creates subscribers
        /// </summary>
        /// <param name="createDto">instance of <see cref="SubscriberCreateDto"/></param>
        /// <returns>id if subscriber created</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SubscriberCreateDto createDto)
        {
            int id = await _uow.Subscribers.CreateAsync(createDto);
            _uow.Commit();

            return Ok(id);
        }

        /// <summary>
        /// updates subscriber
        /// </summary>
        /// <param name="updateDto">instance of <see cref="SubscriberUpdateDto"/></param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SubscriberUpdateDto updateDto)
        {
            SubscriberDto subscriberDto = await _uow.Subscribers.UpdateAsync(updateDto);
            _uow.Commit();

            return Ok(subscriberDto);
        }

        /// <summary>
        /// deletes subscriber by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>200</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _uow.Subscribers.DeleteByIdAsync(id);
            _uow.Commit();

            return Ok();
        }
    }
}
