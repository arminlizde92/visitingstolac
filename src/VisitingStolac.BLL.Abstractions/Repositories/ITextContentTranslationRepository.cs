using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary>
    /// interface for text content translation repository
    /// </summary>
    public interface ITextContentTranslationRepository
    {
        /// <summary>
        /// creates translation async
        /// </summary>
        /// <param name="createDto">instance of <see cref="TextContentTranslationCreateDto"/></param>
        /// <returns>newly created translations id</returns>
        Task<int> CreateAsync(TextContentTranslationCreateDto createDto);

        /// <summary>
        /// adds additional translation 
        /// </summary>
        /// <param name="createDto">instance of <see cref="TextContentTranslationCreateDto"/></param>
        /// <returns>newly created  translations id</returns>
        Task<int> AddAsync(TextContentTranslationAddDto createDto);

        /// <summary>
        /// updates translation
        /// </summary>
        /// <param name="updateDto">instance of <see cref="TextContentTranslationUpdateDto"/></param>
        /// <returns>instance of <see cref="TextContentTranslationDto"/></returns>
        Task<TextContentTranslationDto> UpdateAsync(TextContentTranslationUpdateDto updateDto);

        /// <summary>
        /// deletes translation by id
        /// </summary>
        /// <param name="id">translation id</param>
        Task DeleteByIdAsync(int id);
    }
}
