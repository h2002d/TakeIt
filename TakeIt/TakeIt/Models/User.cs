using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeIt.DAO;

namespace TakeIt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProflePicture { get; set; }
        
        public User()
        {

        }
        public User GetUserById(int id)
        {
            return UserDAO.getUserById(id);
        }
        public static int Login(string username, string password)
        {

            return UserDAO.userLogin(username,password);
        }

        public void Register()
        {
            UserDAO.registerUser(this.Username, this.Email, this.Password,
                this.PhoneNumber, this.ProflePicture);
        }
        
    }
}
