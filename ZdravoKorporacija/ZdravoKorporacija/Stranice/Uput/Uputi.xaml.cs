using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for Uputi.xaml
    /// </summary>
    public partial class Uputi : Window
    {
        private TerminService storage = new TerminService();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private PacijentService pacijentServis = new PacijentService();

        public Uputi()
        {
            InitializeComponent();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();
            dgUsers.ItemsSource = lekarStart.uputi;
            this.DataContext = this;
        }

        private void izmeniUput(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                izmeniUput iu = new izmeniUput((Termin)dgUsers.SelectedItem, lekarStart.uputi);
                iu.Show();
            }
        }

        private void izdajUput(object sender, RoutedEventArgs e)
        {
            izdajUput iu = new izdajUput(lekarStart.uputi, ids);
            iu.Show();
        }

        private void prikaziKarton(object sender, RoutedEventArgs e)
        {
            zdravstveniKartonPrikaz zk = new zdravstveniKartonPrikaz((Termin)dgUsers.SelectedItem);
            zk.Show();
        }

        private void otkaziUput(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                otkaziUput ou = new otkaziUput(lekarStart.uputi, (Termin)dgUsers.SelectedItem, ids);
                ou.Show();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            pregledPacijenata pp = new pregledPacijenata();
            this.Close();
            pp.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            lekarStart ls = new lekarStart();
            ls.Show();
            this.Close();
        }

        private void zakaziHitno(object sender, RoutedEventArgs e)
        {
            zakaziHitniLekar zh = new zakaziHitniLekar(lekarStart.uputi, ids);
            zh.Show();
        }
    }
}


