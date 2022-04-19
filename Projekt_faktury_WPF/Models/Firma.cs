using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class Firma
    {
        

        public string Name { get;}

        public BankAccount BankAccount { get;}

        public BossData BossData { get;}

        public CompanyData CompanyData { get;}

        public DocumentNumbering DocumentNumbering { get;}
        
        public Firma(string name, BankAccount bankAccount, BossData bossData, CompanyData companyData, DocumentNumbering documentNumbering)
        {
            Name = name;
            BankAccount = bankAccount;
            BossData = bossData;
            CompanyData = companyData;
            DocumentNumbering = documentNumbering;
        }
        
    }
}
