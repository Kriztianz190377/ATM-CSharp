using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBibliotheque
{
    public class Epargne:Compte
    {
        private double tauxIntet = 0.25;

        public Epargne(int _numeroNIP, int _numeroCompte, double _SaldoCompte ) :
            base (_numeroNIP, _numeroCompte, _SaldoCompte)
        {
            
        }

        public double TauxIntet
        {
            get
            {
                return tauxIntet;
            }

            set
            {
                tauxIntet = value;
            }
        }
        public void paimentInteret(double montant)
        {
            SaldoCompte = SaldoCompte-(montant *tauxIntet);
        }
    }
}
