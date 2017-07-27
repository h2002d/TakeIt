using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeIt.Helpers;
using TakeIt.Models;

namespace TakeIt.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index(int id)
        {
           Post post= Post.GetPostById(id);
           PostHelper helper = new PostHelper(post);
           return View(helper);
        }
        public ActionResult FillState(int countryId)
        {
            var states = Location.GetStates(countryId);
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FillCity(int stateId)
        {
            var cities = Location.GetCities(stateId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            try
            {
                int id= Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name);
                post.UserId = id;
                post.SavePost();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FilterPosts(string fromCountryid, string fromStateId,string fromCityId ,
                                                    string toCountryid, string toStateId, string toCityId,string fromDate,string toDate)
        {
            var posts = Post.GetPosts(fromCountryid, fromStateId, 
                fromCityId, toCountryid, toStateId,
                toCityId, fromDate, toDate);
            List<PostHelper> postHelper = new List<PostHelper>();
            foreach(var post in posts)
            {
                PostHelper newPost = new PostHelper(post);
                postHelper.Add(newPost);
            }
            return PartialView("PostPartial", postHelper);
        }

    }
}
