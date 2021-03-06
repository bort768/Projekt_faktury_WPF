using Projekt_faktury_WPF.Commands;
using Projekt_faktury_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_faktury_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public CommandBase BossDataCommand { get; set; }
        public CommandBase MakeBussinesCommand { get; set; }
        public CommandBase BankAccountCommand { get; set; }
        public CommandBase KontrahenciCommand { get; set; }
        public CommandBase AddGoodsCommand { get; set; }
        public CommandBase InvoiceCommand { get; set; }

        //public ViewModelBase CurrrentViewModel { get; }

        public BossDataViewModel BossDataViewModel { get; }
        public MakeBussinesViewModel MakeBussinesViewModel { get; }
        public BankAccountViewModel BankAccountViewModel { get; }
        public KonthrahentViewModel KonthrahentViewModel { get; }
        public AddGoodsViewModel AddGoodsViewModel { get; }
        public InvoiceViewModel InvoiceViewModel { get; }

        private object _currentView;

        public object CurrentView 
        { get  { return _currentView; } 
          set 
            {
                _currentView = value;
                OnPropertyChanged();          
            }
        }

        public MainViewModel()
        {
            //CurrrentViewModel = new MakeBussinesViewModel(firma);

            BossDataViewModel = new BossDataViewModel();
            MakeBussinesViewModel = new MakeBussinesViewModel();
            BankAccountViewModel = new BankAccountViewModel();
            KonthrahentViewModel = new KonthrahentViewModel();
            AddGoodsViewModel = new AddGoodsViewModel();
            InvoiceViewModel = new InvoiceViewModel();

            CurrentView = MakeBussinesViewModel;

            BossDataCommand = new CommandBase(r =>
            {
                CurrentView = BossDataViewModel;
            });

            MakeBussinesCommand = new CommandBase(r =>
            {
                CurrentView = MakeBussinesViewModel;
            });

            BankAccountCommand = new CommandBase(r =>
            {
                CurrentView = BankAccountViewModel;
            });

            KontrahenciCommand = new CommandBase(r =>
            {
                CurrentView = KonthrahentViewModel;
            });

            AddGoodsCommand = new CommandBase(r => 
            { 
                CurrentView = AddGoodsViewModel; 
            });

            InvoiceCommand = new CommandBase(r =>
            {
                CurrentView = InvoiceViewModel;
            });

        }
    }
}
