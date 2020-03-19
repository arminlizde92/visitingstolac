using System.Collections.Generic;
using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary>
    /// isubscriber interface
    /// </summary>
    public interface ISubscriberRepository
    {
        /// <summary> Gets all subscribers async </summary>
        Task<IEnumerable<SubscriberDto>> GetAllAsync();

        /// <summary>
        /// creates subscriber
        /// </summary>
        /// <param name="createDto">instance of <see cref="SubscriberCreateDto"/></param>
        /// <returns></returns>
        Task<int> CreateAsync(SubscriberCreateDto createDto);

        /// <summary>
        /// gets subscriber by id
        /// </summary>
        /// <param name="id">subscriber id</param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        Task<SubscriberDto> GetByIdAsync(int id);

        /// <summary>
        /// updates subscriber by id
        /// </summary>
        /// <param name="id">subcriber id</param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        Task<SubscriberDto> UpdateAsync(SubscriberUpdateDto updateDto);

        /// <summary>
        /// deletes subscriber by id
        /// </summary>
        /// <param name="id"></param>
        Task DeleteByIdAsync(int id);
    }
}
