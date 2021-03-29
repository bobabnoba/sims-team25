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

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for lekarStart.xaml
    /// </summary>
    public partial class lekarStart : Page
    {
        public lekarStart()
        {
            InitializeComponent();
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            izmeniPregledLekar ip = new izmeniPregledLekar();
            ip.Show();
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledLekar zp = new zakaziPregledLekar();
            zp.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            oktaziPregledLekar op = new oktaziPregledLekar();
            op.Show();
        }

    }
}
