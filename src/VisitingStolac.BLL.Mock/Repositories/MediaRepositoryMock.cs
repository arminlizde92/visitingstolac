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
    /// mock media repository
    /// </summary>
    public class MediaRepositoryMock : IMediaRepository
    {
        /// <summary>
        /// mock media data
        /// </summary>
        private IList<Media> _medias = new List<Media>()
        {
            new Media {Id = 1, GroupId = 1, Url = "www.google.com", Source = "internet", Type = MediaType.Icon},
            new Media {Id = 2, GroupId = 1, Url = "www.google1.com", Source = "internet2", Type = MediaType.Image},
            new Media {Id = 3, GroupId = 2, Url = "www.google2.com", Source = "internet3", Type = MediaType.Icon},
            new Media {Id = 4, GroupId = 2, Url = "www.google3.com", Source = "internet4", Type = MediaType.Video},
            new Media {Id = 5, GroupId = 2, Url = "www.google4.com", Source = "internet5", Type = MediaType.Video}
        };

        /// <summary>
        /// mocks media group data
        /// </summary>
        private IList<MediaGroup> _groups = new List<MediaGroup>()
        {
            new MediaGroup {Id = 1, Type = MediaGroupType.Banner},
            new MediaGroup {Id = 2, Type = MediaGroupType.Post}
        };

        /// <summary>
        /// mocks creating media 
        /// </summary>
        /// <param name="createDto">instance of <see cref="MediaCreateDto"/></param>
        /// <returns>new media id</returns>
        public async Task<int> CreateAsync(MediaCreateDto createDto)
        {
            Media media = new Media
            {
                Id = 6,
                Url = createDto.Url,
                Type = createDto.Type,
                Source = createDto.Source
            };

            _medias.Add(media);

            return await Task.Run(() => { return media.Id; });
        }

        /// <summary>
        /// mocks deleting media
        /// </summary>
        /// <param name="id">mocked media id</param>
        public async Task DeleteByIdAsync(int id)
        {
            Media media = await Task.Run(() => { return _medias.Where(m => m.Id == id).First(); });

            if (media == null)
                throw new KeyNotFoundException($"Media with: {id} could not be found!");

            _medias.Remove(media);
        }

        /// <summary>
        /// mocks deleting media group
        /// </summary>
        /// <param name="id">mock group id</param>
        public async Task DeleteGroupByIdAsync(int id)
        {
            MediaGroup group = await Task.Run(() => { return _groups.Where(g => g.Id == id).First(); });

            if (group == null)
                throw new KeyNotFoundException($"MediaGroup with: {id} could not be found!");

            _groups.Remove(group);
        }

        /// <summary>
        /// mocks the GetAllAsync method
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MediaDto>> GetAllAsync()
        {
            return await Task.Run(() => {
                return _medias.Select(m => new MediaDto()
                {
                    Url = m.Url,
                    Id = m.Id,
                    GroupId = m.GroupId,
                    Type = m.Type.ToString(),
                    Source = m.Source
                });
            });
        }

        /// <summary>
        /// mocks getting all media by group id
        /// </summary>
        /// <param name="groupId">mock group id</param>
        /// <returns>instance of <see cref="IEnumerable{MediaDto}"/></returns>
        public async Task<IEnumerable<MediaDto>> GetAllByGroupIdAsync(int groupId)
        {
            return await Task.Run(() => {
                return _medias.Where(g => g.GroupId == groupId).Select(m => new MediaDto()
                {
                    Url = m.Url,
                    Id = m.Id,
                    GroupId = m.GroupId,
                    Type = m.Type.ToString(),
                    Source = m.Source
                });
            });
        }

        /// <summary>
        /// gets all media group types
        /// </summary>
        /// <returns>instance of <see cref="IEnumerable{MediaGroupTypeDto}"/></returns>
        public Task<IEnumerable<MediaGroupTypeDto>> GetAllMediaGroupTypesAsync()
        {
            IEnumerable<MediaGroupType> values = Enum.GetValues(typeof(MediaGroupType)).Cast<MediaGroupType>();

            return Task.FromResult(values.Select(e => new MediaGroupTypeDto
            {
                Id = (int)e,
                Name = e.ToString()
            }));
        }

        /// <summary>
        /// mocks getting media by id
        /// </summary>
        /// <param name="id">mock media id</param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        public async Task<MediaDto> GetByIdAsync(int id)
        {
            Media media = await Task.Run(() => { return _medias.Where(m => m.Id == id).First(); });

            if (media == null)
                throw new KeyNotFoundException($"Media with id: {id} could not be found!");

            return new MediaDto
            {
                Id = media.Id,
                Url = media.Url,
                Type = media.Type.ToString(),
                Source = media.Source
            };
        }

        /// <summary>
        /// mocks updating media
        /// </summary>
        /// <param name="updateDto">instance of <see cref="MediaUpdateDto"/></param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        public async Task<MediaDto> UpdateAsync(MediaUpdateDto updateDto)
        {
            Media media = await Task.Run(() => { return _medias.Where(m => m.Id == updateDto.Id).First(); });
            media.Source = updateDto.Source;

            return new MediaDto
            {
                Id = media.Id,
                GroupId = media.GroupId,
                Source = media.Source,
                Type = media.Type.ToString(),
                Url = media.Url
            };
        }
    }
}
