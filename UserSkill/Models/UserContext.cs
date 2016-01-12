using System.Data.Entity;

namespace UserSkill.Models
{
    public class UserContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasMany(c => c.Users)
                .WithMany(s => s.Skills)
                .Map(t => t.MapLeftKey("SkillId")
                .MapRightKey("UserId")
                .ToTable("SkillUser"));
        }
    }
}