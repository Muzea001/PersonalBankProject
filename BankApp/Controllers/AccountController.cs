using BankApp.Interface;
using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.DTOs;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BankApp.Controllers
{

    [ApiController]
    public class AccountController : Controller
    {

        private readonly IRepository<Account> _repository;
        private readonly IAccount _account;

        public AccountController(IRepository<Account> repository, IAccount account)
        {
            _repository = repository;
            _account = account;
        }

        [HttpGet("api/account")]
        public IActionResult Index()
        {
            var accounts = _repository.getAll();
            return Ok(accounts);


        }



        [HttpGet("api/account/{id}")]
        public IActionResult getbyId(int id)
        {
            var account = _repository.getElementById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);

        }



        [HttpPost("api/account/create")]
        public IActionResult CreateAccount([FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null)
            {
                return BadRequest();
            }

            var Account = new Account()
            {
                AccountId = accountDTO.AccountId,
                AccountType = accountDTO.AccountType,
                Balance = accountDTO.Balance,
                DebtSum = accountDTO.DebtSum,
                BankId = accountDTO.BankId,
                userId = accountDTO.UserId

            };
            _repository.add(Account);
            _repository.save();
            return Ok(Account);
        }



        [HttpDelete("api/account/delete/{id}")]
        public IActionResult DeleteAccount(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _repository.delete(id);
                _repository.save();
            }
            return StatusCode(204);
        }



        [HttpPut("api/account/edit")]
        public IActionResult updateAccount([FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null)
            {
                return NotFound();

            }

            Account account = new Account()
            {
                AccountId = accountDTO.AccountId,
                AccountType = accountDTO.AccountType,
                Balance = accountDTO.Balance,
                DebtSum = accountDTO.DebtSum,
                BankId = accountDTO.BankId,
                userId = accountDTO.UserId
            };
            _repository.update(account);
            _repository.save();


            return Ok(account);
        }



        [HttpGet("/api/account/getBalance/{id}")]
        public IActionResult GetAccount(int id)
        {
            if (id == 0)
            {
                return (NotFound());
            }
            decimal balance = _account.Balance(id);
            return Ok(balance);
        }



        [HttpPost("/api/account/deposit/{fromId}/{toId}/{amount}")]
        public IActionResult deposit(int fromId, int toId, decimal amount) {
            if (fromId == 0)
            {
                return NotFound("fromId not found");
            }
            else if (toId == 0)
            {
                return (NotFound("notId not found"));
            }

            else if (amount == 0)
            {
                return BadRequest("amount invalid");
            }
            var transaction = _account.Deposit(fromId, toId, amount);
            _repository.save();
            return Ok(transaction);
        }



        [HttpPost("/api/account/Withdraw/{id}/{amount}")]
        public IActionResult Withdraw(int id, decimal amount)
        {

            if (id == 0)
            {
                return (NotFound("notId not found"));
            }

            else if (amount == 0)
            {
                return BadRequest("amount invalid");
            }

            var transaction = _account.Withdraw(id, amount);
            _repository.save();
            decimal BalancePostWithdrawal = _account.Balance(id);
            
            return Ok(transaction);

        }



        [HttpGet("api/account/loanSum/{id}")]
        public IActionResult  loanSum(int id)
        {
            if (id == 0)
            {
                return NotFound("id for object not found");
            }

            decimal loanSum = _account.LoanSum(id);
            return Ok(loanSum);
        }



        [HttpPost("api/account/requestLoan/{id}")]
        public IActionResult requestLoan(int id, [FromBody] LoanDTO loanDTO)
        {
            if(id == 0)
            {
                return NotFound("id for requested object not found");
            }

            var loan = _account.RequestLoan(id, loanDTO.amount, loanDTO.type);
            return Ok(loan);
        }




        [HttpPost("api/account/downPayment/{id}")]
        public IActionResult downPayment(int accountId, int loanId) {
            if (accountId==0 || loanId == 0)
            {
                return NotFound();
            }
           var transaction =  _account.DownPayment(accountId, loanId);
            return Ok(transaction);
        }

    }
}
