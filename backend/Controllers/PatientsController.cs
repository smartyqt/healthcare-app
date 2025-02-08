using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace backend.Controllers
{

    [Route("api/[controller]")]
	[ApiController]
	public class PatientsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public PatientsController(AppDbContext context)
		{
			_context = context;
		}
        [Authorize(Roles = "Admin,HealthcareProfessional")]
        [HttpGet("{id}")]
		public async Task<ActionResult<Patient>> GetPatient(int id)
		{
			var patient = await _context.Patients.FindAsync(id);

			if (patient == null)
			{
				return NotFound();
			}

			return patient;
		}
        [Authorize(Roles = "Admin,HealthcareProfessional")]
        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] string? id, [FromQuery] string? name)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int patientId))
            {
                query = query.Where(p => p.Id == patientId);
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            var patients = await query.ToListAsync();
            return Ok(patients);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
		public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
		{
			_context.Patients.Add(patient);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
		}

		[Authorize(Roles = "Admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePatient(int id, Patient patient)
		{
			if (id != patient.Id)
			{
				return BadRequest();
			}

			_context.Entry(patient).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

        // DELETE: api/patients/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
		public async Task<IActionResult> DeletePatient(int id)
		{
			var patient = await _context.Patients.FindAsync(id);

			if (patient == null)
			{
				return NotFound();
			}

			_context.Patients.Remove(patient);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}