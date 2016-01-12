using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSkill.Models;

namespace UserSkill.Controllers
{
    public class HomeController : Controller
    {
        UserContext uDB = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string searchValue)
        {
            var persons = from p in uDB.Users select p;
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                ViewBag.IsFound = true;
                persons = persons.Where(p => p.Name == searchValue).Include(c=>c.City);
            }
            else
            {
                ViewBag.IsFound = false;
            }
            return View(persons);
        }

    }
}