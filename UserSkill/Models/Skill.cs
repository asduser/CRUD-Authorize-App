using System.Collections.Generic;

namespace UserSkill.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Skill()
        {
            Users = new List<User>();
        }
    }
}