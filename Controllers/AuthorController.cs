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
        AuthorManager authorManager = new AuthorManager();

        public PartialViewResult AuthorAbout(int id) 
        {
            var authorDetail = blogManager.GetBlogByID(id);
            return PartialView(authorDetail);
        }
        public PartialViewResult AuthorPopulerPost(int id)
        {
            var blogAuthorId = blogManager.GetAll().Where(x=>x.BlogId==id).Select(y=>y.AuthorId).FirstOrDefault();
            var authorBlogs = blogManager.GetBlogByAuthor(blogAuthorId).Where(x => x.BlogId != id);
            return PartialView(authorBlogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists = authorManager.GetAll();
            return View(authorlists);
        }
    }
}