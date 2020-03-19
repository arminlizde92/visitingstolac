using System.Net;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using VisitingStolac.Common;
using VisitingStolac.DAL.Properties;

namespace VisitingStolac.DAL.Helpers
{
    /// <summary>
    /// helper class for cloudinary services
    /// </summary>
    public static class CloudinaryHelper
    {
        /// <summary>
        /// private static instance of <see cref="Cloudinary"/>
        /// </summary>
        private static Cloudinary _cloudinary = new Cloudinary(
            new Account() {
                Cloud = Resources.Cloudinary_Name,
                ApiKey = Resources.Cloudinary_ApiKey,
                ApiSecret = Resources.Cloudinary_ApiSecret
        });

        /// <summary>
        /// Uploads image async
        /// Image can be an URL from the web or from the file system
        /// </summary>
        /// <param name="absoluteFileUrl">absoulte file url</param>
        /// <returns>image public id</returns>
        public static async Task<CloudinaryImageOperationDto> UploadAsync(string absoluteFileUrl)
        {                                          
            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(absoluteFileUrl)
            };

            ImageUploadResult uploadResult = await _cloudinary.UploadAsync(uploadParams);            
            return new CloudinaryImageOperationDto {
                PublicId = uploadResult.PublicId,
                AbsoluteUrl = uploadResult.SecureUri.ToString(),
                HttpStatusCode = uploadResult.StatusCode
            };
        }

        /// <summary>
        /// deletes image from cloudinary
        /// </summary>
        /// <param name="publicId">images public id</param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> DeleteAsync(string publicId)
        {
            DeletionParams deletionParams = new DeletionParams(publicId);
            DeletionResult deletionResult = await _cloudinary.DestroyAsync(deletionParams);

            if (deletionResult.Result == "not found")
                return HttpStatusCode.NotFound;

            return deletionResult.StatusCode;
        }
    }
}
