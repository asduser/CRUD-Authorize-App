using System.Linq;
using UserSkill.Models;

namespace UserSkill.Repos
{
    public interface IUserSkillCollections
    {
        IQueryable<User> Users();
        IQueryable<Skill> Skills();
        IQueryable<City> Cities();
    }
}
