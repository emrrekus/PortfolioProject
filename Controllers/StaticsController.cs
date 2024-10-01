using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class StaticsController : Controller
    {

        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult Index()
        {

            ViewBag.totalMessageCount = context.Contact.Count();
            ViewBag.messageIsReadTrueCount=context.Contact.Where(x=>x.IsRead==true).Count();
            ViewBag.messageIsReadFalseCount = context.Contact.Where(x => x.IsRead==false).Count();
            ViewBag.skillCount=context.Skill.Count();
            ViewBag.skillRateSum=context.Skill.Sum(x=>x.Rate);
            ViewBag.skillRateAvg=context.Skill.Average(x=>x.Rate);
            

            var maxRate=context.Skill.Max(x=>x.Rate);
            ViewBag.maxRateSkillName=context.Skill.Where(x=>x.Rate==maxRate).Select(y=>y.SkillName).FirstOrDefault();
            
            ViewBag.getMessageCountBySubjectReferances=context.Contact.Where(x=>x.Subject=="Test").Count();

            ViewBag.getMessageSendPeople=context.Contact.Where(x=>x.Subject=="Test").Select(y=>y.NameSurname).FirstOrDefault();

            ViewBag.getMessageCountByEmailContainAAndIsReadTrue=context.Contact.Where(x=>x.IsRead==true &&x.Email.Contains("z")).Count();
           
            return View();
        }
    }
}