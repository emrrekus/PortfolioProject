using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult ServiceList()
        {
            
            return View(context.Service.ToList());
        }

        [HttpGet]
        public ActionResult ServiceCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServiceCreate(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult ServiceDelete(int id)
        {
            context.Service.Remove(context.Service.Find(id));
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult ServiceUpdate(int id)
        {
           
            return View(context.Service.Find(id));
        }

        [HttpPost]
        public ActionResult ServiceUpdate(Service service )
        {

            var value = context.Service.Find(service.ServiceId);
            value.Title = service.Title;
            value.Icon = service.Icon;
            value.Description = service.Description;
            value.Subtitle1 = service.Subtitle1;
            value.Subtitle2 = service.Subtitle2;
            value.Subtitle3 = service.Subtitle3;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

    }
}