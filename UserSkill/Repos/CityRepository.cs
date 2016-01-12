using System.Data.Entity;
using System.Linq;
using UserSkill.Models;

namespace UserSkill.Repos
{
    public class CityRepository : IRepository<City>
    {

        private UserContext db;
        public CityRepository()
        {
            this.db = new UserContext();
        }

        public IQueryable<City> GetAll()
        {
            return db.Cities;
        }

        public City GetById(int id)
        {
            return db.Cities.Find(id);
        }

        public void Create(City item)
        {
            db.Entry(item).State = EntityState.Added;
            Save();
        }

        public void Update(City item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var item = db.Cities.Find(id);
            db.Entry(item).State = EntityState.Deleted;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}