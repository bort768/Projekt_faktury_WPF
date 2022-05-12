﻿using System;
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
        public double Price_Netto { get; set; }
        public double Price_Brutto { get; set; }
        public double VAT { get; set; }
        public string VAT_String { get; set; }
        // można dodać walute i inne parametry

        public Goods(string product_Name, string product_Code, string description,
            double price_Netto, double price_Brutto, double vAT, string _vAT_String)
        {
            Product_Name = product_Name;
            Product_Code = product_Code;
            //Product_Id = product_Id;
            Description = description;
            Price_Netto = price_Netto;
            Price_Brutto = price_Brutto;
            VAT = vAT;
            VAT_String = _vAT_String;
        }

        public override string ToString()
        {
            return $"{Product_Name}";
        }
    }
}
