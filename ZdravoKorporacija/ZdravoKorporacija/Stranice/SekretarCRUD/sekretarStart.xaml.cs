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

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for sekretarStart.xaml
    /// </summary>
    public partial class sekretarStart : Page
    {
        public sekretarStart()
        {
            InitializeComponent();
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            kreirajNalogSekretar kn = new kreirajNalogSekretar();
            kn.Show();
        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            izmeniNalogSekretar izn = new izmeniNalogSekretar();
            izn.Show();
        }
        private void izbrisi(object sender, RoutedEventArgs e)
        {
            obrisiNalogSekretar on = new obrisiNalogSekretar();
            on.Show();
        }
    }
}
