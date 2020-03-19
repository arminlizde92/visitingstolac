namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for media
    /// </summary>
    public class MediaDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary> cloudinary public id </summary>
        public string PublicId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// where the media is found e.g. reference
        /// </summary>
        public string Source { get; set; }
        
        /// <summary>
        /// media type in string format
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// media group id
        /// </summary>
        public int GroupId { get; set; }
    }
}
