using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Model
{
    public class Devise
    {
        public int Id { get; set; }

        public String NomDevise { get; set; }

        public double Taux { get; set; }

        public Devise()
        {
        }

        public Devise(int id, string nomDevise, double taux)

        {

            Id = id;

            NomDevise = nomDevise;

            Taux = taux;

        }
    }
}
