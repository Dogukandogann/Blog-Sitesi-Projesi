using BusinessLayer.Concrete;
using EntityLayer.Concrete;
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
        CommentManager cm = new CommentManager();
        public PartialViewResult CommentList(int id)
        {
            var commentList = cm.CommentByBlog(id);
            return PartialView(commentList);
        }
        
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.CommentId = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            cm.CommentAdd(c);
            return PartialView();
        }
    }
}