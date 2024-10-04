using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactDetail()
        {

            ViewBag.adress = db.Profile.Select(x => x.Adress).FirstOrDefault();
            ViewBag.description = db.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.mail = db.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = db.Profile.Select(x => x.Phone).FirstOrDefault();

            return PartialView();

        }

        public PartialViewResult PartialContactLocation()
        {
            return PartialView();
        }



   
    }
}