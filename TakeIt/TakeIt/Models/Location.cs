using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeIt.DAO;

namespace TakeIt.Models
{
    public class Location
    {
        public class Country{
           public int id { get; set; }
            public string Name { get; set; }
        }
        public static IEnumerable<Country> GetCountries()
        {
            return LocationDAO.getCountries();
        }
        public static IEnumerable<Country> GetStates(int countryId)
        {
            return LocationDAO.getStates(countryId);
        }
        public static IEnumerable<Country> GetCities(int stateId)
        {
            return LocationDAO.getCities(stateId);
        }
        public static Country GetCountry(int id)
        {
            return LocationDAO.getCountry(id);
        }
        public static Country GetState(int id)
        {
            return LocationDAO.getState(id);
        }
        public static Country GetCity(int id)
        {
            return LocationDAO.getCity(id);
        }
    }
}
