using System.ComponentModel.DataAnnotations;

namespace VisitingStolac.Common
{
    /// <summary>
    /// media create dto
    /// </summary>
    public class MediaCreateDto
    {
        /// <summary> cloudinary public id </summary>
        public string PublicId { get; set; }

        /// <summary> Tells where the media is found </summary>
        public string Source { get; set; }

        /// <summary> Url to the media (absolute) </summary>
        [Required]
        public string Url { get; set; }

        /// <summary> Video/Image/Icon ect. </summary>
        [Required]
        public MediaType Type { get; set; }

        /// <summary> media group id </summary>
        public int GroupId { get; set; } = 0;

        [Required]
        /// <summary> Tells if Post/Banner ect.. </summary>
        public MediaGroupType GroupType { get; set; }
    }
}
