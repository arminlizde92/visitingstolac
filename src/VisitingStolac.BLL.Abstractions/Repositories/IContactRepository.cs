using System.Collections.Generic;
using System.Threading.Tasks;
using VisitingStolac.Common;

namespace VisitingStolac.BLL.Abstractions.Repositories
{
    /// <summary> interface IContactRepository </summary>
    public interface IContactRepository
    {
        /// <summary> Gets all contacts async </summary>
        Task<IEnumerable<ContactDto>> GetAllAsync();

        /// <summary>
        /// creates contact
        /// </summary>
        /// <param name="createDto">instance of <see cref="ContactCreateDto"/></param>
        /// <returns></returns>
        Task<int> CreateAsync(ContactCreateDto createDto);

        /// <summary>
        /// gets contact by id
        /// </summary>
        /// <param name="id">subscriber id</param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        Task<ContactDto> GetByIdAsync(int id);

        /// <summary>
        /// updates contact by id
        /// </summary>
        /// <param name="id">contact id</param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        Task<ContactDto> UpdateAsync(ContactUpdateDto updateDto);

        /// <summary>
        /// deletes contact by id
        /// </summary>
        /// <param name="id"></param>
        Task DeleteByIdAsync(int id);
    }
}
