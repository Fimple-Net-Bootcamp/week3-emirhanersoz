namespace VirtualPetCareApi
{
    public class Activity : Entity<int>
    {
        public required string Name { get; set; }
        public int HealthBonus { get; set; }
        public int HappinessBonus { get; set; }
        public int CleanlinessReduction { get; set; }
        public required virtual List <Pet> Pets { get; set; }
    }
}
