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
using ZdravoKorporacija.Stranice.PacijentCRUD;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for pacijentStart.xaml
    /// </summary>
    public partial class pacijentStart : Page
    {
        public pacijentStart()
        {
            InitializeComponent();
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            izmeniPregled  ip = new izmeniPregled();
            ip.Show();
        }

     

        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregled zp = new zakaziPregled();
            zp.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            otkaziPregled op = new otkaziPregled();
            op.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
