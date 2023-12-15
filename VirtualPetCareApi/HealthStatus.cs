using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCareApi
{
    public class HealthStatus : Entity<int>
    {
        public int Pet_id { get; set; }
        public int Health { get; set; }
        public int HappinessLevel { get; set; }
        public int HungerLevel { get; set; }
        public int CleanlinessLevel { get; set; }

        [ForeignKey("Pet_id")]
        public virtual Pet Pet { get; set; }
    }
}
