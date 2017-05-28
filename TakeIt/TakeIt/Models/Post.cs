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
        public int FromCountryId { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public string CreateDate { get; set; }
        public DateTime PostTime  { get; set; }

        public Post()
        {

        }

        public static Post GetPostById()
        {
            return null;
        }
        public Post SavePost()
        {
            return PostDAO.savePost(this);
        }
    }
}
