using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.Common;

namespace VisitingStolac.API.Controllers
{
    /// <summary> Media controller </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        /// <summary> private instance of <see cref="IUnitOfWork"/></summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="uow">instance of <see cref="IUnitOfWork"/></param>
        public MediaController(IUnitOfWork uow) => _uow = uow;

        /// <summary> Gets all medias </summary>
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<MediaDto> medias = await _uow.Medias.GetAllAsync();
            return Ok(medias);
        }

        /// <summary>
        /// creates media
        /// </summary>
        /// <param name="createDto">instance of <see cref="MediaCreateDto"/></param>
        /// <returns>new media id</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] MediaCreateDto createDto)
        {
            int id = await _uow.Medias.CreateAsync(createDto);
            _uow.Commit();

            return Ok(id);
        }

        /// <summary>
        /// deletes media by id
        /// </summary>
        /// <param name="id">media id</param>
        /// <returns>200</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _uow.Medias.DeleteByIdAsync(id);
            _uow.Commit();

            return Ok();
        }

        /// <summary>
        /// gets media group types
        /// </summary>
        /// <returns>instance of <see cref="IEnumerable{MediaGroupTypeDto}"/></returns>
        [HttpGet("GroupTypes")]
        public async Task<IActionResult> GetMediaGroupTypes()
        {
            IEnumerable<MediaGroupTypeDto> groupTypeDtos = await _uow.Medias.GetAllMediaGroupTypesAsync();
            return Ok(groupTypeDtos);
        }

        /// <summary>
        /// gets media by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>instnace of <see cref="MediaDto"/></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            MediaDto mediaDto = await _uow.Medias.GetByIdAsync(id);
            return Ok(mediaDto);
        }

        /// <summary>
        /// updates media
        /// </summary>
        /// <param name="updateDto">update dto</param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] MediaUpdateDto updateDto)
        {
            MediaDto mediaDto = await _uow.Medias.UpdateAsync(updateDto);
            _uow.Commit();

            return Ok(mediaDto);
        }
    }
}
