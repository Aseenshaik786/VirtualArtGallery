using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Exception;
using VirtualArtGallery.Util;
using System.Data.SqlClient;
using System.Configuration;

namespace VirtualArtGallery.DAO
{
    public class VirtualArtGalleryImpl : IVirtualArtGallery
    {
        private readonly SqlConnection connection;

        public VirtualArtGalleryImpl()
        {
            connection = DBConnUtil.GetConnection(); 
        }



        public bool AddArtwork(Artwork artwork)
        {
            string query = "INSERT INTO Artwork VALUES (@ArtworkID, @Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
        }



        public Artwork GetArtworkById(int artworkId)
        {
            string query = "SELECT * FROM Artwork WHERE ArtworkID = @ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var artwork = new Artwork(
                        (int)reader["ArtworkID"],
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        reader["CreationDate"].ToString(),
                        reader["Medium"].ToString(),
                        reader["ImageURL"].ToString(),
                        (int)reader["ArtistID"]);
                    connection.Close();
                    return artwork;
                }
                else
                {
                    connection.Close();
                    throw new ArtWorkNotFoundException("Artwork not found.");
                }
            }
        }

        public bool UpdateArtwork(Artwork artwork)
        {
            string query = "UPDATE Artwork SET Title = @Title, Description = @Description, CreationDate = @CreationDate, Medium = @Medium, ImageURL = @ImageURL, ArtistID = @ArtistID WHERE ArtworkID = @ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);
                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
        }

        public bool RemoveArtwork(int artworkId)
        {
            string query = "DELETE FROM Artwork WHERE ArtworkID = @ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
        }

        public List<Artwork> SearchArtworks(string keyword)
        {
            List<Artwork> list = new List<Artwork>();
            string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Artwork(
                        (int)reader["ArtworkID"],
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        reader["CreationDate"].ToString(),
                        reader["Medium"].ToString(),
                        reader["ImageURL"].ToString(),
                        (int)reader["ArtistID"]));
                }
                connection.Close();
            }
            return list;
        }

        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            string query = "INSERT INTO User_Favorite_Artwork VALUES (@UserID, @ArtworkID)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
        }

        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            string query = "DELETE FROM User_Favorite_Artwork WHERE UserID = @UserID AND ArtworkID = @ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();
                return rows > 0;
            }
        }

        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            List<Artwork> artworks = new List<Artwork>();
            string query = @"SELECT A.* FROM Artwork A JOIN User_Favorite_Artwork UFA ON A.ArtworkID = UFA.ArtworkID WHERE UFA.UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    artworks.Add(new Artwork(
                        (int)reader["ArtworkID"],
                        reader["Title"].ToString(),
                        reader["Description"].ToString(),
                        reader["CreationDate"].ToString(),
                        reader["Medium"].ToString(),
                        reader["ImageURL"].ToString(),
                        (int)reader["ArtistID"]));
                }
                connection.Close();
            }
            return artworks;
        }
    }
}
