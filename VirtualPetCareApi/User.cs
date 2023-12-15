using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualPetCareApi
{
    public class User : Entity<int>
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public virtual List<Pet> Pets { get; set; }
    }
}
