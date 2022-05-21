﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.Helper
{     
    /// <summary>
    /// x * vat
    /// </summary>
    public class Vat_Helper
    {
        public const double VAT_23 = 1.23;
        public const double VAT_7 = 1.07;
        public const double VAT_6 = 1.06;
        public const double VAT_3 = 1.03;
        public const double VAT_0 = 1;


        public const string VAT_23_String = "VAT 23%";
        public const string VAT_7_String = "VAT 7%";
        public const string VAT_6_String = "VAT 6%";
        public const string VAT_3_String = "VAT 3%";
        public const string VAT_0_String = "VAT 0%";

        public static List<string> List_VAT_Strings = new List<string>{ VAT_23_String, VAT_7_String, VAT_6_String, VAT_3_String, VAT_0_String};
    }
}  