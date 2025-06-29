using System.Data.SqlClient;

namespace VirtualArtGallery.Util
{
    public class DBConnUtil
    {
        private static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VirtualArtGallery;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
