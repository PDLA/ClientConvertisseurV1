using ClientConvertisseurV1.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ClientConvertisseurV1.Controller
{
    class ConvertisseurController
    {

        private static ConvertisseurController _instance;

        public Devise SelectedDevise { get; set; }

        public string Montant { get; set; }
 

        private ConvertisseurController()
        {

        }

        public static ConvertisseurController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConvertisseurController();
            }
            return _instance;
        }

        public async Task<double> Convert()
        {
            double value = 0;
            bool success = double.TryParse(Montant, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
            if (!success)
            {
                //Probleme de dialog appelé en dehors d'une page
                //MessageDialog dialog = new MessageDialog("Montant non valide !");
                //await dialog.ShowAsync();
            }
            else if(SelectedDevise == null)
            {
                //Probleme de dialog appelé en dehors d'une page
                //MessageDialog dialog = new MessageDialog("Aucune devise sélectionnée !");
                //await dialog.ShowAsync();
            }
            else
            {
                value = value * SelectedDevise.Taux;
            }
            return value;
        }



    }
}
