using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class AboutController : Controller
    {

        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult AboutList()
        {
            var values= context.About.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.About.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {

            var values=context.About.Find(about.AboutId);
            values.Title = about.Title;
            values.Description = about.Description;
            values.ImageUrl = about.ImageUrl;   
            context.SaveChanges();
            return RedirectToAction("AboutList");

        }
    }
}