using System.Collections.Generic;
using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary>
    /// ipost repository
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// gets all posts async
        /// </summary>
        /// <param name="pagingParameters">instance of <see cref="PostPagingParametersDto"</param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        Task<IEnumerable<PostDto>> GetAllAsync(PostPagingParametersDto pagingParameters);

        /// <summary>
        /// Gets 3 latests posts filtered by <see cref="Locale"/>
        /// </summary>
        /// <param name="locale">language enumeration</param>
        /// <returns>instance of <see cref="IEnumerable{PostDto}"/></returns>
        Task<IEnumerable<PostDto>> GetLatestAsync(Locale locale);

        /// <summary>
        /// Creates post async
        /// </summary>
        /// <param name="createDto">instance of <see cref="PostCreateDto"/></param>
        /// <returns></returns>
        Task<int> CreateAsync(PostCreateDto createDto);

        /// <summary>
        /// gets post by id
        /// </summary>
        /// <param name="id">post id</param>
        /// <param name="locale">language enumeration</param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        Task<PostDto> GetByIdAsync(int id, Locale locale);

        /// <summary>
        /// updates post
        /// </summary>
        /// <param name="updateDto">instance of <see cref="PostUpdateDto"/></param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        Task<PostDto> UpdateAsync(PostUpdateDto updateDto);

        /// <summary>
        /// deletes post by id async
        /// </summary>
        /// <param name="id">post id</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// adds translation to post
        /// </summary>
        /// <param name="postAddDto">instance of <see cref="PostAddTranslationDto"/></param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        Task<PostDto> AddTranslationAsync(PostAddTranslationDto postAddDto);

        /// <summary>
        /// updates translation async
        /// </summary>
        /// <param name="postTranslationDto">instance of <see cref="PostTranslationUpdateDto"/></param>
        /// <returns>instance of <see cref="PostDto"/></returns>
        Task<PostDto> UpdateTranslationAsync(PostTranslationUpdateDto postTranslationDto);
    }
}
