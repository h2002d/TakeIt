using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeIt.Models;

namespace TakeIt.DAO
{
    class UserDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["TakeItConnectionString"].ConnectionString;

        public static User getUserById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        User user = new User();
                        while (rdr.Read())
                        {

                            user.Id = Convert.ToInt32(rdr["Id"]);
                            user.Email = rdr["Email"].ToString();
                            user.Username = rdr["Username"].ToString();
                            user.PhoneNumber = rdr["PhoneNumber"].ToString();
                            //params adding
                        }

                        return user;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }
        }
        public static void registerUser(string username, string email,
                                            string password, string phone, string profilepicture)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("RegisterUser", sqlConnection))
                {
                  
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@profilepicture", profilepicture);

                        command.Parameters.AddWithValue("@phone", phone);
                        command.ExecuteNonQuery();

                    
                  
                }
            }
        }
    }
}
