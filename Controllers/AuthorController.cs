using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class AuthorController : Controller
    {
        BlogManager blogManager = new BlogManager();

        public PartialViewResult AuthorAbout(int id) 
        {
            var authorDetail = blogManager.GetBlogByID(id);
            return PartialView(authorDetail);
        }
        public PartialViewResult AuthorPopulerPost()
        {
            return PartialView();
        }
    }
}