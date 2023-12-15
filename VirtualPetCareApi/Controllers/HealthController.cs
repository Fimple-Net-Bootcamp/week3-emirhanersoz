using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Controllers
{
    [Route("api/petcare")]
    [ApiController]
    public class PetCareController : ControllerBase
    {
        private readonly GameDbContext _gameDbContext;

        public PetCareController(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        [HttpGet("{petsId}")]
        public async Task<ActionResult<HealthStatus>> GetHealthStatusByPetId(int petId)
        {
            var healthStatus = await _gameDbContext.HealthStatuses
                .Where(h => h.Pet_id == petId)
                .FirstOrDefaultAsync();

            if (healthStatus == null)
            {
                return NotFound();
            }

            return healthStatus;
        }

        [HttpPatch("{petsId}")]
        public async Task<IActionResult> UpdateHealthStatus(int evcilHayvanId, HealthStatus updatedHealthStatus)
        {
            var existingHealthStatus = await _gameDbContext.HealthStatuses
                .Where(h => h.Pet_id == evcilHayvanId)
                .FirstOrDefaultAsync();

            if (existingHealthStatus == null)
            {
                return NotFound();
            }

            existingHealthStatus.Health = updatedHealthStatus.Health;
            existingHealthStatus.HappinessLevel = updatedHealthStatus.HappinessLevel;
            existingHealthStatus.HungerLevel = updatedHealthStatus.HungerLevel;
            existingHealthStatus.CleanlinessLevel = updatedHealthStatus.CleanlinessLevel;

            await _gameDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
