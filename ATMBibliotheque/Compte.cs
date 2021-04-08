using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBibliotheque
{
    public class Compte

    {
        private int  _numeroNIP; //0 à 65.535.
        private int _numeroCompte; // 0 à 18.446.744.073.709.551.615.
        private double  _SaldoCompte; // -2.147.483.648 a 2.147.483.647
        private int _ratraiteMaximun = 1000; // 0 à 4.294.967.295
        private int _MontantTransferMaximun = 100000; //0 à 4.294.967.295
        

        public int NumeroNIP
        {
            get
            {
                return _numeroNIP;
            }

            set
            {
                _numeroNIP = value;
            }
        }

        public int NumeroCompte
        {
            get
            {
                return _numeroCompte;
            }

            set
            {
                _numeroCompte = value;
            }
        }

        public double SaldoCompte
        {
            get
            {
                return _SaldoCompte;
            }

            set
            {
                _SaldoCompte = value;
            }
        }

        public int RatraiteMaximun
        {
            get
            {
                return _ratraiteMaximun;
            }

            set
            {
                _ratraiteMaximun = value;
            }
        }

        public int MontantTransferMaximun
        {
            get
            {
                return _MontantTransferMaximun;
            }

            set
            {
                _MontantTransferMaximun = value;
            }
        }

        public Compte()
        {

        }
        public Compte(int _numeroNIP, int _numeroCompte, double _SaldoCompte)
        {
            this._numeroNIP = _numeroNIP;
            this._numeroCompte = _numeroCompte;
            this._SaldoCompte = _SaldoCompte;

        }
        public void Retrait(double montant)
        {
          this._SaldoCompte = _SaldoCompte - montant ;
        }
        public void Depot(double montant)
        {
            this._SaldoCompte = _SaldoCompte + montant; 
        }
        public void TranfertVers(double montant)
        {
            this._SaldoCompte = _SaldoCompte - montant;
        }
        public void TranfertDans(double montant)
        {
            this._SaldoCompte = _SaldoCompte + montant;
        }        
    }
} 
