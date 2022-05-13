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
    public class InvoiceViewModel : ViewModelBase
    {
        Firma firma = Firma.GetInstance();

        public CommandBase SubmitInvoiceCommand { get; set; }
        public CommandBase AddGoodToListCommand { get; set; }
        public CommandBase RemoveGoodFromListCommand { get; set; }

        public ObservableCollection<Goods>  List_Of_Added_Goods { get; set; }

        public static int Invoice_Number = 1;

        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                var SelectedItem = from x in List_Of_Added_Goods where(x.IsSelected == true) select x;
                Selected_Goods = (Goods)SelectedItem;



                OnPropertyChanged();
            }
        }

        public string Town { get; set; }

        private string _selected_Item;
        
        public ObservableCollection<Goods> Add_Remove_Goods_List { get; set; } 

        public string Selected_Item
        {
            get
            {
                return _selected_Item;
            }
            set
            {
                int index = 0;
                foreach (var goods in firma.goods)
                {
                    if (goods.Product_Name == value)
                    {
                        SaveToLocal(index);
                        break;
                    }
                    index++;
                }
                _selected_Item = value;
                OnPropertyChanged();
            }
        }

        private Goods _goods;
        public Goods Selected_Goods { get { return _goods; } 
            set 
            {
                _goods = value;
                OnPropertyChanged();
            } }

        public Kontrahent kontrahent { get; set; }

        public DateTime dataWystawienia { get; set; }

        public DateTime dataDostawy { get; set; }

        private string _invoice_Format;
        public string Invoice_format { 
            get 
            { 
                return _invoice_Format;
            } 
            private set 
            {
                _invoice_Format = value;
                OnPropertyChanged();
            } }




        public InvoiceViewModel()
        {
            if (firma.CompanyData != null)
            {
                Town = firma.CompanyData.Town;
            }
            else
            {
                //MessageBox.Show("Dane o firmie nie zostały załadowane", "Bład", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Wypisanie_Invoice_Format();
            dataWystawienia = DateTime.Now;
            dataDostawy = DateTime.Now;

            List_Of_Added_Goods = new();
            Add_Remove_Goods_List = new();

            if (firma.goods != null)
            {
                //Add_Remove_Goods_List = firma.goods;
                foreach (var goods in firma.goods)
                {
                    Add_Remove_Goods_List.Add(goods);
                }
            }


            AddGoodToListCommand = new CommandBase(r =>
            {
                Add_Goods_To_List((Goods)r);
            });

            RemoveGoodFromListCommand = new CommandBase(r => 
            {
                DeleteGoods(r);
            });
            SubmitInvoiceCommand = new CommandBase(r =>
            {
                Invoice_Number++;
                Wypisanie_Invoice_Format();
            });
        }

        

        #region Metody
        private void DeleteGoods(object Product_Code)
        {
            MessageBox.Show($"{Product_Code.ToString}", "Testowo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Add_Goods_To_List(Goods goods_To_Add)
        {
            List_Of_Added_Goods.Add(goods_To_Add);
        }

        private void SaveToLocal(int index)
        {
            Selected_Goods = firma.goods[index];
        }

        private void Wypisanie_Invoice_Format()
        {
            if (firma.DocumentNumbering != null )
            {
                if (firma.DocumentNumbering.Broken_By_Year && firma.DocumentNumbering.Broken_By_Mounth)
                {
                    Invoice_format = $"FS {Invoice_Number}/{DateTime.Today.ToString("MM")}/{DateTime.Today.ToString("yyyy")}";
                }
                else if (firma.DocumentNumbering.Broken_By_Year)
                {
                    Invoice_format = $"FS {Invoice_Number}/{DateTime.Today.ToString("yyyy")}";
                }
                else if (firma.DocumentNumbering.Broken_By_Mounth)
                {
                    Invoice_format = $"FS {Invoice_Number}/{DateTime.Today.ToString("MM")}";
                }
                else
                {
                    Invoice_format = $"FS {Invoice_Number}";
                }
            }
            else
            {
                Invoice_format = $"FS {Invoice_Number}";
            }

        }
        #endregion

    }
}
