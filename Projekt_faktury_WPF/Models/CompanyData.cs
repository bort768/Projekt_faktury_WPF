using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class CompanyData
    {

        public string Full_Name { get; }
        public string NIP { get;  }
        public string REGON { get;  }
        public string Street { get;  }
        public string House_Number { get;  } 
        //public string? Apartment_Number { get;  }
        public string ZIP_Code { get;  }
        public string Town { get;  }
        
        public CompanyData(string full_Name, string nIP, string rEGON, string street, string house_Number, string zIP_Code, string town)
        {
            Full_Name = full_Name;
            NIP = nIP;
            REGON = rEGON;
            Street = street;
            House_Number = house_Number;
            //Apartment_Number = apartment_Number;
            ZIP_Code = zIP_Code;
            Town = town;
        }




        


    }
}
