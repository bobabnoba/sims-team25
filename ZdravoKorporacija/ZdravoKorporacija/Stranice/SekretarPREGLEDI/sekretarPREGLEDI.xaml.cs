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
using Repository;
using Service;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.SekretarCRUD;

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
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        public sekretarPREGLEDI()
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
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniPregledLekar ip = new izmeniPregledLekar((Termin)dgUsers.SelectedItem, termini);
                ip.Show();
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledSekretar zp = new zakaziPregledSekretar(termini, ids);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sekretarStart s = new sekretarStart();

            s.Show();
        }

        private void hitno(object sender, RoutedEventArgs e)
        {
            zakaziHitno zh = new zakaziHitno(termini, ids);
            zh.Show();
        }
    }
}
