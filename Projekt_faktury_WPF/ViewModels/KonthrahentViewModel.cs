using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.ViewModels
{
    public class KonthrahentViewModel : ViewModelBase
    {


        private string _bankAccount_Name;
        public string BankAccount_Name
        {
            get
            {
                return _bankAccount_Name;
            }
            set
            {
                _bankAccount_Name = value;
                OnPropertyChanged();
            }
        }

        private string _account_Number;
        public string Account_Number
        {
            get
            {
                return _account_Number;
            }
            set
            {
                _account_Number = value;
                OnPropertyChanged();
            }
        }

        private string _invoice_format;
        public string Invoice_format
        {
            get
            {
                return _invoice_format;
            }
            set
            {

                _invoice_format = value;
                OnPropertyChanged();
            }
        }

        private string _full_Name;
        public string Full_Name
        {
            get
            {
                return _full_Name;
            }
            set
            {
                _full_Name = value;
                OnPropertyChanged(nameof(Full_Name));
            }
        }

        private string _nIP;
        public string NIP
        {
            get
            {
                return _nIP;
            }
            set
            {
                _nIP = value;
                OnPropertyChanged(nameof(NIP));
            }
        }

        private string _REGON;
        public string REGON
        {
            get
            {
                return _REGON;
            }
            set
            {
                _REGON = value;
                OnPropertyChanged(nameof(REGON));
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        private string _house_Number;
        public string House_Number
        {
            get
            {
                return _house_Number;
            }
            set
            {
                _house_Number = value;
                OnPropertyChanged(nameof(House_Number));
            }
        }

        private string _apartment_Number;
        public string Apartment_Number
        {
            get
            {
                return _apartment_Number;
            }
            set
            {
                _apartment_Number = value;
                OnPropertyChanged(nameof(Apartment_Number));
            }
        }

        private string _ZIP_Code;
        public string ZIP_Code
        {
            get
            {
                return _ZIP_Code;
            }
            set
            {
                _ZIP_Code = value;
                OnPropertyChanged(nameof(ZIP_Code));
            }
        }

        private string _town;
        public string Town
        {
            get
            {
                return _town;
            }
            set
            {
                _town = value;
                OnPropertyChanged(nameof(Town));
            }
        }

        public KonthrahentViewModel()
        {

        }
    }
}
