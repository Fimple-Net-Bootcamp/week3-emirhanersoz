using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly GameDbContext _gameDbContext;

        public PetController(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _gameDbContext.Pets.Add(pet);
            await _gameDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPetById), new { petId = pet.Id }, pet);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAllPets()
        {
            return await _gameDbContext.Pets.ToListAsync();
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<Pet>> GetPetById(int petId)
        {
            var pet = await _gameDbContext.Pets.FindAsync(petId);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPut("{petId}")]
        public async Task<IActionResult> PutPet(int petId, Pet pet)
        {
            if (petId != pet.Id)
            {
                return BadRequest();
            }

            _gameDbContext.Entry(pet).State = EntityState.Modified;

            try
            {
                await _gameDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(petId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool PetExists(int petId)
        {
            return _gameDbContext.Pets.Any(e => e.Id == petId);
        }
    }
}
