using MVCFrameworkHandShake.Context;
using MVCFrameworkHandShake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCFrameworkHandShake.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        NorthwindContext context = new NorthwindContext(); 

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // Post: Account/Register
        [HttpPost]
        public ActionResult Register(User usr)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(usr);
                try
                {
                    context.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                var usrIden = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("Name", usr.UserName),
                    new Claim("Email", usr.Email),
                    new Claim("Pass", usr.Password)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(usrIden);

                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // Post: Account/Login
        [HttpPost]
        public ActionResult Login(User usr)
        {
            if(usr.Email != null && usr.Password != null)
            {
                var Us = context.Users.FirstOrDefault(u => u.Email == usr.Email && u.Password == usr.Password);

                if (Us != null)
                {
                    var usrIden = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim("Email", usr.Email),
                        new Claim("Pass", usr.Password)
                    }, "AppCookie");

                    Request.GetOwinContext().Authentication.SignIn(usrIden);

                    return RedirectToAction("Index", "Product");
                }
            }
            return View();
        }

        // Get: Account/Logout
        [Authorize]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }
    }
}