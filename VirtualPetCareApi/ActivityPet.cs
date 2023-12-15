using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCareApi
{
    public class ActivityPet
    {
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        [ForeignKey("Pet")]
        public int PetId { get; set; }

        public Activity Activity { get; set; }
        public Pet Pet { get; set; }
    }
}
