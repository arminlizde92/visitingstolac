using System;
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
    /// <summary> implementation of media repository </summary>
    public class MediaRepository : IMediaRepository
    {
        /// <summary> private instance of <see cref="VisitingStolacDbContext"/> </summary>
        private VisitingStolacDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">instance of <see cref="VisitingStolacDbContext"/></param>
        public MediaRepository(VisitingStolacDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates media, if the first media, creates also media group
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns>media id</returns>
        public async Task<int> CreateAsync(MediaCreateDto createDto)
        {
            // TODO Armin -> maybe we should seperate create and add method ?
            if(createDto.GroupId == 0)
            {
                MediaGroup mediaGroup = new MediaGroup { Type = createDto.GroupType };
                await _context.MediaGroups.AddAsync(mediaGroup);
                await _context.SaveChangesAsync();

                createDto.GroupId = mediaGroup.Id;
            }

            Media media = new Media
            {
                Source = createDto.Source,
                Url = createDto.Url,
                Type = createDto.Type,
                GroupId = createDto.GroupId,
                PublicId = createDto.PublicId
            };

            await _context.Medias.AddAsync(media);
            await _context.SaveChangesAsync();

            return media.Id;
        }

        /// <summary>
        /// deletes media and if the group has only 1 media the group is also deleted
        /// </summary>
        /// <param name="id">media id</param>
        public async Task DeleteByIdAsync(int id)
        {
            Media media = await _context.Medias.FindAsync(id);

            if(media == null)
                throw new KeyNotFoundException($"Media with id: {id} could not be found!");

            _context.Medias.Remove(media);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes group by id
        /// </summary>
        /// <param name="id">media group id</param>
        public async Task DeleteGroupByIdAsync(int id)
        {
            MediaGroup mediaGroup = await _context.MediaGroups.FindAsync(id);

            if (mediaGroup == null)
                throw new KeyNotFoundException($"Media group with id: {id} could not be found!");

            _context.MediaGroups.Remove(mediaGroup);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets all medias
        /// </summary>
        /// <returns>instance of <see cref="IEnumerable{MediaGroupTypeDto}"/></returns>
        public async Task<IEnumerable<MediaDto>> GetAllAsync()
        {
            return await _context.Medias.Select(m => new MediaDto
            {
                Id = m.Id,
                GroupId = m.GroupId,
                Source = m.Source,
                Type = m.Type.ToString(),
                Url = m.Url
            }).ToListAsync();
        }

        /// <summary>
        /// gets all
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>instance of <see cref="IEnumerable{MediaGroupTypeDto}"/></returns>
        public async Task<IEnumerable<MediaDto>> GetAllByGroupIdAsync(int groupId)
        {
            return await _context.Medias.Where(m => m.GroupId == groupId)
                .Select(m => new MediaDto
            {
                Id = m.Id,
                GroupId = m.GroupId,
                Source = m.Source,
                Type = m.Type.ToString(),
                Url = m.Url,
                PublicId = m.PublicId
            }).ToListAsync();
        }

        /// <summary>
        /// Gets dtos for media group type enumeration
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
        /// gets media by id
        /// </summary>
        /// <param name="id">media id</param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        public async Task<MediaDto> GetByIdAsync(int id)
        {
            Media media = await _context.Medias.FindAsync(id);

            if (media == null)
                throw new KeyNotFoundException($"Media with id: {id} could not be found!");

            return new MediaDto {
                GroupId = media.GroupId,
                Id = media.Id,
                PublicId = media.PublicId,
                Type = media.Type.ToString(),
                Url = media.Url,
                Source = media.Source
            };
        }

        /// <summary>
        /// updates media
        /// </summary>
        /// <param name="updateDto">instance of <see cref="MediaUpdateDto"/></param>
        /// <returns>instance of <see cref="MediaDto"/></returns>
        public async Task<MediaDto> UpdateAsync(MediaUpdateDto updateDto)
        {
            Media media = await _context.Medias.FindAsync(updateDto.Id);

            if (media == null)
                throw new KeyNotFoundException($"Media with id: {updateDto.Id} could not be found!");

            media.Source = updateDto.Source;
            media.PublicId = updateDto.PublicId;
            _context.Medias.Update(media);

            await _context.SaveChangesAsync();

            return new MediaDto {
                Id = media.Id,
                GroupId = media.GroupId,
                Source = media.Source,
                Type = media.Type.ToString(),
                Url = media.Url,
                PublicId = media.PublicId
            };
        }
    }
}
