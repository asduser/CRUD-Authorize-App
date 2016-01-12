using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using UserSkill.Models;
using UserSkill.Repos;
using UserSkill.Utilities;

namespace UserSkill.Controllers
{
    public class UserController : Controller
    {
        private UserRepository db;

        public UserController()
        {
            db = new UserRepository();
        }

        [HttpGet]
        public ActionResult Index(int? city=0, string gender="Both", int page=1)
        {
            List<City> cities = db.Cities().ToList();
            cities.Insert(0, new City(){ Name = "All", Id = 0 });

            List<string> genders = new List<string> { "M", "F" };
            genders.Insert(0, "Both");
            
            List<User> users = new List<User>();

            users = city == 0 ? db.Users().Include(u => u.City).ToList() : db.Users().Include(u => u.City).Where(p => p.CityId == city).ToList();
            if (gender != "Both")
            {
                users = users.Where(u => u.Gender == gender).ToList();
            }

            const int pageSize = 5;
            IEnumerable<User> usersPerPages = users.Skip((page - 1) * pageSize).Take(pageSize);
            Pagination pageInfo = new Pagination { PageNumber = page, PageSize = pageSize, TotalItems = users.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Users = usersPerPages, Cities = new SelectList(cities, "Id", "Name"), Genders = new SelectList(genders)};

            return View(ivm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var genderList = new List<string> { "M", "F" };
            ViewBag.Genders = new SelectList(genderList);
            ViewBag.Skills = db.Skills().ToList();
            ViewBag.Cities = new SelectList(db.Cities(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user, int[] selectedSkills)
        {
            if (selectedSkills != null)
            {
                foreach (var s in db.Skills().Where(sk => selectedSkills.Contains(sk.Id)))
                {
                    user.Skills.Add(s);
                }
            }
            db.Create(user);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            var user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var genderList = new List<string> { "M", "F" };
            ViewBag.Genders = new SelectList(genderList);
            ViewBag.Cities = new SelectList(db.Cities(), "Id", "Name");
            ViewBag.Skills = db.Skills().ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user, int[] selectedSkills)
        {
            User newUser = db.GetById(user.Id);
            newUser.Name = user.Name;
            newUser.Age = user.Age;
            newUser.Gender = user.Gender;
            newUser.City = user.City;
            newUser.CityId = user.CityId;
            newUser.Skills.Clear();
            if (selectedSkills != null)
            {
                foreach (var s in db.Skills().Where(sk => selectedSkills.Contains(sk.Id)))
                {
                    newUser.Skills.Add(s);
                }
            }
            db.Update(newUser);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var user = db.GetById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.GetById(id);
            db.Delete(user.Id);
            return RedirectToAction("Index", "User");
        }

    }
}