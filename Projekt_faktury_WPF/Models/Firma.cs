using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    
    public sealed class Firma
    {
        private Firma() { }

        private static Firma _instance;

        public static Firma GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Firma();
            }
            return _instance;
        }


        public string Name { get;}

        public int NumerFaktury { get; set;}

        public BankAccount BankAccount { get; set; }

        public BossData BossData { get; set; }

        public CompanyData CompanyData { get; set; }

        public DocumentNumbering DocumentNumbering { get; set; }
        
        
        
    }
}
