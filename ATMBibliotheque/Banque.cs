using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBibliotheque
{
    public class Banque : Compte
    {

        private int _montantMaximun;
        private int _montantRemplisage;


        public Banque()
        {

        }
        public Banque(int _montantMaximun, int _montantRemplisage, int _numeroNIP,
            int _numeroCompte, int _SaldoCompte, int _ratraiteMaximon, int _MontantTransferMaximun) :
            base(_numeroNIP, _numeroCompte, _SaldoCompte)
        {
            this._montantMaximun = _montantMaximun;
            this._montantRemplisage = _montantRemplisage;
        }
        
        

        public int MontantMaximun
        {
            get
            {
                return _montantMaximun;
            }

            set
            {
                _montantMaximun = value;
            }
        }

        public int MontantRemplisage
        {
            get
            {
                return _montantRemplisage;
            }

            set
            {
                _montantRemplisage = value;
            }
        }
    }
}
