using System;
using System.Data.Entity;
using System.Linq;
using UserSkill.Models;

namespace UserSkill.Repos
{
    public class UserRepository : IUserSkillCollections, IRepository<User>
    {
        private UserContext db;
        public UserRepository()
        {
            this.db = new UserContext();
        }

        public void Create(User item)
        {
            db.Entry(item).State = EntityState.Added;
            Save();
        }

        public void Delete(int id)
        {
            var result = db.Users.Find(id);
            if (result != null)
            {
                db.Entry(result).State = EntityState.Deleted;
                Save();
            }
        }

        public IQueryable<User> GetAll()
        {
            return db.Users;
        }

        public User GetById(int id)
        {
            return db.Users.Find(id);
        }

        public IQueryable<City> Cities()
        {
            return db.Cities;
        }
        public IQueryable<Skill> Skills()
        {
            return db.Skills;
        }
        public IQueryable<User> Users()
        {
            return db.Users;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

    }
}