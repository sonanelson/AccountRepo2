using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public interface IRepository
    {
         List<AccountDTO> GetAllAccounts();
        List<AccountTransaction> GetAllAccountTransactionById(int id);

    }
}
