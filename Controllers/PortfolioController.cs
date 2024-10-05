using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class PortfolioController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult PortfolioList()
        {

            return View(context.Portfolio.ToList());
        }

        [HttpGet]
        public ActionResult PortfolioCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PortfolioCreate(Portfolio portfolio )
        {
            context.Portfolio.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public ActionResult PortfolioDelete(int id)
        {
            context.Portfolio.Remove(context.Portfolio.Find(id));
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public ActionResult PortfolioUpdate(int id)
        {

            return View(context.Portfolio.Find(id));
        }

        [HttpPost]
        public ActionResult PortfolioUpdate(Portfolio portfolio)
        {

            var value = context.Portfolio.Find(portfolio.ExpertiseId);
            value.Title = portfolio.Title;  
            value.Description = portfolio.Description;
            value.Image = portfolio.Image;  
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}