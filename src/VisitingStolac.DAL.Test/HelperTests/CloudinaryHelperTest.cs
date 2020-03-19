using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisitingStolac.Common;
using VisitingStolac.DAL.Helpers;

namespace VisitingStolac.DAL.Tests
{
    /// <summary>
    /// helper class for testing cloudinary functions
    /// </summary>
    [TestClass]
    public class CloudinaryHelperTest
    {
        /// <summary>
        /// integration test for cloudinary helper
        /// </summary>
        [TestMethod]
        public async Task CloudinaryHelper_IntegrationTestAsync()
        {
            string projectDirectory = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.IndexOf("\\bin"));
            string imgUrl = Path.Combine(projectDirectory, "Misc", "testimage.jpg");

            CloudinaryImageOperationDto fromFS = await UploadAsync_Test(imgUrl);
            Assert.IsTrue(fromFS.HttpStatusCode == HttpStatusCode.OK);

            CloudinaryImageOperationDto fromWeb = await UploadAsync_Test(fromFS.AbsoluteUrl);
            Assert.IsTrue(fromWeb.HttpStatusCode == HttpStatusCode.OK);

            Assert.IsTrue(await DeleteAsync_FromCloudinary(fromFS.PublicId) == HttpStatusCode.OK);

            Assert.IsTrue(await DeleteAsync_FromCloudinary(fromWeb.PublicId) == HttpStatusCode.OK);

            Assert.IsTrue(await DeleteAsync_FromCloudinary("fake_public_id") != HttpStatusCode.OK);
        }

        /// <summary>
        /// Tests for uploading non existent file from fs
        /// should throw <see cref="FileNotFoundException"/>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task CloudinaryHelper_UploadAsync_FromFS_ShouldThrowFileNotFound()
        {
            string nonExistentPath = Path.Combine(Environment.CurrentDirectory, "imgdoesnotexist.jpg");
            await UploadAsync_Test(nonExistentPath);
        }

        /// <summary>
        /// Tests for uploading non existent file from fs
        /// should throw <see cref="DirectoryNotFoundException"/>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public async Task CloudinaryHelper_UploadAsync_FromFS_ShouldThrowDirectoryNotFound()
        {
            string nonExistentPath = Path.Combine("C://folderdoesnotexist", "imgdoesnotexist.jpg");
            await UploadAsync_Test(nonExistentPath);
        }

        /// <summary>
        /// Tests for uploading non existent file from the web
        /// should throw <see cref="NullReferenceException"/> if the site could not be found
        /// or the image on the site
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task CloudinaryHelper_UploadAsync_FromWeb_ShouldThrowNullReference()
        {
            await UploadAsync_Test("https://doesnotexist.com/nonexistentimage.jpg");
        }

        /// <summary>
        /// Tests uploading image to cloudinary from the web (random picture) and fs
        /// Assert is true if the return object has a status 200
        /// </summary>
        /// <param name="imgUrl">image url from cloudinary</param>
        /// <returns>instance of <see cref="CloudinaryImageOperationDto"/></returns>
        private async Task<CloudinaryImageOperationDto> UploadAsync_Test(string imgUrl)
        {
            return await CloudinaryHelper.UploadAsync(imgUrl);
        }

        /// <summary>
        /// Test deleting the image from cloudinary with images public id
        /// </summary>
        /// <param name="publicId">public id from cloudinary</param>
        /// <returns>instance of <see cref="HttpStatusCode"/></returns>
        private async Task<HttpStatusCode> DeleteAsync_FromCloudinary(string publicId)
        {
            return await CloudinaryHelper.DeleteAsync(publicId);
        }
    }
}
