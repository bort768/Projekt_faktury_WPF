using Projekt_faktury_WPF.Commands;
using Projekt_faktury_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_faktury_WPF.ViewModels
{
    public class KonthrahentViewModel : ViewModelBase
    {
        public CommandBase SubmitKontrahent { get; set; }
        public CommandBase DeleteKontrahent { get; set; }

        CompanyData company;
        Kontrahent kontrahent;

        Firma firma = Firma.GetInstance();

        private string _lastVisetedKontrahent;
        public string LastVisetedKontrahent
        {
            get
            {
                return _lastVisetedKontrahent;
            }
            set
            {
                _lastVisetedKontrahent = value;
                int index = 0;
                foreach (var kontrahent in firma.kontrahents)
                {
                    if (kontrahent.Company.Full_Name == value)
                    {
                        SaveToLocal(index);
                    }
                    index++;
                }
                OnPropertyChanged();
            }
        }

        
        //private ObservableCollection<string> _listaDoCombobox;
        public ObservableCollection<string> listaDoCombobox { get; set; }
        
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
            if (firma.kontrahents != null)
            {
                int index = 0;
                foreach (var kontrahent in firma.kontrahents)
                {
                    if (kontrahent.Company.Full_Name == _lastVisetedKontrahent)
                    {
                        SaveToLocal(index);
                    }                    
                    index++;
                }
                

                listaDoCombobox = new();

                //średnia optymalizcja jeśli chodzi o wieksze tabele
                foreach (var item in firma.kontrahents)
                {
                    listaDoCombobox.Add(item.Company.Full_Name);
                }

            }
            else
            {
                listaDoCombobox = new();

                firma.kontrahents = new();
                firma.kontrahents.Add(new Kontrahent("BPK Oddział III w Brzozowie", "15 0011 0018 9123 3456 4567 8912",
                    new CompanyData("Dom Towarowy „KROS” SA", "117-00-88-765", "986674453", "Brzozowska", "56", "36-200", "Brzozów")));

                firma.kontrahents.Add(new Kontrahent("BT Oddział w Brzozowie", "19 0000 1245 6778 9189 1223 3456",
                    new CompanyData("Dom Handlowy „Mrówka” sp. z.o.o.", "823 12 20 711", "74185296", "Obwodowa", "2", "36-200", "Brzozów"))); 

            }
          
                
            
            SubmitKontrahent = new CommandBase(r =>
            {
                company = new(_full_Name, _nIP, _REGON, _street, _house_Number, _ZIP_Code, _town);
                kontrahent = new(BankAccount_Name, Account_Number, company);
                AddToKontrahents();
                LastVisetedKontrahent = _full_Name;
                listaDoCombobox.Add(_full_Name);
            });
            DeleteKontrahent = new CommandBase(r =>
            {
                RemoveFromKontrahents();
            });
        }

        private void SaveToLocal(int index)
        {
            BankAccount_Name = firma.kontrahents[index].BankAccount_Name;
            Account_Number = firma.kontrahents[index].Account_Number;
            Full_Name = firma.kontrahents[index].Company.Full_Name;
            NIP = firma.kontrahents[index].Company.NIP;
            REGON = firma.kontrahents[index].Company.REGON;
            Street = firma.kontrahents[index].Company.Street;
            House_Number = firma.kontrahents[index].Company.House_Number;
            Town = firma.kontrahents[index].Company.Town;
            ZIP_Code = firma.kontrahents[index].Company.ZIP_Code;

            //zrób kontrahenta do usuwania go
            company = new(_full_Name, _nIP, _REGON, _street, _house_Number, _ZIP_Code, _town);
            kontrahent = new(BankAccount_Name, Account_Number, company);
        }

        private void RemoveFromKontrahents()
        {
            if (firma.kontrahents == null)
            {
                MessageBox.Show("Dane nie zostały usunięte", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //To do naprawić to :) Kiedyś
            else if (firma.kontrahents.Contains(kontrahent))
            {
                firma.kontrahents.Remove(kontrahent);
            }
            else
            {
                MessageBox.Show("Dane nie zostały usunięte", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void AddToKontrahents()
        {
            if (kontrahent == null)
            {
                MessageBox.Show("Dane nie zostały zapisane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (firma.kontrahents == null)
            {
                firma.kontrahents = new();
                firma.kontrahents.Add(kontrahent);
                MessageBox.Show("Dane zapisane pomyślne", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!firma.kontrahents.Contains(kontrahent))
            {
                firma.kontrahents.Add(kontrahent);
                MessageBox.Show("Dane zapisane pomyślne", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information );
            }
            else
            {
                MessageBox.Show("Dane już istnieją", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
