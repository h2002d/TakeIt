using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeIt.Models;

namespace TakeIt.Helpers
{
    public class PostHelper :Post
    {
        public string ToCountryName { get; set; }
        public string ToCityName { get; set; }
        public string ToStateName { get; set; }
        public string FromCountryName { get; set; }
        public string FromCityName { get; set; }
        public string FromStateName { get; set; }
        public string Username { get; set; }


        public PostHelper(Post post)
        {
            this.id = post.id;
            this.UserId = post.UserId;
            this.CreateDate = post.CreateDate;
            this.PostTime = post.PostTime;
            this.FromCountryName = Location.GetCountry(post.FromCountryId).Name;
            this.ToCountryName = Location.GetCountry(post.ToCountryId).Name;
            this.FromStateName = Location.GetState(post.FromStateId).Name;
            this.ToStateName = Location.GetState(post.ToStateId).Name;
            this.FromCityName = Location.GetCity(post.FromCityId).Name; 
            this.ToCityName=Location.GetCity(post.ToCityId).Name;
            this.Username = User.GetUserById(post.UserId).Username;
            
        }
    }
}
