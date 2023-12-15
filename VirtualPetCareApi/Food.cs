using System.Text.Json.Serialization;

namespace VirtualPetCareApi
{
    public class Food : Entity<int>
    {
        public string Name { get; set; }
        public int HealthBonus { get; set; }
        public int HungerReduction { get; set; }
        public DateTime ExpirationDate { get; set; }

        [JsonIgnore]
        public virtual List<Pet> Pets { get; set; }
    }
}
