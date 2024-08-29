using BankApp.Interface;
using BankApp.Models;
using Moq;
using BankApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Tests

{
    public class Tests
    {
        private readonly Mock<IRepository<User>> _mockRepo;
        private readonly UserController _userController;

        public Tests(Mock<IRepository<User>> mock, UserController userController)
        {
            _mockRepo = mock;
            _userController = userController;
        }

        //[Test]
        //public void Test1()
        //{
        //    //arrange
        //    var users = new List<User>() {
        //                new User { UserId = 3, UserName = "John Doe", BankId = 1, AccountId = "AAAC1", Member = false },
        //                new User { UserId = 4, UserName = "Amy James", BankId = 1, AccountId = "AAAD3", Member = true }
        //            };

        //    _mockRepo.Setup(repo => repo.getAll()).Returns(users);

        //    //Act
        //    var result = _userController.Index();

        //    ////Assert
        //    //Assert.IsInstanceOf<ViewResult>(result);
        //    //var viewResult = result as ViewResult;
        //    //Assert.NotNull(viewResult);
        //    //Assert.IsInstanceOf<IEnumerable<User>>(viewResult.ViewData.Model);
        //    //var model = viewResult.ViewData.Model as IEnumerable<User>;
        //    //Assert.AreEqual(2, model.Count());
            
        //}
    }
}