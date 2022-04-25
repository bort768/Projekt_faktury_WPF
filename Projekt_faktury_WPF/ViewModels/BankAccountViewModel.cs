using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.ViewModels
{
    public class BankAccountViewModel : ViewModelBase
    {
       

        private string _bankAccount;
        public string BankAccount
        {
            get
            {
                return _bankAccount;
            }
            set
            {
                _bankAccount = value;
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

        private bool _is_IBAN_Active;
        public bool Is_IBAN_Activey
        {
            get
            {
                return _is_IBAN_Active;
            }
            set
            {
                _is_IBAN_Active = value;
                OnPropertyChanged();
            }
        }

        private int _currency;
        public int Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                OnPropertyChanged();
            }
        }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public BankAccountViewModel()
        {
                
        }

    }
}
