using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingSystem.Api.Services;
using OnlineBankingSystem.Domain.Entities;
using OnlineBankingSystem.Domain.Models;
using OnlineBankingSystem.Persistence.Data;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace OnlineBankingSystem.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly OnlineBankingSystemDbContext _context;
        private readonly IMapper _mapper;
        private string generatedToken = null;

        public AuthenticationController(IConfiguration config, ITokenService tokenService, OnlineBankingSystemDbContext context, IMapper mapper)
        {
            _config = config;
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Id) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest();
            }
            CustomerDto customerDto;
            try
            {
                customerDto = await getAuthenticatedCustomer(userDto);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }

            if (customerDto == null)
            {
                return NotFound();
            }
            generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), customerDto);
            if (generatedToken != null)
            {

                return Ok(generatedToken);
            }
            else
            {
                return StatusCode(500);
            }


        }

        [Authorize]
        [HttpGet("test")]
        public async Task<IActionResult> TestAuth()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok($"Authenticated as customer {customerId}");
        }


        private async Task<CustomerDto> getAuthenticatedCustomer(UserDto userDto) {
            var customer = await _context.Customers.FindAsync(userDto.Id);
            // TODO: password check logic, hashing and comparing
            if (customer.Password != userDto.Password)
            {
                throw new UnauthorizedAccessException("Incorrect password");
            }
            await _context.Entry(customer).Collection("BankAccounts").LoadAsync();
            return _mapper.Map<Customer, CustomerDto>(customer);

        }
    }
}
