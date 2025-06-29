using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string ProfilePic { get; set; }

        public User() { }

        public User(int userID, string username, string password, string email, string firstName, string lastName, string dob, string profilePic)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            ProfilePic = profilePic;
        }
    }
}
