using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() {
            ActionGetData();
        }

        private async void ActionGetData() {
            var result = await WSService.GetInstance().GetAllDeviseAsync();
            this.ComboBoxDevises = new ObservableCollection<Devise>(result);
        }

        private ObservableCollection<Devise> _comboBoxDevises;
        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return _comboBoxDevises; }
            set
            {
                _comboBoxDevises = value;
                RaisePropertyChanged(); // Pour notifier de la modification de ses données            
            }
        } 
   }
}
