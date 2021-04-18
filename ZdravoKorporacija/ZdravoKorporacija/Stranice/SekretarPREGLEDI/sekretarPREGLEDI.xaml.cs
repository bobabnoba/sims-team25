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
using Model;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for sekretarPREGLEDI.xaml
    /// </summary>
    public partial class sekretarPREGLEDI : Page
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        public sekretarPREGLEDI()
        {
            InitializeComponent();

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            dgUsers.ItemsSource = termini;
            this.DataContext = this;
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniPregledLekar ip = new izmeniPregledLekar((Termin)dgUsers.SelectedItem, termini);
                ip.Show();
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledLekar zp = new zakaziPregledLekar(termini);
            zp.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            /*  if (dgUsers.SelectedItem == null)
                  MessageBox.Show("Niste selektovali red", "Greska");
              else
              {
                  if (dgUsers.SelectedItem != null)
                  {
                      MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete ovaj termin?", "Potvrda brisanja", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes)
                      {
                          pac.RemoveTermin((Termin)dgUsers.SelectedItem);
                          storagePacijent.AzurirajPacijenta(pac);
                          storage.OtkaziTermin((Termin)dgUsers.SelectedItem);
                          termini.Remove((Termin)dgUsers.SelectedItem);
                      }
                  }*/
            oktaziPregledLekar op = new oktaziPregledLekar(termini, (Termin)dgUsers.SelectedItem);
            // otkaziPregledLekar op = new otkaziPregledLekar(termini, (Termin)dgUsers.SelectedItem);
            op.Show();

        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
