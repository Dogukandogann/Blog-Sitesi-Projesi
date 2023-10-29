using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProjesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            Context c = new Context();
            var userInfo=c.Authors.FirstOrDefault(x=>x.Mail==p.Mail && x.Password==p.Password);
            if (userInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Mail, false);
                Session["Mail"] = userInfo.Mail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }
    }
}