﻿using Projekt_faktury_WPF.Commands;
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

        //public ViewModelBase CurrrentViewModel { get; }

        public BossDataViewModel BossDataViewModel { get; }

        public MakeBussinesViewModel MakeBussinesViewModel { get; }

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

            CurrentView = BossDataViewModel;

            BossDataCommand = new CommandBase(r =>
            {
                CurrentView = BossDataViewModel;
            });

            MakeBussinesCommand = new CommandBase(r =>
            {
                CurrentView = MakeBussinesViewModel;
            });
        }
    }
}
