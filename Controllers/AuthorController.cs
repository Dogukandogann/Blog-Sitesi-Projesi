using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AuthorAbout() 
        {
            return PartialView();
        }
        public PartialViewResult AuthorPopulerPost()
        {
            return PartialView();
        }
    }
}