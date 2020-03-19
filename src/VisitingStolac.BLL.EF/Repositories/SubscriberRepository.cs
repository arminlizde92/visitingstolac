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
    /// implementation of subscriber repository
    /// </summary>
    public class SubscriberRepository : ISubscriberRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">instance of <see cref="VisitingStolacDbContext"/></param>
        public SubscriberRepository(VisitingStolacDbContext context) => _context = context;

        /// <summary>
        /// Gets all Subscribers "/>
        /// </summary>
        /// <returns><see cref="IEnumerable{AdministratorDto}</returns>
        public async Task<IEnumerable<SubscriberDto>> GetAllAsync()
        {
            IEnumerable<SubscriberDto> subscribers = await _context.Subscribers.Select(s => SubscriberToSubscriberDto(s)).ToListAsync();
            return subscribers;
        }

        /// <summary>
        /// gets subscriber by id
        /// </summary>
        /// <param name="id">subscriber id</param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        public async Task<SubscriberDto> GetByIdAsync(int id)
        {
            Subscriber subscriber = await _context.Subscribers.FindAsync(id);

            if(subscriber == null)
                throw new KeyNotFoundException($"Subscriber with id: {id} could not be found!");

            SubscriberDto subscriberDto = SubscriberToSubscriberDto(subscriber);

            return subscriberDto;
        }

        /// <summary>
        /// creates subscriber
        /// </summary>
        /// <param name="createDto">instance of <see cref="SubscriberCreateDto"/></param>
        /// <returns>id</returns>
        public async Task<int> CreateAsync(SubscriberCreateDto createDto)
        {
            if (_context.Subscribers.Where(s => s.Email == createDto.Email).FirstOrDefault() != null)
                throw new KeyAlreadyExistsException($"Email: {createDto.Email} is already subscribed!");

            Subscriber subscriber = new Subscriber {
                Email = createDto.Email
            };

            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();

            return subscriber.Id;
        }

        /// <summary>
        /// updates subscriber by id
        /// </summary>
        /// <param name="id">subcriber id</param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        public async Task<SubscriberDto> UpdateAsync(SubscriberUpdateDto updateDto)
        {
            Subscriber subscriber = await _context.Subscribers.FindAsync(updateDto.Id);

            if (subscriber == null)
                throw new KeyNotFoundException($"Subscriber with id: {updateDto.Id} could not be found!");

            subscriber.IsActive = updateDto.IsActive;
            subscriber.IsSubscribedOnNews = updateDto.IsSubscribedOnNews;
            subscriber.IsSubscribedOnPosts = updateDto.IsSubscribedOnPosts;

            _context.Subscribers.Update(subscriber);
            await _context.SaveChangesAsync();

            SubscriberDto subscriberDto = SubscriberToSubscriberDto(subscriber);
            return subscriberDto;
        }

        /// <summary>
        /// deletes subscriber by id
        /// </summary>
        /// <param name="id">id</param>
        public async Task DeleteByIdAsync(int id)
        {
            Subscriber subscriber = await _context.Subscribers.FindAsync(id);

            if (subscriber == null)
                throw new KeyNotFoundException($"Subscriber with id: {id} could not be found!");

            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Converts Subscriber to subscriber dto
        /// </summary>
        /// <param name="s">instance of <see cref="Subscriber"/></param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        private SubscriberDto SubscriberToSubscriberDto(Subscriber s)
        {
            return new SubscriberDto
            {
                Id = s.Id,
                Created = s.Created,
                Email = s.Email,
                IsActive = s.IsActive,
                IsSubscribedOnNews = s.IsSubscribedOnNews,
                IsSubscribedOnPosts = s.IsSubscribedOnPosts
            };
        }
    }
}
