using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class DocumentNumbering
    {
        

        public bool Broken_By_Mounth { get; set; }
        public bool Broken_By_Year { get; set; }
        
        public DocumentNumbering(bool broken_By_Mounth, bool broken_By_Year)
        {
            Broken_By_Mounth = broken_By_Mounth;
            Broken_By_Year = broken_By_Year;
        }
    }
}
