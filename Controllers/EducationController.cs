using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class EducationController : Controller
    {

        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult EducationList()
        {
            var values= context.Education.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education item)
        {

            context.Education.Add(item);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }


       
        public ActionResult EducationDelete(int id)
        {

            var value = context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }


        [HttpGet]
        public ActionResult EducationUpdate(int id)
        {
            var value = context.Education.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EducationUpdate(Education item)
        {
            var value = context.Education.Find(item.EducationId);
            value.Title = item.Title;
            value.SubTitle = item.SubTitle;
            value.Description = item.Description;
            value.Date = item.Date;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

    }
}