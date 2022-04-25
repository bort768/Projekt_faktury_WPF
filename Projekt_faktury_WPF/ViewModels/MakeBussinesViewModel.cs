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
    public class MakeBussinesViewModel: ViewModelBase
    {
        public CommandBase SubmitCompanyDataCommand { get; set; }
        public CommandBase Invoice_Format_By_Year_Command { get; set; }      
        public CommandBase Invoice_Format_By_Mounth_Command { get; set; }      

        Firma firma = Firma.GetInstance();

        public bool Broken_By_Mounth { get; set; }
        public bool Broken_By_Year { get; set; }


       
        

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
            } set 
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

        //TODO: dodaj sprawdzanie nulla
        public bool ValidateNip(string nip)
        {
            nip = nip.Replace("-", string.Empty);

            if (nip.Length != 10 || nip.Any(chr => !char.IsDigit(chr))) return false;

            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7, 0 };
            int sum = nip.Zip(weights, (digit, weight) => (digit - '0') * weight).Sum();

            return (sum % 11) == (nip[9] - '0');

        }

        public MakeBussinesViewModel()
        {
            if (firma.CompanyData != null)
            {
                Full_Name = firma.CompanyData.Full_Name;
                NIP = firma.CompanyData.NIP;
                REGON = firma.CompanyData.REGON;
                Street = firma.CompanyData.Street;
                House_Number = firma.CompanyData.House_Number;
                ZIP_Code = firma.CompanyData.ZIP_Code;
                Town = firma.CompanyData.Town;
            }

            if (firma.DocumentNumbering != null)
            {
                Broken_By_Mounth = firma.DocumentNumbering.Broken_By_Mounth;
                Broken_By_Year = firma.DocumentNumbering.Broken_By_Year;
                Wypisanie_Invoice_Format();
            }
            else
            {
                Invoice_format = $"FV 1";
            }

            Invoice_Format_By_Year_Command = new(r =>
            {
                if (firma.DocumentNumbering == null)
                {
                    firma.DocumentNumbering = new DocumentNumbering(Broken_By_Mounth, Broken_By_Year);
                }
                
                //Sprawdzanie jak numerować dokument
                if (Broken_By_Year == true)
                {
                    firma.DocumentNumbering.Broken_By_Year = true;
                }
                else
                {          
                    firma.DocumentNumbering.Broken_By_Year = false;
                }

                Wypisanie_Invoice_Format();
            });

            Invoice_Format_By_Mounth_Command = new(r =>
            {
                if (firma.DocumentNumbering == null)
                {
                    firma.DocumentNumbering = new DocumentNumbering(Broken_By_Mounth, Broken_By_Year);
                }
               
                //Sprawdzanie jak numerować dokument
                if (Broken_By_Mounth == true)
                {  
                    firma.DocumentNumbering.Broken_By_Mounth = true;
                }
                else
                {          
                    firma.DocumentNumbering.Broken_By_Mounth = false;
                }

                Wypisanie_Invoice_Format();
            });





            // TODO: dodaj sprawdzanie do nipu
            SubmitCompanyDataCommand = new CommandBase(r =>
            {
                if (ValidateNip(NIP))
                {
                    firma.CompanyData = new CompanyData(Full_Name, NIP, REGON, Street, House_Number, ZIP_Code, Town);
                    MessageBox.Show("Dane zapisane", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("NIP nie prawidłowy", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                  
            });
        }

        private void Wypisanie_Invoice_Format()
        {
            if (Broken_By_Year && Broken_By_Mounth)
            {
                Invoice_format = $"FV 1/{DateTime.Today.ToString("MM")}/{DateTime.Today.ToString("yyyy")}";
            }
            else if (Broken_By_Year)
            {
                Invoice_format = $"FV 1/{DateTime.Today.ToString("yyyy")}";
            }
            else if (Broken_By_Mounth)
            {
                Invoice_format = $"FV 1/{DateTime.Today.ToString("MM")}";
            }
            else
            {
                Invoice_format = $"FV 1";
            }
        }

    }
}
