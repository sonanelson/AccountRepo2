using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Account.Models
{
    public class AccountDTO
    {
        public int Account_Number { get; set; }
        public string Account_Name { get; set; }
        public string Account_Type { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Balance_Date { get; set; }
        public string Currency { get; set; }
        public decimal Opening_Balance { get; set; }

    }
}