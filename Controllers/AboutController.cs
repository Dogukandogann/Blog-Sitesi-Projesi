using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProjesi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Footer()
        {
            var aboutContent = abm.GetAll();
            return PartialView(aboutContent);
        }
        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }

    }
}