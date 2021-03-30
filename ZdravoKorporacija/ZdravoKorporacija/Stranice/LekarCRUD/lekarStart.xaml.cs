using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for lekarStart.xaml
    /// </summary>
    public partial class lekarStart : Page
    {
        private TerminFileStorage storage = new TerminFileStorage();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        public lekarStart()
        {
            InitializeComponent();

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            dgUsers.ItemsSource = termini;
            this.DataContext = this;
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            izmeniPregledLekar ip = new izmeniPregledLekar((Termin)dgUsers.SelectedItem, termini);
            ip.Show();
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledLekar zp = new zakaziPregledLekar(termini);
            zp.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete ovaj termin?", "Potvrda brisanja", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    storage.OtkaziTermin((Termin)dgUsers.SelectedItem);
                    termini.Remove((Termin)dgUsers.SelectedItem);
                }
            }
            //  oktaziPregledLekar op = new oktaziPregledLekar();
            //op.Show();
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
