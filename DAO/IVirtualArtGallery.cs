using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.DAO
{
    public interface IVirtualArtGallery
    {
        bool AddArtwork(Artwork artwork);
        bool UpdateArtwork(Artwork artwork);
        bool RemoveArtwork(int artworkId);
        Artwork GetArtworkById(int artworkId);
        List<Artwork> SearchArtworks(string keyword);

        bool AddArtworkToFavorite(int userId, int artworkId);
        bool RemoveArtworkFromFavorite(int userId, int artworkId);
        List<Artwork> GetUserFavoriteArtworks(int userId);
    }
}
