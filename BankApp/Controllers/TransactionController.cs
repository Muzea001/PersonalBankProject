using BankApp.Interface;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ILogger _logger;
        private readonly IRepository<Transaction> _repository;

        public TransactionController(Logger<Transaction>logger, IRepository<Transaction> repository)
        {
            _logger = logger;
            _repository = repository;   
        }

        public IActionResult Index()
        {
            var transactions = _repository.getAll();
            return View(transactions);


        }

        public IActionResult getbyId(string id)
        {
            var transaction = _repository.getElementByStringId(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);

        }

        public IActionResult CreateTransaction(Transaction transaction)
        {

            if (ModelState.IsValid)
            {
                _repository.add(transaction);
                _repository.save();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        public IActionResult DeleteTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                return NotFound();
            }
            else
            {
                _repository.delete(transaction.TransactionId);
                _repository.save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult updateTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                return NotFound();

            }
            else
            {
                _repository.update(transaction);
                _repository.save();

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

