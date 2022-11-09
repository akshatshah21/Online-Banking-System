using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Domain.Models;
using OnlineBankingSystem.Persistence.Data;

namespace OnlineBankingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly OnlineBankingSystemDbContext _context;
        private readonly IMapper _mapper;

        public TransactionsController(OnlineBankingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
        {
            IEnumerable<Transaction> transactions = await _context.Transactions.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDto>>(transactions));
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransaction(string id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return _mapper.Map<TransactionDto>(transaction);
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction([FromBody] TransactionDto transactionDto)
        {
            if (!DoesBankAccountExist(transactionDto.FromAccountNumber))
            {
                return NotFound("Sender account not found");
            }
            if(!DoesBankAccountExist(transactionDto.ToAccountNumber)) {
                return NotFound("Receiver account not found");
            }

            var sender = await _context.BankAccounts.FindAsync(transactionDto.FromAccountNumber);
            
            if(transactionDto.Amount < 0) {
                return Conflict("Amount can't be negative");
            }

            if(sender.Balance - transactionDto.Amount < sender.MinBalance) {
                return Conflict("Minimum balance requirement not met");
            }

            await _context.Entry(sender).Collection("Beneficiaries").LoadAsync();

            if (!sender.Beneficiaries.Any(b => b.AccountNumber == transactionDto.ToAccountNumber))
            {
                return Conflict("Receiver account is not a beneficiary of sender account");
            }
            var receiver = await _context.BankAccounts.FindAsync(transactionDto.ToAccountNumber);

            sender.Balance -= transactionDto.Amount;
            receiver.Balance += transactionDto.Amount;


            _context.Entry(sender).State = EntityState.Modified;
            _context.Entry(receiver).State = EntityState.Modified;

            Transaction transaction = _mapper.Map<Transaction>(transactionDto);
            _context.Transactions.Add(transaction);

            await _context.Entry(sender).Collection("SentTransactions").LoadAsync();
            sender.SentTransactions.Add(transaction);

            await _context.Entry(receiver).Collection("ReceivedTransactions").LoadAsync();
            receiver.ReceivedTransactions.Add(transaction);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, _mapper.Map<TransactionDto>(transaction));
        }

        private bool TransactionExists(string id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }

        private bool DoesBankAccountExist(string id)
        {
            return _context.BankAccounts.Any(e => e.AccountNumber == id);
        }
    }
}
