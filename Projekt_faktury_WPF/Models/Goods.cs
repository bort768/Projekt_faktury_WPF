using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Models
{
    public class Goods
    {
        

        public string Product_Name { get; set; }
        public string Product_Code { get; set; }
        public int Product_Id { get; set; }
        public string Description { get; set; }
        public float Price_Netto { get; set; }
        public float Price_Brutto { get; set; }
        public float VAT { get; set; }
        // można dodać walute i inne parametry

        public Goods(string product_Name, string product_Code, string description, float price_Netto, float price_Brutto, float vAT)
        {
            Product_Name = product_Name;
            Product_Code = product_Code;
            //Product_Id = product_Id;
            Description = description;
            Price_Netto = price_Netto;
            Price_Brutto = price_Brutto;
            VAT = vAT;
        }
    }
}
