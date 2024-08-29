using BankApp.Interface;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class UserController : Controller
    {

        private ILogger _logger;
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository, Logger<User> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var users = _repository.getAll();
            return View(users);


        }

        public IActionResult getbyId(int id)
        {
            var User = _repository.getElementById(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);

        }

        public IActionResult CreateUser(User user)
        {

            if (ModelState.IsValid)
            {
                _repository.add(user);
                _repository.save();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult DeleteUser(User user)
        {
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                _repository.delete(user.UserId);
                _repository.save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult updateUser(User user)
        {
            if(user == null)
            {
                return NotFound();

            }
            else
            {
                _repository.update(user);
                _repository.save();

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
