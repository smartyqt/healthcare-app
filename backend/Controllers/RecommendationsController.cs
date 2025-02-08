using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecommendationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecommendationsController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,HealthcareProfessional")]
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Recommendation>>> GetRecommendationsForPatient(int patientId)
        {
            var recommendations = await _context.Recommendations
                .Where(r => r.PatientId == patientId)
                .ToListAsync();

            return Ok(recommendations);
        }
        [Authorize(Roles = "HealthcareProfessional")]
        [HttpPost]
        public async Task<ActionResult<Recommendation>> CreateRecommendation([FromBody] Recommendation recommendation)
        {
            if (recommendation == null || string.IsNullOrWhiteSpace(recommendation.Type) ||
                string.IsNullOrWhiteSpace(recommendation.Description) || recommendation.PatientId <= 0)
            {
                return BadRequest("Invalid recommendation data. Ensure all fields are filled.");
            }

            _context.Recommendations.Add(recommendation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecommendationsForPatient), new { patientId = recommendation.PatientId }, recommendation);
        }
        [Authorize(Roles = "HealthcareProfessional")]
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkRecommmendationComplete(int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation == null)
            {
                return NotFound(new { message = $"Recommendation with ID {id} not found" });
            }
            recommendation.IsCompleted = true;
            _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
