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
<<<<<<< HEAD
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();

=======
        private PacijentService pacijentServis = new PacijentService();
>>>>>>> prikazpacijenta
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

        private void prikaziKarton(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
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

           
=======
            zdravstveniKartonPrikaz zk = new zdravstveniKartonPrikaz((Termin)dgUsers.SelectedItem);
            zk.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        { 
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                oktaziPregledLekar op = new oktaziPregledLekar(termini, (Termin)dgUsers.SelectedItem);
                op.Show();
            }
            
>>>>>>> prikazpacijenta
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            pregledPacijenata pp = new pregledPacijenata();
            this.Close();
            pp.Show();
        }
    }
}
