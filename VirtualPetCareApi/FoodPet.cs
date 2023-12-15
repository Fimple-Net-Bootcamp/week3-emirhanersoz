using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCareApi
{
    public class FoodPet
    {
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        [ForeignKey("Pet")]
        public int PetId { get; set; } 

        public Food Food { get; set; }
        public Pet Pet { get; set; }
    }
}
