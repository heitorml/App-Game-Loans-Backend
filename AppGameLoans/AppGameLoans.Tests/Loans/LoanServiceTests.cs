using AppGameLoans.Api.Controllers;
using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Interfaces.Services;
using AppGameLoans.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace AppGameLoans.Tests.Loans
{
    [TestClass]
    public class LoanServiceTests
    {
        [TestMethod]
        public void InsertLoanInvalid()
        {
            var mockService = new Mock<ILoanService>();

            var controller = new LoanController(mockService.Object);

            //// Act
            IActionResult actionResult = (IActionResult)controller.AddNewLoan(new LoanDto { FriendId = Guid.NewGuid(), GameId = Guid.NewGuid() });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<LoanDto>;

            Assert.IsNotNull(createdResult);
        }

        [TestMethod]
        public void InsertLoanVvalid()
        {
            var mockService = new Mock<ILoanService>();

            var controller = new LoanController(mockService.Object);


    //        "gameId": "774e0112-b110-45f8-6133-08d87f7d9d6b",
    //"friendId": "699173d2-8440-4deb-9010-08d87f7d70bd",
            //// Act
            IActionResult actionResult = (IActionResult)controller.AddNewLoan(new LoanDto { FriendId = Guid.Parse("699173d2-8440-4deb-9010-08d87f7d70bd") , GameId = Guid.Parse("774e0112-b110-45f8-6133-08d87f7d9d6b") });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<LoanDto>;

            Assert.IsNotNull(createdResult);
        }
    }
}
