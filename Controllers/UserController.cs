using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class UserController : Controller
    {
        // GET: AuthorLogin
        UserProfileManager _userProfileManager = new UserProfileManager();

        public ActionResult Index()
        {
           return View();
        } 
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profileValues = _userProfileManager.GetAuthorByMail(p);
            return PartialView(profileValues);
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(x => x.AuthorId).FirstOrDefault();
            var blogs = _userProfileManager.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
    
}