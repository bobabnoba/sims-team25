using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for ZaposleniPocetna.xaml
    /// </summary>
    public partial class ZaposleniPocetna : Page
    {
        public ZaposleniPocetna()
        {
            InitializeComponent();
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dodajZaposlenog dZ = new dodajZaposlenog();
            dZ.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void dgKorisnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {

        }
    }
}
