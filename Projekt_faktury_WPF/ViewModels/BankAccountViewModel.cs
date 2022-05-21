using Projekt_faktury_WPF.Commands;
using Projekt_faktury_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_faktury_WPF.ViewModels
{
    public class BankAccountViewModel : ViewModelBase
    {

        public CommandBase SubmitCommandButton { get; set; }

        Firma firma = Firma.GetInstance();

        private List<string> _currencyComboBox;
        public List<string> CurrencyComboBox
        {
            get
            {
                return _currencyComboBox;
            }
            set
            {
                _currencyComboBox = value;
                OnPropertyChanged();
            }
        }


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

        //private bool _is_IBAN_Active;
        //public bool Is_IBAN_Activey
        //{
        //    get
        //    {
        //        return _is_IBAN_Active;
        //    }
        //    set
        //    {
        //        _is_IBAN_Active = value;
        //        OnPropertyChanged();
        //    }
        //}

        

        private string _currency;
        public string Currency
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
        public string Value
        {
            get
            {
                return _value.ToString();
            }
            set
            {
                try
                {
                    _value = Convert.ToInt32(value);
                    OnPropertyChanged();
                }
                catch (Exception)
                {
                    MessageBox.Show("UwU watrość nie jest liczbą", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        public BankAccountViewModel()
        {        
            CurrencyComboBox = new List<string>();
            CurrencyComboBox.Add("PLN");
            CurrencyComboBox.Add("UwU");
            CurrencyComboBox.Add("In progress");

            

            if (firma.BankAccount != null)
            {
               BankAccount_Name = firma.BankAccount.BankAccount_Name;
               Account_Number = firma.BankAccount.Account_Number;
               Currency = firma.BankAccount.Currency;
               Value = firma.BankAccount.Value.ToString();
            }
            else
            {
                firma.BankAccount = new("BANK POLSKIEJ SPÓŁDZIELCZOŚCI SA F. w Porębie", "87 1930 1334 1353 2760 2968 7558", "PLN", 740);
            }

            SubmitCommandButton = new(r =>
            {
                if (BankAccount_Name == null)
                {
                    MessageBox.Show("Błąd zapisu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Account_Number == null)
                {
                    MessageBox.Show("Błąd zapisu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                    firma.BankAccount = new BankAccount(_bankAccount_Name, _account_Number, _currency, _value);
                    MessageBox.Show("Dazne zapisane", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }

    }
}
