using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCareApi
{
    public class Pet : Entity<int>
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public int Age { get; set; }   

        public virtual List <Activity> Activities { get; set; }
        public virtual List <Food> Foods { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
