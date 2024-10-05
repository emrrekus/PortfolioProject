using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in db.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value= x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.value=values;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.IsRead = false;
            contact.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {


            ViewBag.title = db.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = db.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.adress = db.Profile.Select(x => x.Adress).FirstOrDefault();
            ViewBag.email = db.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = db.Profile.Select(x => x.Phone).FirstOrDefault();
            ViewBag.github = db.Profile.Select(x => x.Github).FirstOrDefault();
            ViewBag.imageurl = db.Profile.Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.socialMedia=db.SocialMedia.Where(x=> x.Status==true).ToList();

            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.About.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialEducation()
        {
            var values = db.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = db.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialInternship()
        {
            var values=db.Internship.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialServices()
        {
            var values= db.Service.ToList();
            return PartialView(values); 
        }

        public PartialViewResult PartialPortfolio()
        {

            var values = db.Portfolio.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {

            var values = db.Testimonial.ToList();
            return PartialView(values);
        }




        public PartialViewResult PartialSkill()
        {
            var values = db.Skill.Where(x => x.Status == true).ToList();

            return PartialView(values);
        }


        public PartialViewResult PartialFooter()
        {

            ViewBag.socialMedia = db.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView();
        }


    }
}