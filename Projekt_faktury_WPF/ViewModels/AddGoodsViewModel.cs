using Projekt_faktury_WPF.Commands;
using Projekt_faktury_WPF.Helper;
using Projekt_faktury_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.ViewModels
{
    public class AddGoodsViewModel : ViewModelBase
    {
        public CommandBase DeleteGoodsCommand { get; set; }
        public CommandBase GetGoodsCommand { get; set; }

        Firma firma = Firma.GetInstance();

        public static int LastAddedGood;

        //private static int Product_ID;

        public ObservableCollection<string> LastVisetedGoods { get; set; }

        public List<string> Vat_Combobox { get; set; }

        private string _product_Name;
        public string Product_Name
        {
            get
            {
                return _product_Name;
            }
            set
            {
                _product_Name = value;
                OnPropertyChanged();
            }
        }

        private string _product_Code;
        public string Product_Code
        {
            get
            {
                return _product_Code;
            }
            set
            {
                _product_Code = value;
                OnPropertyChanged();
            }
        }

        private int _product_ID;
        public int Product_ID
        {
            get
            {
                return _product_ID;
            }
            set
            {
                _product_ID = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private float _price_Netto;
        public float Price_Netto
        {
            get
            {
                return _price_Netto;
            }
            set
            {
                _price_Netto = value;
                OnPropertyChanged();
            }
        }

        private float _price_Brutto;
        public float Price_Brutto
        {
            get
            {
                return _price_Brutto;
            }
            set
            {
                _price_Brutto = value;
                OnPropertyChanged();
            }
        }

        private float _VAT;
        public float VAT
        {
            get
            {
                return _VAT;
            }
            set
            {
                _VAT = value;
                OnPropertyChanged();
            }
        }

        public AddGoodsViewModel()
        {
            Vat_Combobox = new();
            Vat_Combobox.Add(Vat_Helper.VAT_23_String);    
            Vat_Combobox.Add(Vat_Helper.VAT_7_String);    
            Vat_Combobox.Add(Vat_Helper.VAT_6_String);    
            Vat_Combobox.Add(Vat_Helper.VAT_3_String);    
            Vat_Combobox.Add(Vat_Helper.VAT_0_String);

            if (firma.goods != null)
            {
                Product_Code = firma.goods[LastAddedGood].Product_Code;
                Product_Name = firma.goods[LastAddedGood].Product_Name;
                Description = firma.goods[LastAddedGood].Description;
                Price_Netto = firma.goods[LastAddedGood].Price_Netto;
                Price_Brutto = firma.goods[LastAddedGood].Price_Brutto;
                Product_ID = firma.goods[LastAddedGood].Product_Id;

                foreach (var Goods_Combobox in firma.goods)
                {
                    LastVisetedGoods.Add(Product_Name);
                }
            }
            else
            {
                firma.goods = new();
            }

            DeleteGoodsCommand = new CommandBase(r =>
            {
                
            });

            GetGoodsCommand = new CommandBase(r =>
            {
                //submit goods
                firma.goods.Add(new Goods(_product_Name, _product_Code, _description, _price_Netto, _price_Brutto, _VAT));
            });
        }
    }
}
