using System;
using VirtualArtGallery.DAO;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Exception;
using VirtualArtGallery.Util;

namespace VirtualArtGallery.Main
{
    public class MainModule
    {

        static void Main(string[] args)
        {
            var galleryService = new VirtualArtGalleryImpl();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== Virtual Art Gallery =====");
                Console.WriteLine("1. Add Artwork");
                Console.WriteLine("2. Get Artwork by ID");
                Console.WriteLine("3. Update Artwork");
                Console.WriteLine("4. Remove Artwork");
                Console.WriteLine("5. Search Artworks");
                Console.WriteLine("6. Add to Favorites");
                Console.WriteLine("7. Remove from Favorites");
                Console.WriteLine("8. Get User Favorites");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Artwork ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Description: ");
                        string desc = Console.ReadLine();
                        Console.Write("Creation Date: ");
                        string date = Console.ReadLine();
                        Console.Write("Medium: ");
                        string medium = Console.ReadLine();
                        Console.Write("Image URL: ");
                        string img = Console.ReadLine();
                        Console.Write("Artist ID: ");
                        int artistId = int.Parse(Console.ReadLine());

                        var artwork = new Artwork(id, title, desc, date, medium, img, artistId);
                        Console.WriteLine(galleryService.AddArtwork(artwork) ? "Added successfully." : "Add failed.");
                        break;

                    case "2":
                        Console.Write("Enter Artwork ID: ");
                        try
                        {
                            var art = galleryService.GetArtworkById(int.Parse(Console.ReadLine()));
                            Console.WriteLine($"Found: {art.Title}, {art.Description}, {art.CreationDate}");
                        }
                        catch (ArtWorkNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "3":
                        Console.Write("Artwork ID to Update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("New Title: ");
                        string newTitle = Console.ReadLine();
                        Console.Write("New Description: ");
                        string newDesc = Console.ReadLine();
                        Console.Write("New Creation Date: ");
                        string newDate = Console.ReadLine();
                        Console.Write("New Medium: ");
                        string newMedium = Console.ReadLine();
                        Console.Write("New Image URL: ");
                        string newImg = Console.ReadLine();
                        Console.Write("New Artist ID: ");
                        int newArtistId = int.Parse(Console.ReadLine());

                        var updatedArtwork = new Artwork(updateId, newTitle, newDesc, newDate, newMedium, newImg, newArtistId);
                        Console.WriteLine(galleryService.UpdateArtwork(updatedArtwork) ? "Updated successfully." : "Update failed.");
                        break;

                    case "4":
                        Console.Write("Artwork ID to Remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        Console.WriteLine(galleryService.RemoveArtwork(removeId) ? "Removed successfully." : "Remove failed.");
                        break;

                    case "5":
                        Console.Write("Search Keyword: ");
                        string keyword = Console.ReadLine();
                        var results = galleryService.SearchArtworks(keyword);
                        foreach (var a in results)
                        {
                            Console.WriteLine($"{a.ArtworkID}: {a.Title} - {a.Description}");
                        }
                        if (results.Count == 0)
                            Console.WriteLine("No artworks found.");
                        break;

                    case "6":
                        Console.Write("User ID: ");
                        int userIdFav = int.Parse(Console.ReadLine());
                        Console.Write("Artwork ID to Favorite: ");
                        int artIdFav = int.Parse(Console.ReadLine());
                        Console.WriteLine(galleryService.AddArtworkToFavorite(userIdFav, artIdFav) ? "Added to favorites." : "Failed to add to favorites.");
                        break;

                    case "7":
                        Console.Write("User ID: ");
                        int userIdRem = int.Parse(Console.ReadLine());
                        Console.Write("Artwork ID to Remove: ");
                        int artIdRem = int.Parse(Console.ReadLine());
                        Console.WriteLine(galleryService.RemoveArtworkFromFavorite(userIdRem, artIdRem) ? "Removed from favorites." : "Failed to remove.");
                        break;

                    case "8":
                        Console.Write("User ID: ");
                        int favUserId = int.Parse(Console.ReadLine());
                        var favList = galleryService.GetUserFavoriteArtworks(favUserId);
                        foreach (var art in favList)
                        {
                            Console.WriteLine($"{art.ArtworkID}: {art.Title} - {art.Description}");
                        }
                        if (favList.Count == 0)
                            Console.WriteLine("No favorites found.");
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
