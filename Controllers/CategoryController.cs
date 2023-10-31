using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        public ActionResult Index()
        {
            var categoryValues = cm.GetAll();
            return View(categoryValues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailCategoryList()
        {
            var categoryValues = cm.GetAll();
            return PartialView(categoryValues);
        }
        public ActionResult AdminCategoryList() 
        { 
            var categoryList=cm.GetAll();
            return View(categoryList);
        }
    }
}