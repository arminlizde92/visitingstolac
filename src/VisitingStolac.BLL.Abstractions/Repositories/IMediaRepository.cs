using System.Collections.Generic;
using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary> interface IMediaRepository </summary>
    public interface IMediaRepository
    {
        /// <summary> Gets all medias async </summary>
        Task<IEnumerable<MediaDto>> GetAllAsync();

        /// <summary>
        /// gets all medias by group id
        /// </summary>
        /// <param name="groupId">group id</param>
        /// <returns>instance of <see cref="IEnumerable{MediaDto}"/></returns>
        Task<IEnumerable<MediaDto>> GetAllByGroupIdAsync(int groupId);

        /// <summary>
        /// gets all media group types
        /// </summary>
        /// <returns>instance of <see cref="IEnumerable{MediaGroupTypeDto}"/></returns>
        Task<IEnumerable<MediaGroupTypeDto>> GetAllMediaGroupTypesAsync();

        /// <summary>
        /// creates media 
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns>id of created media group</returns>
        Task<int> CreateAsync(MediaCreateDto createDto);

        /// <summary>
        /// gets media by id
        /// </summary>
        /// <param name="id">media id</param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        Task<MediaDto> GetByIdAsync(int id);

        /// <summary>
        /// updates media by id
        /// </summary>
        /// <param name="id">media id</param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        Task<MediaDto> UpdateAsync(MediaUpdateDto updateDto);

        /// <summary>
        /// deletes media by id
        /// </summary>
        Task DeleteByIdAsync(int id);

        /// <summary>
        /// deletes media group by id
        /// </summary>
        Task DeleteGroupByIdAsync(int id);
    }
}
