using BusinessLayer.Concrete;
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
    [Authorize]
    public class UserController : Controller
    {
        // GET: AuthorLogin
        UserProfileManager _userProfileManager = new UserProfileManager();
        BlogManager bm = new BlogManager();

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
        public ActionResult UpdateUserProfile(Author p)
        {
            _userProfileManager.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(x => x.AuthorId).FirstOrDefault();
            var blogs = _userProfileManager.GetBlogByAuthor(id);
            return View(blogs);
        }
        public ActionResult UpdateBlog(int id)
        {

            DataAccessLayer.Concrete.Context c = new DataAccessLayer.Concrete.Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> authors = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.authors = authors;
            Blog blog = bm.FindBlog(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");

        }
        public ActionResult AddNewBlog()
        {
            DataAccessLayer.Concrete.Context c = new DataAccessLayer.Concrete.Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> authors = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.authors = authors;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBl(b);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }
    }
   

}