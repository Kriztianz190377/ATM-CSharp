using System;
using System.Windows;
using System.Windows.Controls;
using ATMBibliotheque;

namespace ATM
{
    /// <summary>
    /// Logique d'interaction pour frmLogginATM.xaml
    /// </summary>
    public partial class frmLogginATM : Window
    {
        public static Clients clients = new Clients();
        public static int numeroNIP = 0;

        //bool ouverture = false;
        public frmLogginATM()
        {            
            InitializeComponent();
            try
            {
                clients.CreerListeClients();
                clients.CreerListeCheque();
                clients.CreerListeEpargne();
                txtUtilisateur.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "L'application prendra fin.", "Attention",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
        }

        private void btnEntrer_Click(object sender, RoutedEventArgs e)
        {
            //Récuperatiopn de valeur saisie par l'utilisateur en lettres minuscule.
            string nom = txtUtilisateur.Text.Trim().ToUpper();
            numeroNIP= int.Parse(txtMotPasse.Password.Trim());
            Clients membre = clients.AuthentifierUtilisateur(nom , numeroNIP);
            //Appel de la methode d'autentification

            if(membre != null)
            {
                //Message de bienvenue é l'ut.ilisateur.                
                MessageBox.Show($"Bonjour " + membre.Nom + ".",
                "Bienvenue!", MessageBoxButton.OK, MessageBoxImage.Information);

                //this.Hide();
                ATMPrincipal atm = new ATMPrincipal();
                atm.Show();
                this.Hide();
            }
            //Si les valeur ne sont pas valides.
            else
            {
                MessageBox.Show("Les information saisies ne sont pas valide.", "Attention",
                             MessageBoxButton.OK, MessageBoxImage.Information);
                //nous supprimons le texte saisi dans nos zones de saisie et nous le donons le focus 
                //à TxtClients
                txtUtilisateur.Text = string.Empty;
                txtMotPasse.Password = string.Empty;
                txtUtilisateur.Focus();              
            }
            
        }

        private void btnSortir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmLoggin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //on s'assure que c'est bien l'intention de l'utilisateur de quitter de l'application.
            if (MessageBox.Show("Désirez-vous réllement Quitter de cette application.", "Attention",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
