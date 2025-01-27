using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecommendationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/recommendations/patient/{patientId}
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Recommendation>>> GetRecommendationsForPatient(int patientId)
        {
            var recommendations = await _context.Recommendations
                .Where(r => r.PatientId == patientId)
                .ToListAsync();

            return Ok(recommendations);
        }

        // POST: api/recommendations
        [HttpPost]
        public async Task<ActionResult<Recommendation>> CreateRecommendation(Recommendation recommendation)
        {
            _context.Recommendations.Add(recommendation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecommendationsForPatient), new { patientId = recommendation.PatientId }, recommendation);
        }
        // PUT: api/recommendations/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, Recommendation updatedRecommendation)
        {
            if (id != updatedRecommendation.Id) {
                return BadRequest("The recomendation ID in the URL does not match the body");
            }
            var existingRecommendation = await _context.Recommendations.FindAsync(id);
            if(existingRecommendation == null)
            {
                return NotFound($"Recommendation with ID {id} not found");
            }

            existingRecommendation.Type = updatedRecommendation.Type;
            existingRecommendation.Description = updatedRecommendation.Description;
            existingRecommendation.IsCompleted = updatedRecommendation.IsCompleted;
            existingRecommendation.PatientId = updatedRecommendation.PatientId;
            
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
