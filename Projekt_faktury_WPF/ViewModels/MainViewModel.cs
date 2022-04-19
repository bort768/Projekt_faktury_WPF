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
        public ViewModelBase CurrrentViewModel { get; }

        public MainViewModel(Firma firma)
        {
            CurrrentViewModel = new MakeBussinesViewModel(firma);
        }
    }
}
