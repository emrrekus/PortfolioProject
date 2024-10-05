using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult SocialMediaList()
        {
            return View(context.SocialMedia.ToList());
        }


        [HttpGet]
        public ActionResult CreateSocialMedia()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia social)
        {
            context.SocialMedia.Add(social);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia social)
        {
            var value = context.SocialMedia.Find(social.SocialMediaId);
            value.Url = social.Url;
            value.Icon = social.Icon;
            value.Title = social.Title;
            value.Status = social.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}