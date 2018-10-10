using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);

        }

        private async void ActionGetData()
        {
            try
            {
                var result = await WSService.GetInstance().GetAllDeviseAsync();
                this.ComboBoxDevises = new ObservableCollection<Devise>(result);
            }
            catch (Exception e)
            {
                MessageDialog dialog = new MessageDialog("Une erreur est survenu en essayant de recupérer les données du serveur");
                await dialog.ShowAsync();
            }
          
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

        public ICommand BtnSetConversion { get; private set; }

        private async void ActionSetConversion()
        {
            double value = 0;
            bool success = double.TryParse(MontantDevise, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
            if (!success)
            {
                MessageDialog dialog = new MessageDialog("Montant non valide !");
                await dialog.ShowAsync();
            }
            else if (ComboBoxDeviseItem == null)
            {
                MessageDialog dialog = new MessageDialog("Aucune devise sélectionnée !");
                await dialog.ShowAsync();
            }
            else
            {
                value = value * (ComboBoxDeviseItem as Devise).Taux;
            }

            ConvertedValue = value;
        }

        private string _montantDevises;
        public string MontantDevise {
            get {
                return _montantDevises;
            }
            set {
                _montantDevises = value;
                RaisePropertyChanged();
            }
        }

        private Devise _comboBoxDeviseItem;
        public Devise ComboBoxDeviseItem
        {
            get
            {
                return _comboBoxDeviseItem;
            }
            set
            {
                _comboBoxDeviseItem = value;
                RaisePropertyChanged();
            }
        }

        private double _convertedValue;
        public double ConvertedValue
        {
            get
            {
                return _convertedValue;
            }
            set
            {
                _convertedValue = value;
                RaisePropertyChanged();
            }
        }

    }
}
