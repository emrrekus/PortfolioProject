using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult Inbox(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var values = context.Contact.ToList().ToPagedList(pageNumber, pageSize); 
            return View(values);
        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");

        }


        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");

        }

        public ActionResult DeleteMessage(int id)
        {
            context.Contact.Remove(context.Contact.Find(id));
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }


      
    }
}