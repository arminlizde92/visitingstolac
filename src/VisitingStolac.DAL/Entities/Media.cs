using System.ComponentModel.DataAnnotations;
using VisitingStolac.Common;

namespace VisitingStolac.DAL
{
    /// <summary>
    /// public class for videos/images
    /// </summary>
    public class Media
    {
        /// <summary> Identification number </summary>
        public int Id { get; set; }

        /// <summary> public id </summary>
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
        public int GroupId { get; set; }

        /// <summary> virtual instance of media group </summary>
        public virtual MediaGroup Group { get; set; }
    }
}
