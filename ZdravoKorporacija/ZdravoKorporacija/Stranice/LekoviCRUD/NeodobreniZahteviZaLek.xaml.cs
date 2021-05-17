using Controller;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for NeodobreniZahteviZaLek.xaml
    /// </summary>
    public partial class NeodobreniZahteviZaLek : Page
    {
        public NeodobreniZahteviZaLek()
        {
            InitializeComponent();
            NeodobreniLekController neodobreniLekController = new NeodobreniLekController();
            dgNeodobreniLek.ItemsSource = neodobreniLekController.PregledNeodobrenihLekova();
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {

        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void  izmenaAlternativnihLekova(object sender, RoutedEventArgs e)
        {

        }

    }
}
