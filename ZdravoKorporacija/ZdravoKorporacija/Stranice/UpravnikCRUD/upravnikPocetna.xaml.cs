using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Stranice.DinamickaOpremaCRUD;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Magacin;
using ZdravoKorporacija.Stranice.StatickaOpremaCRUD;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikPocetna.xaml
    /// </summary>
    public partial class upravnikPocetna : Page
    {
        public upravnikPocetna()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new prostorijeStart();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new statickaOpremaStart();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new MagacinStart();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new dinamickaOpremaStart();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Zaposleni(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new ZaposleniPocetna();
        }

        private void button_Click_5(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new LekStart();
        }

        private void renoviraj_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new RenoviranjeStart();
        }

        private void profil(object sender, RoutedEventArgs e)
        {

        }
    }
}