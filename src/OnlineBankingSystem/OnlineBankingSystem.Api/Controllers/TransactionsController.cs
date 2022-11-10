using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction([FromBody] InitiateTransactionDto initiateTransactionDto)
        {
            var authenticatedCustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sender = await _context.BankAccounts.FindAsync(initiateTransactionDto.FromAccountNumber);
            if (sender == null)
            {
                return NotFound("Account does not exist");
            }

            if (authenticatedCustomerId != sender.CustomerId)
            {
                return Unauthorized();
            }
            if(!DoesBankAccountExist(initiateTransactionDto.ToAccountNumber)) {
                return NotFound("Receiver account not found");
            }

            if (sender.TransactionPin != initiateTransactionDto.TransactionPin)
            {
                return Unauthorized("Incorrect transaction PIN");
            }
            
            if(initiateTransactionDto.Amount < 0) {
                return Conflict("Amount can't be negative");
            }

            if(sender.Balance - initiateTransactionDto.Amount < sender.MinBalance) {
                return Conflict("Minimum balance requirement not met");
            }

            await _context.Entry(sender).Collection("Beneficiaries").LoadAsync();

            if (!sender.Beneficiaries.Any(b => b.AccountNumber == initiateTransactionDto.ToAccountNumber))
            {
                return Conflict("Receiver account is not a beneficiary of sender account");
            }
            var receiver = await _context.BankAccounts.FindAsync(initiateTransactionDto.ToAccountNumber);

            sender.Balance -= initiateTransactionDto.Amount;
            receiver.Balance += initiateTransactionDto.Amount;


            _context.Entry(sender).State = EntityState.Modified;
            _context.Entry(receiver).State = EntityState.Modified;

            Transaction transaction = _mapper.Map<TransactionDto, Transaction>(initiateTransactionDto);
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
