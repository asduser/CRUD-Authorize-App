using System.Data.Entity;
using System.Linq;
using UserSkill.Models;

namespace UserSkill.Repos
{
    public class SkillRepository : IRepository<Skill>{

        private UserContext db;
        public SkillRepository()
        {
            this.db = new UserContext();
        }

        public IQueryable<Skill> GetAll()
        {
            return db.Skills;
        }

        public Skill GetById(int id)
        {
            return db.Skills.Find(id);
        }

        public void Create(Skill item)
        {
            db.Entry(item).State = EntityState.Added;
            Save();
        }

        public void Update(Skill item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var item = db.Skills.Find(id);
            db.Entry(item).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}