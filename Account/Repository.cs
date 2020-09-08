using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Account
{
    public class Repository: IRepository
    {
        public Repository()
        {

        }
        AccountsEntities accountsEntities = new AccountsEntities();
        public List<AccountDTO> GetAllAccounts()
        {
            var accounts = accountsEntities.AccountLists.Select(b => new AccountDTO()
            {
                Account_Number = b.Account_Number,
                Account_Name = b.Account_Name,
                Account_Type = b.Account_Type.Trim(),
                Balance_Date = b.Balance_Date,
                Currency = b.Currency.Trim(),
                Opening_Balance = b.Opening_Balance

            });
            return accounts.ToList();
        }

        public List<AccountTransaction> GetAllAccountTransactionById(int id)
        {
            var accounts = accountsEntities.AccountTransactions.Where(b => b.Account_Number == id).ToList();
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();
            foreach (var item in accounts)
            {
                AccountTransaction accountTransaction = new AccountTransaction();
                accountTransaction.Account_Name = item.Account_Name;
                accountTransaction.Account_Number = item.Account_Number;
                accountTransaction.Credit_Amount = item.Credit_Amount;
                accountTransaction.Currency = item.Currency;
                accountTransaction.Debit_Amount = item.Debit_Amount;
                accountTransaction.Debit_Credit = item.Debit_Credit.Trim();
                accountTransaction.TransactionNarrative = item.TransactionNarrative;
                accountTransaction.Value_Date = item.Value_Date;
                accountTransactions.Add(accountTransaction);
            }
            return accountTransactions;
        }
    }
}