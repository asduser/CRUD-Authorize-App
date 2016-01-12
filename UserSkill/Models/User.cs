using System.Collections.Generic;

namespace UserSkill.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }

        public User()
        {
            Skills = new List<Skill>();
        }
    }
}