using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.Common;
using VisitingStolac.DAL;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.BLL.EF.Repositories
{
    /// <summary>
    /// implementation of contact repository
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">instance of <see cref="VisitingStolacDbContext"/></param>
        public ContactRepository(VisitingStolacDbContext context) => _context = context;

        /// <summary>
        /// Gets all contacts "/>
        /// </summary>
        /// <returns><see cref="IEnumerable{ContactDto}</returns>
        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            IEnumerable<ContactDto> contacts = await _context.Contacts.Select(c => ContactToContactDto(c)).ToListAsync();
            return contacts;
        }

        /// <summary>
        /// gets contact by id async
        /// </summary>
        /// <param name="id">contact id</param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        public async Task<ContactDto> GetByIdAsync(int id)
        {
            Contact contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new KeyNotFoundException($"Contact with id: {id} could not be found!");

            ContactDto contactDto = ContactToContactDto(contact);            
            return contactDto;
        }

        /// <summary>
        /// creates contact
        /// </summary>
        /// <param name="createDto">instance of <see cref="ContactCreateDto"/></param>
        /// <returns>newly created contact id</returns>
        public async Task<int> CreateAsync(ContactCreateDto createDto)
        {
            if (_context.Contacts.Where(s => s.Email == createDto.Email).FirstOrDefault() != null)
                throw new KeyAlreadyExistsException($"Contact: {createDto.Email} already exists!");

            Contact contact = new Contact {
                Email = createDto.Email,
                Type = createDto.Type,
                PhoneNumber = createDto.PhoneNumber,
                Name = createDto.Name,
                IsActive = true
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact.Id;
        }

        /// <summary>
        /// updates contact
        /// </summary>
        /// <param name="updateDto">instance of <see cref="ContactUpdateDto"/></param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        public async Task<ContactDto> UpdateAsync(ContactUpdateDto updateDto)
        {
            Contact contact = await _context.Contacts.FindAsync(updateDto.Id);

            if (contact == null)
                throw new KeyNotFoundException($"Contact with id: {updateDto.Id} could not be found!");

            contact.IsActive = updateDto.IsActive;
            contact.Name = updateDto.Name;
            contact.PhoneNumber = updateDto.PhoneNumber;
            contact.Type = updateDto.Type;

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            ContactDto contactDto = ContactToContactDto(contact);
            return contactDto;
        }

        /// <summary>
        /// deletes contact by id
        /// </summary>
        /// <param name="id">contact id</param>
        public async Task DeleteByIdAsync(int id)
        {
            Contact contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new KeyNotFoundException($"Contact with id: {id} could not be found!");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// private method for converting converting Contact to contact dto
        /// </summary>
        /// <param name="c">instance of <see cref="Contact"/></param>
        /// <returns>instance of <see cref="ContactDto"/></returns>
        private ContactDto ContactToContactDto(Contact c)
        {
            return new ContactDto
            {
                Id = c.Id,
                Email = c.Email,
                IsActive = c.IsActive,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Type = c.Type
            };
        }
    }
}
