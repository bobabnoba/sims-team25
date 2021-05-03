using Model;

using Service;

using Repository;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using System.Diagnostics;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for lekarStart.xaml
    /// </summary>
    public partial class lekarStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> terminiSvi = new ObservableCollection<Termin>();
        public static ObservableCollection<Termin> termini = new ObservableCollection<Termin>();

        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();


        private PacijentService pacijentServis = new PacijentService();

        public lekarStart(Lekar lekar)
        {
            InitializeComponent();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();

            terminiSvi = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            foreach(Termin ter in termini)
            {
                Trace.WriteLine(ter.Id);
            }
            foreach(Termin t in terminiSvi)
            {
                if (t.Lekar != null)
                {
                    if (t.Lekar.Jmbg.Equals(lekar.Jmbg))
                    {
                        if (!termini.Contains(t))
                        {
                            Trace.WriteLine("Uso");
                            termini.Add(t);
                        }
                    }
                }
            }
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
            zdravstveniKartonPrikaz zk = new zdravstveniKartonPrikaz((Termin)dgUsers.SelectedItem);
            zk.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        { 
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                oktaziPregledLekar op = new oktaziPregledLekar(termini, (Termin)dgUsers.SelectedItem,ids);
                op.Show();
            }
            

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
