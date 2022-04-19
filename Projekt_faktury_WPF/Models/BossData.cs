using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class BossData
    {
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }

        public BossData(string name, string last_Name, string iD, string password)
        {
            Name = name;
            Last_Name = last_Name;
            ID = iD;
            Password = password;
        }
    }
}
