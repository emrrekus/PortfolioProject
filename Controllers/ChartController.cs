﻿using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ChartController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var skills = context.Skill.ToList();

            
            var skillNames = skills.Select(x => x.SkillName).ToList();
            var skillRates = skills.Select(x => x.Rate).ToList();

          
            ViewBag.SkillNames = skillNames;
            ViewBag.SkillRates = skillRates;

            return View();
        }
    }
}