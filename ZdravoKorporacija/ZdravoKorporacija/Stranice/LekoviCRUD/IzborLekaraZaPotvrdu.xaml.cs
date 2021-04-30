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

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for IzborLekaraZaPotvrdu.xaml
    /// </summary>
    public partial class IzborLekaraZaPotvrdu : Window
    {
        public IzborLekaraZaPotvrdu()
        {
            InitializeComponent();
        }

        private void dgLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgIzabraniLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
