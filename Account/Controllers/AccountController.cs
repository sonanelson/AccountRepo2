using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Account.Controllers
{
    public class AccountController : ApiController
    {
        private IRepository _repository;
        public AccountController()
        {
        }
            public AccountController(IRepository repository)
        {
            _repository = repository;
        }
        public IHttpActionResult Get()
        {
            List<AccountDTO> accountList = _repository.GetAllAccounts();


            if (accountList.Count==0)
            {
                return NotFound();
            }
            else
            {
                return Ok(accountList);
            }
        }
        public IHttpActionResult Get(int id)
        {
            List<AccountTransaction> accountTransactions = _repository.GetAllAccountTransactionById(id);
            if (accountTransactions.Count==0)
            {
                return NotFound();
            }
            else
            {
                return Ok(accountTransactions);
            }
        }
    }
}
