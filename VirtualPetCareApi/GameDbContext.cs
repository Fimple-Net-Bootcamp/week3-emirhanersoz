using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodPet> FoodPets { get; set;}
        public DbSet<ActivityPet> ActivityPets { get;set; }
    }
}
