namespace VisitingStolac.Common
{
    /// <summary>
    /// dto for updating media
    /// </summary>
    public class MediaUpdateDto
    {
        /// <summary>
        /// media id
        /// </summary>
        public int Id { get; set; }

        /// <summary> cloudinary public id </summary>
        public string PublicId { get; set; }

        /// <summary>
        /// where the media is found e.g. reference
        /// </summary>
        public string Source { get; set; }
    }
}
