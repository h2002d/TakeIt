﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TakeIt.Models;

namespace TakeIt.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Countries = Location.GetCountries();
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
           
            int userId=TakeIt.Models.User.Login(username,password);
            if (userId.Equals(0))
                throw new HttpUnhandledException();
            else
            {
                FormsAuthentication.RedirectFromLoginPage(userId.ToString(), true);
                HttpCookie StudentCookies = new HttpCookie("userkey");
                StudentCookies.Value = userId.ToString();
                StudentCookies.Expires = DateTime.Now.AddDays(1);
                CookieSecurityProvider.Encrypt(StudentCookies);
                Response.SetCookie(StudentCookies);
            }
            return RedirectToAction("Index");
        }

        public ActionResult SignUp()
        {
            return View();
        }
    
        //
        // GET: /Home/Details/5

        public ActionResult PostDetails(int id)
        {
            return View();
        }


        public ActionResult UserDetails(int id)
        {
            User user = TakeIt.Models.User.GetUserById(id);           
            return View(user);
        }
        //
        // GET: /Home/Create

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                user.Register();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Registration");
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreatePost()
        {
            ViewBag.Countries = Location.GetCountries();
            return View();
        }

        //
        // POST: /Home/Create

      
        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
