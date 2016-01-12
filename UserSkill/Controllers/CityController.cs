using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSkill.Models;

namespace UserSkill.Controllers
{
    public class CityController : Controller
    {
        UserContext uDB = new UserContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(uDB.Cities.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(City city)
        {
            uDB.Entry(city).State = EntityState.Added;
            uDB.SaveChanges();
            return RedirectToAction("Index", "City");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var city = uDB.Cities.Find(id);
            return View(city);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var city = uDB.Cities.Find(id);
            uDB.Entry(city).State = EntityState.Deleted;
            uDB.SaveChanges();
            return RedirectToAction("Index", "City");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var users = uDB.Cities.Include(u => u.Users).FirstOrDefault(c => c.Id == id);
            return View(users);
        }
    }
}