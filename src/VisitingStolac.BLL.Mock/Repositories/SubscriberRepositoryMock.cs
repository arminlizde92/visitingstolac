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
    /// Mock subscriber repository
    /// </summary>
    public class SubscriberRepositoryMock : ISubscriberRepository
    {
        /// <summary>
        /// private subscriber list for mocking data
        /// </summary>
        private IList<Subscriber> _subscribers = new List<Subscriber>()
        {
            new Subscriber{Id = 1, Created = DateTime.Now, Email = "armin.lizde@outlook.com", IsActive = true, IsSubscribedOnNews = true, IsSubscribedOnPosts = true},
            new Subscriber{Id = 2, Created = DateTime.Now, Email = "alen.prema@outlook.com", IsActive = true, IsSubscribedOnNews = false, IsSubscribedOnPosts = true},
            new Subscriber{Id = 3, Created = DateTime.Now, Email = "hara.zujo@outlook.com", IsActive = true, IsSubscribedOnNews = true, IsSubscribedOnPosts = false},
            new Subscriber{Id = 4, Created = DateTime.Now, Email = "arman.ajanic@outlook.com", IsActive = false, IsSubscribedOnNews = true, IsSubscribedOnPosts = true},
            new Subscriber{Id = 5, Created = DateTime.Now, Email = "besir.isakovic@outlook.com", IsActive = false, IsSubscribedOnNews = false, IsSubscribedOnPosts = true},
            new Subscriber{Id = 6, Created = DateTime.Now, Email = "eda.burina@outlook.com", IsActive = false, IsSubscribedOnNews = true, IsSubscribedOnPosts = false},
        };

        /// <summary>
        /// mocks creation of subscriber
        /// </summary>
        /// <param name="createDto">instance of <see cref="SubscriberCreateDto"/></param>
        /// <returns>new subscribers dto</returns>
        public async Task<int> CreateAsync(SubscriberCreateDto createDto)
        {
            foreach (var item in _subscribers)
            {
                if (createDto.Email == item.Email)
                    throw new KeyAlreadyExistsException($"Email: {createDto.Email} is already subscribed!");
            }

            Subscriber subscriber = new Subscriber
            {
                Id = 7,
                IsActive = true,
                Created = DateTime.Now,
                IsSubscribedOnNews = true,
                IsSubscribedOnPosts = true,
                Email = createDto.Email
            };

            _subscribers.Add(subscriber);

            return await Task.Run(() => { return subscriber.Id; });
        }

        /// <summary>
        /// mocks deleting of a subscriber
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(int id)
        {
            Subscriber subscriber = await Task.Run(() => { return _subscribers.Where(s => s.Id == id).First(); });

            if (subscriber == null)
                throw new KeyNotFoundException($"Subscriber with id: {id} could not be found!");

            _subscribers.Remove(subscriber);
        }

        /// <summary>
        /// mocks getting all subscribers
        /// </summary>
        public async Task<IEnumerable<SubscriberDto>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _subscribers.Select(s => new SubscriberDto()
                {
                    Id = s.Id,
                    IsSubscribedOnPosts = s.IsSubscribedOnPosts,
                    IsSubscribedOnNews = s.IsSubscribedOnNews,
                    Created = s.Created,
                    Email = s.Email,
                    IsActive = s.IsActive
                });
            });
        }

        /// <summary>
        /// mocks getting subscriber by id
        /// </summary>
        /// <param name="id">subscriber id</param>
        /// <returns>instance of <see cref="SubscriberDto"/></returns>
        public async Task<SubscriberDto> GetByIdAsync(int id)
        {
            Subscriber subscriber = await Task.Run(() => { return _subscribers.Where(s => s.Id == id).First(); });

            if (subscriber == null)
                throw new KeyNotFoundException($"Subscriber with id: {id} could not be found!");

            return new SubscriberDto
            {
                Id = subscriber.Id,
                Created = subscriber.Created,
                Email = subscriber.Email,
                IsActive = subscriber.IsActive,
                IsSubscribedOnNews = subscriber.IsSubscribedOnNews,
                IsSubscribedOnPosts = subscriber.IsSubscribedOnPosts
            };
        }

        /// <summary>
        /// mocks updating subscriber
        /// </summary>
        /// <param name="updateDto">instance of <see cref="SubscriberUpdateDto"/></param>
        /// <returns></returns>
        public async Task<SubscriberDto> UpdateAsync(SubscriberUpdateDto updateDto)
        {
            foreach (var item in _subscribers)
            {
                if (item.Id == updateDto.Id)
                {
                    item.IsActive = updateDto.IsActive;
                    item.IsSubscribedOnNews = updateDto.IsSubscribedOnNews;
                    item.IsSubscribedOnPosts = updateDto.IsSubscribedOnPosts;

                    return await Task.Run(() =>
                    {
                        return new SubscriberDto
                        {
                            Id = item.Id,
                            IsSubscribedOnPosts = item.IsSubscribedOnPosts,
                            IsSubscribedOnNews = item.IsSubscribedOnNews,
                            Created = item.Created,
                            Email = item.Email,
                            IsActive = item.IsActive
                        };
                    });
                }
            }

            throw new KeyNotFoundException($"Subscriber with id: {updateDto.Id} could not be found!");
        }
    }
}
