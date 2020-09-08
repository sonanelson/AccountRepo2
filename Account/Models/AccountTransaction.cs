using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Account.Models
{
    public class AccountTransaction
    {
        public int Account_Number { get; set; }
        public string Account_Name { get; set; }
        public DateTime Value_Date { get; set; }
        public string Currency { get; set; }
        public decimal? Debit_Amount { get; set; }
        public decimal? Credit_Amount { get; set; }
        public string Debit_Credit { get; set; }
        public string TransactionNarrative { get; set; }
    }
}