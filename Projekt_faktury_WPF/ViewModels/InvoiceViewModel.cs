using Projekt_faktury_WPF.Commands;
using Projekt_faktury_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Data;
using Projekt_faktury_WPF.Helper;
using Projekt_faktury_WPF.Interface;

namespace Projekt_faktury_WPF.ViewModels
{
    public class InvoiceViewModel : ViewModelBase
    {
        Firma firma = Firma.GetInstance();

        ISaveToFile MetodOfSave;

        public CommandBase SubmitInvoiceCommand { get; set; }
        public CommandBase AddGoodToListCommand { get; set; }
        public CommandBase RemoveGoodFromListCommand { get; set; }
        public CommandBase EditGoodToListCommand { get; set; }

        public ObservableCollection<Goods>  List_Of_Added_Goods { get; set; }
        public ObservableCollection<Kontrahent>  List_Of_Kontrahents { get; set; }
        public ObservableCollection<Goods> Add_Remove_Goods_List { get; set; }

        private Kontrahent _selected_Kontrahent;
        public Kontrahent Selected_Kontrahent
        {
            get 
            {
                return _selected_Kontrahent; 
            }
            set 
            {
                _selected_Kontrahent = value;
                OnPropertyChanged();
            }
        }

        public CompanyData companyData { get; set; }  

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

        private int _quantity = 1;
        public string Quantity
        {
            get
            {
                return _quantity.ToString();
            }
            set
            {
               if (value != null && value != "")
                {
                    _quantity = Convert.ToInt32(value!);
                    if (Selected_Goods != null)
                    {
                        Selected_Goods.Quantity = _quantity;
                        Selected_Goods.Sum = (_quantity * Selected_Goods.Price_Brutto);
                    }
                    
                }

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
      

        private DateTime _dataWystawienia = DateTime.Now;
        public DateTime DataWystawienia
        {
            get
            {
                return _dataWystawienia;
            }
            set
            {
                _dataWystawienia = value;
                Wypisanie_Invoice_Format();
                OnPropertyChanged();
            }
        }

        private DateTime _dataDostawy = DateTime.Now;
        public DateTime DataDostawy
        {
            get
            {
                return _dataDostawy;
            }
            set
            {
                _dataDostawy = value;
                OnPropertyChanged();
            }
        }

        

        private string _invoice_Format;
        

        public string Invoice_format { 
            get 
            { 
                return _invoice_Format;
            } 
            set 
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
            
            if (firma.CompanyData != null)
            {
                companyData = firma.CompanyData;
            }
            
            List_Of_Added_Goods = new();

            //dodawanie i towrzenie listy kontrahentów do comobobox
            List_Of_Kontrahents = new();
            foreach (var kontrahent in firma.kontrahents!)
            {
                List_Of_Kontrahents.Add(kontrahent);
            }

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

            EditGoodToListCommand = new CommandBase(r => { Edit_Goods_To_List((Goods)r); }); // zmien tu trochę

            RemoveGoodFromListCommand = new CommandBase(r => 
            {
                DeleteGoods((Goods)r);
            });
            SubmitInvoiceCommand = new CommandBase(r =>
            {
                MetodOfSave = new InvoicePdfCreate(firma.DocumentNumbering, Selected_Kontrahent, firma.CompanyData!, firma.BossData, firma.BankAccount,
                    List_Of_Added_Goods.ToList(), DataWystawienia, Invoice_format, Invoice_Number);
                MetodOfSave.SaveToFile();
                Invoice_Number++;
                Wypisanie_Invoice_Format();
            });
        }






        #region Metody
        private void DeleteGoods(Goods goods_To_Remove)
        {
            //MessageBox.Show($"{Product_Code.ToString}", "Testowo", MessageBoxButton.OK, MessageBoxImage.Information);

            List_Of_Added_Goods.Remove(goods_To_Remove);
        }

        private void Edit_Goods_To_List(Goods goods_To_Edit)
        {
            var find_Item = List_Of_Added_Goods.Where(r => r.Product_Code == goods_To_Edit.Product_Code);
            foreach (var item in find_Item)
            {
                List_Of_Added_Goods.Remove(item);
            }
            
            
        }

        private void Add_Goods_To_List(Goods goods_To_Add)
        {

            if (Selected_Goods != null)
            {
                Selected_Goods.Quantity = _quantity;
                Selected_Goods.Sum = (_quantity * Selected_Goods.Price_Brutto);
                List_Of_Added_Goods.Add(goods_To_Add);
            }
            else
            {
                MessageBox.Show($"Nie wybrano towaru lub usługi", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
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
                    Invoice_format = $"FS {Invoice_Number}/{DataWystawienia.ToString("MM")}/{DataWystawienia.ToString("yyyy")}";
                }
                else if (firma.DocumentNumbering.Broken_By_Year)
                {
                    Invoice_format = $"FS {Invoice_Number}/{DataWystawienia.ToString("yyyy")}";
                }
                else if (firma.DocumentNumbering.Broken_By_Mounth)
                {
                    Invoice_format = $"FS {Invoice_Number}/{DataWystawienia.ToString("MM")}";
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
