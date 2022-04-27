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
    public class BossDataViewModel : ViewModelBase
    {

        Firma firma = Firma.GetInstance();

        public CommandBase SubmitButtonCommand { get; set; }

        
        

        private string? _name;
        public string  Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string? _last_Name;
        public string Last_Name
        {
            get
            {
                return _last_Name;
            }
            set
            {
                _last_Name = value;
                OnPropertyChanged();
            }
        }

        private string? _ID;
        public  string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                OnPropertyChanged();
            }
        }

        private string? _password;
        

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


        public BossDataViewModel()
        {
            if(firma.BossData != null)
            {
                Name = firma.BossData.Name  ;
                Last_Name = firma.BossData.Last_Name;
                ID = firma.BossData.ID;
                Password = firma.BossData.Password;
            }

            SubmitButtonCommand = new CommandBase(r =>
            {
                BossData bossData = new BossData(Name, Last_Name, ID, Password); // po co?
                MessageBox.Show("Dane zapisane", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                firma.BossData = bossData;
            });
            
        }
    }
}
