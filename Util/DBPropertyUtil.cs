using System;

namespace VirtualArtGallery.Util
{
    public class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName = null)
        {
            // File name is ignored, hardcoded value returned
            return "Server=(localdb)\\MSSQLLocalDB;Database=VirtualArtGallery;Trusted_Connection=True;";
        }
    }
}
