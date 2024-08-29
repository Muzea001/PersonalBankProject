using BankApp.DAL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using BankApp.Interface;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace BankApp.Controllers
{



    [ApiController]
    public class BankController : ControllerBase
    {

        private readonly IBank _bankRepository;

        public BankController(IBank bankRepository)
        {
            _bankRepository = bankRepository;
        }


        [HttpGet("api/bank")]
        public IActionResult GetAllBanks()
        {
            var banks = _bankRepository.overview();
            return Ok(banks);

        }

        [HttpGet("api/bank/{id}")]
        public IActionResult GetAccounts(int id)
        {
            var  liste  =_bankRepository.accountsInBank(id);
            return Ok(liste);

        }

        [HttpGet("api/bank/CurrentSavings/{id}")]
        public IActionResult CurrentSavings(int id)
        {
            var currentSavings = _bankRepository.calculateCurrentSavings(id);
            return Ok(currentSavings);

        }

        [HttpGet("api/bank/sumLoans/{id}")]
        public IActionResult CurrentLoans(int id)
        {
            var sumLoans = _bankRepository.sumOfallLoans(id);
            return Ok(sumLoans);

        }

        [HttpGet("api/bank/projectedHoldings/{id}")]
        public IActionResult projectedHoldings(int id)
        {
            var sumHoldings = _bankRepository.sumOfProjectedHoldings(id);
            return Ok(sumHoldings);

        }


    }
}
