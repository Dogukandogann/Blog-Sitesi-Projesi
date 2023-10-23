using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CommentList()
        {
            return PartialView();
        }
        public PartialViewResult LeaveComment()
        {
            return PartialView();
        }
    }
}