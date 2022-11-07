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
    public class BankAccountsController : ControllerBase
    {
        private readonly OnlineBankingSystemDbContext _context;

        public BankAccountsController(OnlineBankingSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/BankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            return await _context.BankAccounts.ToListAsync();
        }

        // GET: api/BankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(string id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return bankAccount;
        }

        // PUT: api/BankAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankAccount(string id, BankAccount bankAccount)
        {
            if (id != bankAccount.AccountNumber)
            {
                return BadRequest();
            }

            _context.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
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

        // POST: api/BankAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankAccount>> PostBankAccount(BankAccount bankAccount)
        {
            _context.BankAccounts.Add(bankAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BankAccountExists(bankAccount.AccountNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBankAccount", new { id = bankAccount.AccountNumber }, bankAccount);
        }

        // DELETE: api/BankAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(string id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/BankAccounts/5/AddBeneficiary
        [HttpPut("{id}/AddBeneficiary")]
        public async Task<IActionResult> AddBeneficiary(string accountNumber, string beneficiaryAccountNumber, string beneficiaryRoutingNumber)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(accountNumber);
            if (bankAccount == null)
            {
                return NotFound("Account does not exist");
            }
            if (bankAccount.Beneficiaries.Any(b => b.AccountNumber == beneficiaryAccountNumber))
            {
                return BadRequest("Beneficiary already exists");
            }

            var beneficiary = await _context.BankAccounts.FindAsync(beneficiaryAccountNumber);
            if (beneficiary == null)
            {
                return NotFound("Beneficiary account does not exist");
            }
            if (beneficiary.RoutingNumber != beneficiaryRoutingNumber)
            {
                return NotFound("Beneficiary account does not exist");
            }
            bankAccount.Beneficiaries.Add(beneficiary);
            _context.Entry(bankAccount).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return Ok();
        }


        private bool BankAccountExists(string id)
        {
            return _context.BankAccounts.Any(e => e.AccountNumber == id);
        }


    }
}
