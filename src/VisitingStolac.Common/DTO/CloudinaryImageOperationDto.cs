using System.Net;

namespace VisitingStolac.Common
{
    /// <summary>
    /// public dto for cloudinary images
    /// </summary>
    public class CloudinaryImageOperationDto
    {
        /// <summary>
        /// public id
        /// </summary>
        public string PublicId  { get; set; }

        /// <summary>
        /// image url from cloudinary
        /// </summary>
        public string AbsoluteUrl { get; set; }

        /// <summary>
        /// http status code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
