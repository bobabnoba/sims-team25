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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikStart.xaml
    /// </summary>
    public partial class upravnikStart : Page
    {
        public upravnikStart()
        {
            InitializeComponent();
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dodajProstorijuUpravnik dp = new dodajProstorijuUpravnik();
            dp.Show();
        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            izmeniProstorijuUpravnik ip = new izmeniProstorijuUpravnik();
            ip.Show();
        }
        private void izbrisi(object sender, RoutedEventArgs e)
        {
            izbrisiProstorijuUpravnik ip = new izbrisiProstorijuUpravnik();
            ip.Show();
        }
    }
}
