using Microsoft.AspNetCore.Mvc;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ActivityController : Controller
    {
        private readonly GameDbContext _gameDbContext;

        public ActivityController(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        [HttpPost("activity")]
        public IActionResult AddActivity([FromBody] ActivityPet activityPet)
        {
            if (activityPet == null)
            {
                return BadRequest("Invalid activity data");
            }

            var newActivity = new ActivityPet
            {
                PetId = activityPet.PetId,
                ActivityId = activityPet.ActivityId,
            };

            _gameDbContext.ActivityPets.Add(newActivity);
            _gameDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetActivitiesForPet), new { petId = activityPet.PetId }, activityPet);
        }

        [HttpGet("activity/{petId}")]
        public IActionResult GetActivitiesForPet(int petId)
        {
            var activities = _gameDbContext.Activities.Where(a => a.Id == petId).ToList();

            if (activities == null || activities.Count == 0)
            {
                return NotFound($"Activities for pet with ID {petId} not found.");
            }

            return Ok(activities);
        }

        [HttpGet]
        public IActionResult GetAllActivityWithOutPets()
        {
            var GetAllActivityWithoutPetIds = _gameDbContext.Activities
                                        .OrderBy(id => activt.Id)
                                        .Select(food => new
                                        {
                                            food.Id,
                                            food.Name,
                                            food.HealthBonus,
                                            food.HungerReduction,
                                            food.ExpirationDate
                                        })
                                        .ToList();

            return Ok(foodsWithoutPetIds);
        }
    }
}
