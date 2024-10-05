using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class InternshipController : Controller
    {

        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult InternshipList()
        {
            var values = context.Internship.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult InternshipCreate()
        {
            return View();

        }

        [HttpPost]
        public ActionResult InternshipCreate(Internship item)
        {
            context.Internship.Add(item);   
            context.SaveChanges();
            return RedirectToAction("InternshipList");

        }

        public ActionResult InternshipDelete(int id)
        {
            context.Internship.Remove(context.Internship.Find(id)); 
            context.SaveChanges();
            return RedirectToAction("InternshipList");

        }


        [HttpGet]
        public ActionResult InternshipUpdate(int id)
        {
            return View(context.Internship.Find(id));

        }

        [HttpPost]
        public ActionResult InternshipUpdate(Internship item)
        {
            var values = context.Internship.Find(item.InternshipId);
            values.Title = item.Title;
            values.Description = item.Description;
            values.Subtitle = item.Subtitle;    
            values.Date = item.Date;
            context.SaveChanges();
            return RedirectToAction("InternshipList");

        }
    }
}