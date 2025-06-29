using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualArtGallery.DAO;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Exception;

namespace VirtualArtGallery.Tests
{
    [TestClass]
    public class ArtworkTests
    {
        private IVirtualArtGallery service;

        [TestInitialize]
        public void Setup()
        {
            service = new VirtualArtGalleryImpl();
        }

        [TestMethod]
        public void TestAddArtwork()
        {
            var artwork = new Artwork(106, "Test", "Testing", "2024", "Digital", "img.png", 1);
            bool result = service.AddArtwork(artwork);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArtWorkNotFoundException))]
        public void TestGetInvalidArtwork()
        {
            service.GetArtworkById(999);
        }
    }
}
