using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.PacijentCRUD;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for pacijentStart.xaml
    /// </summary>
    public partial class pacijentStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        public pacijentStart()
        {
            InitializeComponent();

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            dgUsers.ItemsSource = termini;
            this.DataContext = this;

            //Pacijent p1 = new Pacijent("Dusan", "Lekic");
            //Pacijent p2 = new Pacijent("Aleksa", "Papovic");
            //pacijenti.Add(p1);
            // pacijenti.Add(p2);
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniPregled ip = new izmeniPregled((Termin)dgUsers.SelectedItem, termini);
                ip.Show();
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregled zp = new zakaziPregled(termini);
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
                }
            }*/

            otkaziPregled op = new otkaziPregled(termini, (Termin)dgUsers.SelectedItem);
            op.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

     
    }
}
