using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for lekarStart.xaml
    /// </summary>
    public partial class lekarStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();

        public lekarStart()
        {
            InitializeComponent();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            dgUsers.ItemsSource = termini;
            this.DataContext = this;
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                izmeniPregledLekar ip = new izmeniPregledLekar((Termin)dgUsers.SelectedItem, termini);
                ip.Show();
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledLekar zp = new zakaziPregledLekar(termini, ids);
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

            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da otkažete.", "Greška");
            else
            {
                oktaziPregledLekar op = new oktaziPregledLekar(termini, (Termin)dgUsers.SelectedItem, ids); 
                op.Show();
            }

           
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
