using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBibliotheque
{
    public class Cheque: Compte
    {

        private double _fraisPaiementFacture = 1.25; // int -2.147.483.648 a 2.147.483.647
        private double  _montantFactureMaximent = 10000; // int -2.147.483.648 a 2.147.483.647
        public Cheque ()
        {

        }
        public Cheque(int _numeroNIP, int _numeroCompte, double _SaldoCompte): 
            base(_numeroNIP, _numeroCompte, _SaldoCompte  )
        {
            
        }
        public double FraisPaiementFacture
        {
            get
            {
                return _fraisPaiementFacture;
            }

            set
            {
                _fraisPaiementFacture = value;
            }
        }

        public double MontantFactureMaximent
        {
            get
            {
                return _montantFactureMaximent;
            }

            set
            {
                _montantFactureMaximent = value;
            }
        }
        public void PaiementFacture(double montant)
        {
            this.SaldoCompte = this.SaldoCompte-(_fraisPaiementFacture + montant);
                        
        }
    }
 }

