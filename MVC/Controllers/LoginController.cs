using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authorize(MVC.Models.User userModel)
        {
            //Find the match log in information from the database
            using (LoginDBEntities db = new LoginDBEntities()) {

                var userDetails = db.Users.Where(x  => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();

                //Handle the incorrect login detail
                if(userDetails == null)
                {
                    userModel.LoginErrorMessage = "Incorrect Username or Password";
                    return View("Index",userModel);
                }
                else
                {
                    //successful login
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}