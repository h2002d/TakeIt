using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeIt.DAO;

namespace TakeIt.Models
{
    public class Post
    {
        public int id { get; set; }
        public int ToCountryId { get; set; }
        public int ToCityId { get; set; }
        public int ToStateId { get; set; }
        public int FromCountryId { get; set; }
        public int FromStateId { get; set; }
        public int FromCityId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PostTime  { get; set; }

        public Post()
        {

        }

        public static Post GetPostById(int id)
        {
            return PostDAO.getPostById(id);
        }
        public Post SavePost()
        {
            return PostDAO.savePost(this);
        }
        public static List<Post> GetPosts(string fromCountryid, string fromStateId,string fromCityId ,
                                                    string toCountryid, string toStateId, string toCityId,string fromDate,string toDate)
        {

            return PostDAO.getPosts(fromCountryid, fromStateId, fromCityId, toCountryid, toStateId, 
                toCityId, fromDate, toDate);
        }
    }
}
