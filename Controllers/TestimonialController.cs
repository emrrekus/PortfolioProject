using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult TestimonialCreate()
        {
            return View();

        }

        [HttpPost]
        public ActionResult TestimonialCreate(Testimonial item)
        {
            context.Testimonial.Add(item);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }

        public ActionResult TestimonialDelete(int id)
        {
            context.Testimonial.Remove(context.Testimonial.Find(id));
            context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }


        [HttpGet]
        public ActionResult TestimonialUpdate(int id)
        {
            return View(context.Testimonial.Find(id));

        }

        [HttpPost]
        public ActionResult TestimonialUpdate(Testimonial item)
        {
            var values = context.Testimonial.Find(item.FeatureId);
            values.Adress = item.Adress;
            values.NameSurname = item.NameSurname;
            values.ImageUrl = item.ImageUrl;
            values.Description = item.Description;

            context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
    }
}