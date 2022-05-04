using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.ViewModels
{
    public class AddGoodsViewModel : ViewModelBase
    {

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

        }
    }
}
