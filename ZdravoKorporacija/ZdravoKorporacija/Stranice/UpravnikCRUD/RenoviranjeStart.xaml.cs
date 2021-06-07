using System.Windows;
using System.Windows.Controls;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for RenoviranjeStart.xaml
    /// </summary>
    public partial class RenoviranjeStart : Page
    {
        public RenoviranjeStart()
        {
            InitializeComponent();
        }

        private void dgZahteviRenoviranja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            Renoviranje r = new Renoviranje(-1);
            r.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
