using ATMBibliotheque;
using System;
using System.Windows;

namespace ATM
{
    /// <summary>
    /// Logique d'interaction pour ATMPrincipal.xaml
    /// </summary>
    public partial class ATMPrincipal : Window
    {
       
        public ATMPrincipal()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "9";
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += "0";
        }

        private void btnPiriood_Click(object sender, RoutedEventArgs e)
        {
            txtEcran.Text += ".";
        }

        private void bubtnSoumettre_Click(object sender, RoutedEventArgs e)
        {
            if ((rbtDepot.IsChecked == false && rbtRetrait.IsChecked == false && rbtTransfert.IsChecked == false && rbtPDF.IsChecked ==false) 
                || (rbtCheques.IsChecked == false && rbtEpargne.IsChecked == false))
            {
                MessageBox.Show("Sélectioner transaction et compte ");
            }
            else
            {
                if (rbtDepot.IsChecked == true)
                {
                    if (rbtCheques.IsChecked == true)
                    {
                        frmLogginATM.clients.DepotCheque(frmLogginATM.numeroNIP, Double.Parse(txtEcran.Text));
                        MessageBox.Show(frmLogginATM.clients.affichSode(frmLogginATM.numeroNIP));
                        txtEcran.Text = string.Empty;
                    }
                    if (rbtEpargne.IsChecked == true)
                    {
                        frmLogginATM.clients.DepotEpargne(frmLogginATM.numeroNIP, Double.Parse(txtEcran.Text));
                        MessageBox.Show(frmLogginATM.clients.affichSode(frmLogginATM.numeroNIP));
                        txtEcran.Text = string.Empty;
                    }

                }
                if (rbtRetrait.IsChecked == true)
                {
                    if (rbtCheques.IsChecked == true)
                    {
                        frmLogginATM.clients.RetaritChreque(frmLogginATM.numeroNIP, Double.Parse(txtEcran.Text));
                        MessageBox.Show(frmLogginATM.clients.affichSode(frmLogginATM.numeroNIP));
                        txtEcran.Text = string.Empty;
                    }
                    if (rbtEpargne.IsChecked == true)
                    {
                        MessageBox.Show("Vous ne pouvez pas retirer de l'argent de ce compte. Vous devez choissir la compte cheque SVP");
                    }

                }
                if (rbtPDF.IsChecked == true)
                {
                    if (rbtCheques.IsChecked == true)
                    {
                        frmLogginATM.clients.PaiementFacture(frmLogginATM.numeroNIP, Double.Parse(txtEcran.Text));
                        MessageBox.Show(frmLogginATM.clients.affichSode(frmLogginATM.numeroNIP));
                        txtEcran.Text = string.Empty;
                    }
                    if (rbtEpargne.IsChecked == true)
                    {
                        MessageBox.Show("Vous devez choissir la compte cheque SVP");
                    }

                }
                
                if (rbtTransfert.IsChecked == true)
                {
                    if (rbtCheques.IsChecked == true)
                    {
                        frmLogginATM.clients.TransferVersCheque(frmLogginATM.numeroNIP, Double.Parse(txtEcran.Text));
                        MessageBox.Show(frmLogginATM.clients.affichSode(frmLogginATM.numeroNIP));
                        txtEcran.Text = string.Empty;
                    }
                    
                }

                if (rbtTransfert.IsChecked == true)
                {
                    if (rbtEpargne.IsChecked == true)
                    {
                        frmLogginATM.clients.TransferVersEpargne(frmLogginATM.numeroNIP, Double.Parse(txtEcran.Text));
                        MessageBox.Show(frmLogginATM.clients.affichSode(frmLogginATM.numeroNIP));
                        txtEcran.Text = string.Empty;
                    }
                }
            }
                     

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void btnFerme_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
