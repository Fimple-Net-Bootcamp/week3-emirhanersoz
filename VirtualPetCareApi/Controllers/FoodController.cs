using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("/api/foods")]
    public class FoodController : ControllerBase
    {
        private readonly GameDbContext _gameDbContext;

        public FoodController(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        [HttpGet]
        public IActionResult GetAllActivities()
        {
            var activities = _gameDbContext.Activities.ToList();

            if (activities == null || activities.Count == 0)
            {
                return NotFound("No activities found.");
            }

            return Ok(activities);
        }

        [HttpPost("petId")]
        public IActionResult AddActivity([FromBody] FoodPet foodPet)
        {
            if (foodPet == null)
            {
                return BadRequest("Invalid activity data");
            }

            var newActivity = new FoodPet
            {
                PetId = foodPet.PetId,
                FoodId = foodPet.FoodId,
            };

            _gameDbContext.FoodPets.Add(newActivity);
            _gameDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetFoodsForPet), new { petId = foodPet.PetId }, foodPet);
        }

        [HttpGet("{petId}")]
        public IActionResult GetFoodsForPet(int petId)
        {
            var foods = _gameDbContext.FoodPets
                .Where(fp => fp.PetId == petId)
                .Select(fp => fp.Food)
                .ToList();

            if (foods == null || foods.Count == 0)
            {
                return NotFound($"Foods for pet with ID {petId} not found.");
            }

            return Ok(foods);
        }
    }
}
