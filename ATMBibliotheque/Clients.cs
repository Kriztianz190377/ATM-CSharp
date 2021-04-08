using System;
using System.IO;
using System.Collections.Generic;
namespace ATMBibliotheque
{
    public class Clients
    {


        List<Clients> clients = new List<Clients>();
        List<Cheque> cheque = new List<Cheque>();
        List<Epargne> epargne = new List<Epargne>();
        public void CreerListeClients()
        {
            string ligne;
            string[] contacte;
            StreamReader lecteur = RecupererClients();

            while ((ligne = lecteur.ReadLine()) != null)
            {
                contacte = ligne.Split(',');
                clients.Add(new Clients(contacte[0], int.Parse(contacte[1])));
            }
            lecteur.Close();
        }

        public void CreerListeCheque()
        {
            string ligne;
            string[] contacte;
            StreamReader lecteur = RecupererCheque();

            while ((ligne = lecteur.ReadLine()) != null)
            {
                contacte = ligne.Split(',');
                cheque.Add(new Cheque(Int32.Parse(contacte[0]), Int32.Parse(contacte[1]), Int32.Parse(contacte[2])));
            }
            lecteur.Close();
        }

        public void CreerListeEpargne()
        {
            string ligne;
            string[] contacte;
            StreamReader lecteur = RecupererEpargne();

            while ((ligne = lecteur.ReadLine()) != null)
            {
                contacte = ligne.Split(',');
                epargne.Add(new Epargne(Int32.Parse(contacte[0]), Int32.Parse(contacte[1]), Int32.Parse(contacte[2])));
            }
            lecteur.Close();
        }

        private string nom;
        private int numeroNIP;
        public Clients()
        {
        }
        public Clients(string nom, int numeroNIP)
        {
            this.Nom = nom;
            this.NumeroNIP = numeroNIP;
        }
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public Clients AuthentifierUtilisateur(string utilisateur, int motPasse)
        {
            foreach (Clients membre in clients)
            {
                //si les variables contient des valeur qu'on attende 
                if (utilisateur == membre.nom && motPasse == membre.numeroNIP)
                {
                    return membre;
                }
            }
            return null;
        }

        public int NumeroNIP
        {
            get
            {
                return numeroNIP;
            }

            set
            {
                numeroNIP = value;
            }
        }
        public bool TransferVersCheque(int NumeroNIP, double montant)
        {
            foreach (Cheque  item in cheque) 
            {
                foreach (Epargne iten in epargne )
                {
                    if((NumeroNIP==item.NumeroNIP) && (NumeroNIP == item.NumeroNIP))
                    {
                        iten.Retrait(montant);
                        item.Depot(montant);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TransferVersEpargne(int NumeroNIP, double montant)
        {
            foreach (Cheque item in cheque)
            {
                foreach (Epargne iten in epargne)
                {
                    if ((NumeroNIP == item.NumeroNIP) && (NumeroNIP == item.NumeroNIP))
                    {
                        iten.Depot(montant);
                        item.Retrait(montant); 
                        return true;
                    }
                }
            }

            return false;
        }
        public bool RetaritChreque(int NumeroNIP, double montant)
        {
            foreach (Cheque item in cheque)
            {
                if (NumeroNIP == item.NumeroNIP)
                {
                    item.Retrait(montant);
                    return true;
                }
            }
            return false;
        }

        public bool DepotCheque(int NumeroNIP, double montant)
        {
            foreach (Cheque item in cheque)
            {
                if (NumeroNIP == item.NumeroNIP)
                {
                    item.Depot(montant);
                    return true;
                }
            }
            return false;
        }

        public bool DepotEpargne(int NumeroNIP, double montant)
        {
            foreach (Epargne item in epargne)
            {
                if (NumeroNIP == item.NumeroNIP)
                {
                    item.Depot(montant);
                    return true;
                }
            }
            return true;
        }

        public bool PaiementFacture(int NumeroNIP, double montant)
        {
            foreach (Cheque item in cheque)
            {
                if (NumeroNIP == item.NumeroNIP)
                {
                    item.PaiementFacture(montant);
                    return true;
                }
            } return false;
        }
        public bool LireClients()
        {
            foreach (Clients item in clients)
            {
                if (Nom == item.Nom)
                {
                    return true;
                }
            }

            return false;
        }






        //public void TransferFonds(int NumeroNIP, double montant, Compte)
        //{

        //}

       

        public StreamReader RecupererClients()
        {
            string nomFichier = "Clients.txt";
            if (!File.Exists(nomFichier))//si le fichier n'existe pas 
            {
                //Levée une erreur avec une message specifique
                throw new Exception($"Le fichier{nomFichier} n'existe pas dans mon répertoir.");
            }
            else //sinon passé ala lecture du fichier
            {
                //création d'un nnouveaux lecteur de flux de données pourle fichier "Utilisateur.txt
                StreamReader lecteur = new StreamReader(nomFichier);
                return lecteur;
            }
        }
        public string affichSode(int nip)
        {
            string solde = "";
            foreach (Cheque item in cheque)
            {
                if (item.NumeroNIP == nip)
                {
                   solde = "solde cheque " +item.SaldoCompte;
                }
            }

            foreach (Epargne item in epargne)
            {
                if (item.NumeroNIP == nip)
                {
                    solde += "solde epargne " + item.SaldoCompte;
                }
            }
            return solde;
        }

        public StreamReader RecupererCheque()
        {
            string nomFichierChe = "Cheque.txt";
            if (!File.Exists(nomFichierChe))//si le fichier n'existe pas 
            {
                //Levée une erreur avec une message specifique
                throw new Exception($"Le fichier{nomFichierChe} n'existe pas dans mon répertoir.");
            }
            else //sinon passé ala lecture du fichier
            {
                //création d'un nnouveaux lecteur de flux de données pourle fichier "Utilisateur.txt
                StreamReader lecteur = new StreamReader(nomFichierChe);
                return lecteur;
            }
        }
        public StreamReader RecupererEpargne()
        {
            string nomFichierEp = "Epargne.txt";
            if (!File.Exists(nomFichierEp))//si le fichier n'existe pas 
            {
                //Levée une erreur avec une message specifique
                throw new Exception($"Le fichier{nomFichierEp} n'existe pas dans mon répertoir.");
            }
            else //sinon passé ala lecture du fichier
            {
                //création d'un nnouveaux lecteur de flux de données pourle fichier "Utilisateur.txt
                StreamReader lecteur = new StreamReader(nomFichierEp);
                return lecteur;
            }
        }
    }
}
