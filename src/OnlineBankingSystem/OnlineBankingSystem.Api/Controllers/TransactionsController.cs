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
    public class TransactionsController : ControllerBase
    {
        private readonly OnlineBankingSystemDbContext _context;

        public TransactionsController(OnlineBankingSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(string id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTransaction(string id, Transaction transaction)
        // {
        //     if (id != transaction.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(transaction).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!TransactionExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        private bool DoesBankAccountExist(string id)
        {
            return _context.BankAccounts.Any(e => e.AccountNumber == id);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(string from, string to, double amount, string? comment)
        {
            
            // _context.Transactions.Add(transaction);
            // What is conflict.
            if (!DoesBankAccountExist(from))
            {
                return NotFound();
            }
            if(!DoesBankAccountExist(to)) {
                return NotFound();
            }

            var sender = await _context.BankAccounts.FindAsync(from);
            var receiver = await _context.BankAccounts.FindAsync(to);
            
            var bal = sender.Balance;
            var min_bal = sender.MinBalance;
            if(amount < 0) {
                return Conflict("Amount can't be negative");
            }

            if(bal - amount < min_bal) {
                return Conflict("Min_balance requirement not met.");
            }

            _context.Entry(sender).State = EntityState.Modified;
            _context.Entry(receiver).State = EntityState.Modified;
            Transaction transaction = new Transaction
            {
                Id = "1",
                Amount = amount,
                Timestamp = DateTime.UtcNow,
                FromAccountId = from,
                ToAccountId = to,
                Comment = comment
            };

            try
            {
                sender.Balance -= amount;
                receiver.Balance += amount;
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(string id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(string id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
