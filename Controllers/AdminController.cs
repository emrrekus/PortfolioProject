using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class AdminController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }

     
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }


        public PartialViewResult PartialSideBar()
        {
            ViewBag.image=db.Profile.Select(x=>x.ImageUrl).FirstOrDefault();
            return PartialView();
        }


        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}