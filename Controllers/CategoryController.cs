using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
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
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAddBl(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.FindCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            cm.EditCategory(p);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            cm.DeleteCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.ActiveCategory(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}