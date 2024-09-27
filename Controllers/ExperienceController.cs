using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ExperienceController : Controller
    {

        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult ExperienceList()
        {

            var value=context.Experience.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult CreateExperience(Experience ex)
        {
            context.Experience.Add(ex);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }


        public ActionResult DeleteExperience(int id)
        {

            var value=context.Experience.Find(id);
            context.Experience.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");

        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = context.Experience.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Experience ex)
        {
            var value=context.Experience.Find(ex.ExperienceId);
            value.SubTitle = ex.SubTitle;
            value.Title = ex.Title;
            value.Description = ex.Description; 
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}