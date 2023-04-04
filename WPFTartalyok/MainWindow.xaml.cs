using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Osztályok;

namespace WPFTartalyok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        public MainWindow()
        {
            InitializeComponent();
            rdoTeglatest.IsChecked = true;
        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = false;
            txtAel.Text = "10";
            txtBel.IsEnabled = false;
            txtBel.Text = "10";
            txtCel.IsEnabled = false;
            txtCel.Text = "10";
        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.Text = "";
            txtBel.Text = "";
            txtCel.Text = "";
            txtAel.IsEnabled = true;
            txtBel.IsEnabled = true;
            txtCel.IsEnabled = true;
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            Tartaly ujTartaly = null;
            if (rdoTeglatest.IsChecked == true)
            {
                if (txtAel.Text == "" || txtBel.Text == "" || txtCel.Text == "")
                {
                    MessageBox.Show("Hiányzó oldalhossz! Kérlek add meg mindet!");
                }
                else
                {
                    ujTartaly = new Tartaly(txtNev.Text, int.Parse(txtAel.Text), int.Parse(txtBel.Text), int.Parse(txtCel.Text));
                }
            }
            else if (rdoKocka.IsChecked == true)
            {
                ujTartaly = new Tartaly(txtNev.Text);
            }

            if (txtNev.Text != "")
            {
                lbTartalyok.Items.Add(ujTartaly.Info());
                tartalyok.Add(ujTartaly);
            }
            else
            {
                MessageBox.Show("Nem adott a tartálynak nevet!");
            }
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kiválaszott tartály");
                return;
            }
            else
            {
                tartalyok[lbTartalyok.SelectedIndex].TeljesLeengedes();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
                lbTartalyok.Items.Refresh();
            }
        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kiválaszott tartály");
                return;
            }
            else
            {
                tartalyok[lbTartalyok.SelectedIndex].DuplazMeretet();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
                lbTartalyok.Items.Refresh();
            }
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs kiválaszott tartály");
                return;
            }
            else
            {
                tartalyok[lbTartalyok.SelectedIndex].Tolt(double.Parse(txtMennyitTolt.Text));
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
                lbTartalyok.Items.Refresh();
            }
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("tartalyok.csv");
            sw.Close();
        }
    }
}
