using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class BankAccount
    {
        public string BankAccount_Name { get; set; }
        public string Account_Number { get; set; }
        public bool Is_IBAN_Active { get; set; }
        public string Currency { get; set; }
        public int Value { get; set; }

        public BankAccount(string bankAccount_Name, string account_Number, bool is_IBAN_Active, string currency, int value)
        {
            BankAccount_Name = bankAccount_Name;
            Account_Number = account_Number;
            Is_IBAN_Active = is_IBAN_Active;
            Currency = currency;
            Value = value;
        }
    }
}
