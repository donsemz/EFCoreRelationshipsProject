using EFCoreRelationshipsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsProject.Data
{
    public class HeroContext: DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
