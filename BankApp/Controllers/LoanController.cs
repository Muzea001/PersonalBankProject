using BankApp.Interface;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankApp.Controllers
{
    public class LoanController : Controller
    {

        private readonly ILogger _logger;
        private readonly IRepository<Loan> _repository;
        public LoanController(ILogger logger, IRepository<Loan> loan)
        {
            _logger = logger;
            _repository = loan;
        }

        public IActionResult Index()
        {
            var loans = _repository.getAll();
            return View(loans);


        }

        public IActionResult getbyId(string id)
        {
            var loan = _repository.getElementByStringId(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);

        }

        public IActionResult CreateLoan(Loan loan)
        {

            if (ModelState.IsValid)
            {
                _repository.add(loan);
                _repository.save();
                return RedirectToAction(nameof(Index));
            }
            return View(loan);
        }

        public IActionResult DeleteLoan(Loan loan)
        {
            if (loan == null)
            {
                return NotFound();
            }
            else
            {
                _repository.delete(loan.LoanId);
                _repository.save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult updateLoan(Loan loan)
        {
            if (loan == null)
            {
                return NotFound();

            }
            else
            {
                _repository.update(loan);
                _repository.save();

            }
            return RedirectToAction(nameof(Index));
        }


    }
}
