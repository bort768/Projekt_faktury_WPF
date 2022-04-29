using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class Kontrahent
    {
        public Kontrahent(string bankAccount_Name, string account_Number, CompanyData company)
        {
            BankAccount_Name = bankAccount_Name;
            Account_Number = account_Number;
            Company = company;
        }

        // można dodac numer kontrahenta(index)
        public string BankAccount_Name { get; set; }
        public string Account_Number { get; set; }
        public CompanyData Company { get; set; }
    }
}
