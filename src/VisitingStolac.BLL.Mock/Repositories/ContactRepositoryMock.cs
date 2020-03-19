using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL;

namespace VisitingStolac.BLL.Mock.Repositories
{
    /// <summary>
    /// mock repository for contact
    /// </summary>
    public class ContactRepositoryMock : IContactRepository
    {
        /// <summary>
        /// private subscriber list for mocking data
        /// </summary>
        private IList<Contact> _contacts = new List<Contact>()
        {
            new Contact{Id = 1, Email = "armin.lizde@outlook.com", IsActive = true, Name = "Armin Lizde", PhoneNumber = "000000000000", Type = ContactType.Bar},
            new Contact{Id = 2, Email = "alen.prema@outlook.com", IsActive = true, Name = "Alen Prema", PhoneNumber = "000000000001", Type = ContactType.Bar},
            new Contact{Id = 3, Email = "edvin.burina@outlook.com", IsActive = true, Name = "Eda Burina", PhoneNumber = "000000000002", Type = ContactType.Bar},
            new Contact{Id = 4, Email = "cuna.ajanic@outlook.com", IsActive = true, Name = "Arman Ajanic", PhoneNumber = "000000000003", Type = ContactType.Restaurant},
            new Contact{Id = 5, Email = "hara.zujo@outlook.com", IsActive = true, Name = "Hara Zujo", PhoneNumber = "000000000004", Type = ContactType.Restaurant},
            new Contact{Id = 6, Email = "besir.isa@outlook.com", IsActive = true, Name = "Besir Isakovic", PhoneNumber = "000000000005", Type = ContactType.Restaurant},
        };

        /// <summary>
        /// mocks creation of contact
        /// </summary>
        /// <param name="createDto">instance of <see cref="ContactCreateDto"/></param>
        /// <returns>new id</returns>
        public async Task<int> CreateAsync(ContactCreateDto createDto)
        {
            foreach (var item in _contacts)
            {
                if (createDto.Email == item.Email)
                    throw new KeyAlreadyExistsException($"Email: {createDto.Email} is already subscribed!");
            }

            Contact contact = new Contact
            {
                Id = 7,
                IsActive = true,
                Email = createDto.Email,
                Name = createDto.Name,
                PhoneNumber = createDto.PhoneNumber,
                Type = createDto.Type
            };

            _contacts.Add(contact);

            return await Task.Run(() => { return contact.Id; });
        }

        /// <summary>
        /// mocks deleting of contact
        /// </summary>
        /// <param name="id">id</param>
        public async Task DeleteByIdAsync(int id)
        {
            Contact contact = await Task.Run(() => { return _contacts.Where(s => s.Id == id).First(); });

            if (contact == null)
                throw new KeyNotFoundException($"Contact with id: {id} could not be found!");

            _contacts.Remove(contact);
        }

        /// <summary>
        /// mocks getting all contacts
        /// </summary>
        /// <returns>instance of <see cref="IEnumerable{ContactDto}"/></returns>
        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _contacts.Select(s => new ContactDto()
                {
                    Id = s.Id,
                    Email = s.Email,
                    IsActive = s.IsActive,
                    Type = s.Type,
                    PhoneNumber = s.PhoneNumber,
                    Name = s.Name
                });
            });
        }

        /// <summary>
        /// mocks getting contact by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        public async Task<ContactDto> GetByIdAsync(int id)
        {
            Contact contact = await Task.Run(() => { return _contacts.Where(s => s.Id == id).First(); });

            if (contact == null)
                throw new KeyNotFoundException($"Contact with id: {id} could not be found!");

            return new ContactDto
            {
                Id = contact.Id,
                Email = contact.Email,
                IsActive = contact.IsActive,
                Type = contact.Type,
                PhoneNumber = contact.PhoneNumber,
                Name = contact.Name
            };
        }

        /// <summary>
        /// mocks update contact
        /// </summary>
        /// <param name="updateDto">instance of <see cref="ContactUpdateDto"/></param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        public async Task<ContactDto> UpdateAsync(ContactUpdateDto updateDto)
        {
            foreach (var item in _contacts)
            {
                if (item.Id == updateDto.Id)
                {
                    item.IsActive = updateDto.IsActive;
                    item.Name = updateDto.Name;
                    item.Id = updateDto.Id;
                    item.PhoneNumber = updateDto.PhoneNumber;
                    item.Type = updateDto.Type;

                    return await Task.Run(() =>
                    {
                        return new ContactDto
                        {
                            Id = item.Id,
                            Email = item.Email,
                            IsActive = item.IsActive,
                            Type = item.Type,
                            PhoneNumber = item.PhoneNumber,
                            Name = item.Name
                        };
                    });
                }
            }

            throw new KeyNotFoundException($"Contact with id: {updateDto.Id} could not be found!");
        }
    }
}
