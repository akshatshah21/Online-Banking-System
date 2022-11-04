using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Persistence.Data;

namespace OnlineBankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalLoanApplicationsController : ControllerBase
    {
        private readonly OnlineBankingSystemDbContext _context;

        public PersonalLoanApplicationsController(OnlineBankingSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonalLoanApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalLoanApplication>>> GetPersonalLoanApplications()
        {
            return await _context.PersonalLoanApplications.ToListAsync();
        }

        // GET: api/PersonalLoanApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalLoanApplication>> GetPersonalLoanApplication(string id)
        {
            var personalLoanApplication = await _context.PersonalLoanApplications.FindAsync(id);

            if (personalLoanApplication == null)
            {
                return NotFound();
            }

            return personalLoanApplication;
        }

        // PUT: api/PersonalLoanApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalLoanApplication(string id, PersonalLoanApplication personalLoanApplication)
        {
            if (id != personalLoanApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalLoanApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalLoanApplicationExists(id))
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

        // POST: api/PersonalLoanApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalLoanApplication>> PostPersonalLoanApplication(PersonalLoanApplication personalLoanApplication)
        {
            _context.PersonalLoanApplications.Add(personalLoanApplication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonalLoanApplicationExists(personalLoanApplication.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonalLoanApplication", new { id = personalLoanApplication.Id }, personalLoanApplication);
        }

        // DELETE: api/PersonalLoanApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalLoanApplication(string id)
        {
            var personalLoanApplication = await _context.PersonalLoanApplications.FindAsync(id);
            if (personalLoanApplication == null)
            {
                return NotFound();
            }

            _context.PersonalLoanApplications.Remove(personalLoanApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalLoanApplicationExists(string id)
        {
            return _context.PersonalLoanApplications.Any(e => e.Id == id);
        }
    }
}
