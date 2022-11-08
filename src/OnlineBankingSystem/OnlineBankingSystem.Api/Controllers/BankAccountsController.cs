using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Domain.Models;
using OnlineBankingSystem.Persistence.Data;

namespace OnlineBankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly OnlineBankingSystemDbContext _context;
        private readonly IMapper _mapper;

        public BankAccountsController(OnlineBankingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountDto>>> GetBankAccounts()
        {
            IEnumerable<BankAccount> bankAccounts = await _context.BankAccounts.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<BankAccount>, IEnumerable<BankAccountDto>>(bankAccounts));
        }

        // GET: api/BankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountDto>> GetBankAccount(string id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return _mapper.Map<BankAccount, BankAccountDto>(bankAccount);
        }

        // PUT: api/BankAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{accountNumber}")]
        public async Task<IActionResult> PutBankAccount(string accountNumber, BankAccountDto bankAccountDto)
        {
            var bankAcccount = await _context.BankAccounts.FindAsync(accountNumber);
            if (bankAcccount == null)
            {
                return NotFound();
            }
            _mapper.Map(bankAccountDto, bankAcccount);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(accountNumber))
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
        public async Task<ActionResult<BankAccountDto>> PostBankAccount(BankAccountDto bankAccountDto)
        {
            var customer = await _context.Customers.FindAsync(bankAccountDto.CustomerId);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            BankAccount bankAccount = _mapper.Map<BankAccountDto, BankAccount>(bankAccountDto);

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

            return CreatedAtAction("GetBankAccount", new { id = bankAccount.AccountNumber }, _mapper.Map<BankAccount, BankAccountDto>(bankAccount));
        }

        // DELETE: api/BankAccounts/5
        [HttpDelete("{accountNumber}")]
        public async Task<IActionResult> DeleteBankAccount(string accountNumber)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(accountNumber);
            if (bankAccount == null)
            {
                return NotFound();
            }

            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/BankAccounts/5/AddBeneficiary
        [HttpPost("{accountNumber}/add-beneficiary")]
        public async Task<IActionResult> AddBeneficiary(string accountNumber, [FromBody] BeneficiaryDto addBeneficiaryDto)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(accountNumber);
            if (bankAccount == null)
            {
                return NotFound("Account does not exist");
            }
            Console.WriteLine(addBeneficiaryDto.RoutingNumber);
            if (bankAccount.Beneficiaries.Any(b => b.AccountNumber == addBeneficiaryDto.AccountNumber))
            {
                return BadRequest("Beneficiary already exists");
            }

            var beneficiary = await _context.BankAccounts.FindAsync(addBeneficiaryDto.AccountNumber);
            if (beneficiary == null)
            {
                return NotFound("Beneficiary account does not exist");
            }
            if (beneficiary.RoutingNumber != addBeneficiaryDto.RoutingNumber)
            {
                return NotFound("Beneficiary account does not exist");
            }
            bankAccount.Beneficiaries.Add(beneficiary);
            beneficiary.BeneficiaryOf.Add(bankAccount);
            _context.Entry(bankAccount).State = EntityState.Modified;
            _context.Entry(beneficiary).State = EntityState.Modified;
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


        [HttpGet("{accountNumber}/beneficiaries")]
        public async Task<ActionResult<IEnumerable<BeneficiaryDto>>> GetBeneficiaries(string accountNumber)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(accountNumber);
            if (bankAccount == null)
            {
                return NotFound();
            }

            IEnumerable<BankAccount> beneficiaryAccounts = bankAccount.Beneficiaries;
            IEnumerable<BankAccountDto> beneficiaries = _mapper.Map<IEnumerable<BankAccount>, IEnumerable<BankAccountDto>>(beneficiaryAccounts);
            return Ok(beneficiaries);
        }


        private bool BankAccountExists(string id)
        {
            return _context.BankAccounts.Any(e => e.AccountNumber == id);
        }


    }
}
