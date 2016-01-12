using System.Collections.Generic;

namespace UserSkill.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public City()
        {
            Users = new List<User>();
        }
    }
}