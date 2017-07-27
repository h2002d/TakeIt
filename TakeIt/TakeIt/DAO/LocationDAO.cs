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
    class LocationDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["TakeItConnectionString"].ConnectionString;

        public static List<Location.Country> getCountries()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCountries", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Location.Country> countryList = new List<Location.Country>();

                        while (rdr.Read())
                        {
                            Location.Country country = new Location.Country();
                            country.id = Convert.ToInt32(rdr["id"]);
                            country.Name = rdr["countryname"].ToString();
                            countryList.Add(country);
                        }
                        return countryList;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return null;
                }
            }

        }
        public static List<Location.Country> getStates(int countryId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetStateByCountryId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CountryId", countryId);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Location.Country> countryList = new List<Location.Country>();

                        while (rdr.Read())
                        {
                            Location.Country country = new Location.Country();
                            country.id = Convert.ToInt32(rdr["id"]);
                            country.Name = rdr["name"].ToString();
                            countryList.Add(country);
                        }
                        return countryList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
        public static List<Location.Country> getCities(int stateId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCitiesByStateId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StateId", stateId);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Location.Country> countryList = new List<Location.Country>();

                        while (rdr.Read())
                        {
                            Location.Country country = new Location.Country();
                            country.id = Convert.ToInt32(rdr["id"]);
                            country.Name = rdr["name"].ToString();
                            countryList.Add(country);
                        }
                        return countryList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
        public static Location.Country getCountry(int countryId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCountryById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CountryId", countryId);
                        SqlDataReader rdr = command.ExecuteReader();
                        Location.Country country = new Location.Country();
                        while (rdr.Read())
                        {
                            country.id = Convert.ToInt32(rdr["id"]);
                            country.Name = rdr["countryname"].ToString();
                        }
                        return country;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
        public static Location.Country getState(int stateId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetStateById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StateId", stateId);
                        SqlDataReader rdr = command.ExecuteReader();
                        Location.Country country = new Location.Country();
                        while (rdr.Read())
                        {
                            country.id = Convert.ToInt32(rdr["id"]);
                            country.Name = rdr["name"].ToString();
                        }
                        return country;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
        public static Location.Country getCity(int cityId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCityById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CityId", cityId);
                        SqlDataReader rdr = command.ExecuteReader();
                        Location.Country country = new Location.Country();
                        while (rdr.Read())
                        {
                            country.id = Convert.ToInt32(rdr["id"]);
                            country.Name = rdr["name"].ToString();
                        }
                        return country;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
   
    }
}
