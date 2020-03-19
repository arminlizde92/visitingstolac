using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.Common;

namespace VisitingStolac.API.Controllers
{
    /// <summary> post controller </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        /// <summary> private instance of <see cref="IUnitOfWork"/></summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="uow">instance of <see cref="IUnitOfWork"/></param>
        public PostController(IUnitOfWork uow) => _uow = uow;

        /// <summary>
        /// gets post by id and by language
        /// </summary>
        /// <param name="id">post id</param>
        /// <param name="locale">post language</param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        [HttpGet("{id}/{locale}")]
        public async Task<IActionResult> Get(int id, Locale locale)
        {
            PostDto postDto = await _uow.Posts.GetByIdAsync(id, locale);
            return Ok(postDto);
        }

        /// <summary>
        /// Gets all posts ordered by creation date
        /// </summary>
        /// <param name="pageSize">size of the page should be bigger than 0</param>
        /// <param name="pageNumber">page number - starts at 1</param>
        /// <param name="locale">language <see cref="Locale"/></param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        [HttpGet("All/{pageSize}/{pageNumber}/{locale}")]
        public async Task<IActionResult> GetAll(int pageSize, int pageNumber, Locale locale)
        {
            IEnumerable<PostDto> posts = await _uow.Posts.GetAllAsync(new PostPagingParametersDto() {
                Locale = locale,
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            return Ok(posts);
        }

        /// <summary>
        /// Gets the 3 latests posts 
        /// </summary>
        /// <param name="locale">language <see cref="Locale"/></param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"</returns>
        [HttpGet("Latest/{locale}")]
        public async Task<IActionResult> GetLatest(Locale locale)
        {
            IEnumerable<PostDto> posts = await _uow.Posts.GetLatestAsync(locale);
            return Ok(posts);
        }
    }
}
