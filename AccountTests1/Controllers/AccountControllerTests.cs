using Microsoft.VisualStudio.TestTools.UnitTesting;
using Account.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Account.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace Account.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void GetShoudReturnAllAccounts()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetAllAccounts())
                .Returns(new List<AccountDTO>()
                    { new AccountDTO()
                    {
                         Account_Number= 79106619,
                        Account_Name= "AUSavings993",
                       Account_Type= "Savings",
                     Currency="AUD",
                     Opening_Balance=88006.12M
                    }
                
                });
            var controller = new AccountController(mockRepository.Object);
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<List<AccountDTO>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count());
        }
        [TestMethod()]
        public void GetShoudReturnAccountTransactionByAccountNumber()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetAllAccountTransactionById(585309209))
                .Returns(new List<AccountTransaction>()
                    { new AccountTransaction()
                    {
                         Account_Number=585309209,
        Account_Name="Current Account",
        Currency= "SGD",
        Debit_Amount= null,
        Credit_Amount= 9541,
        Debit_Credit= "Credit",
        TransactionNarrative= null,
      
                    }

                });
            var controller = new AccountController(mockRepository.Object);
            IHttpActionResult actionResult = controller.Get(585309209);
            var contentResult = actionResult as OkNegotiatedContentResult<List<AccountTransaction>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count);
        }
        [TestMethod()]
        public void GetShoudReturnAccountTransactionByAccountNumber_EmptyTransaction()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetAllAccountTransactionById(5))
                .Returns(new List<AccountTransaction>());
            var controller = new AccountController(mockRepository.Object);
            IHttpActionResult actionResult = controller.Get(5);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}