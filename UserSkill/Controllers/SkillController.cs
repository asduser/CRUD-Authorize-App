using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSkill.Models;

namespace UserSkill.Controllers
{
    public class SkillController : Controller
    {
        UserContext uDB = new UserContext();

        internal int a = 100;

        [HttpGet]
        public ActionResult Index()
        {
            return View(uDB.Skills.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(List<Skill> skills)
        {
            foreach (var s in skills)
            {
                uDB.Entry(s).State = EntityState.Added;   
            }
            uDB.SaveChanges();
            return RedirectToAction("Index", "Skill");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var skill = uDB.Skills.Find(id);
            return View(skill);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var skill = uDB.Skills.Find(id);
            uDB.Entry(skill).State = EntityState.Deleted;
            uDB.SaveChanges();
            return RedirectToAction("Index", "Skill");
        }

	}
}