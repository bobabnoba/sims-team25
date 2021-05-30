using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for Uputi.xaml
    /// </summary>
    public partial class Uputi : Page
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
                //izmeniUput iu = new izmeniUput((Termin)dgUsers.SelectedItem, lekarStart.uputi);
                //iu.Show();
                test.prozor.Content = new izmeniUput((TerminDTO)dgUsers.SelectedItem, lekarStart.uputi);
            }
        }

        private void izdajUput(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new izdajUput(lekarStart.uputi, ids);
        }

        private void prikaziKarton(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new zdravstveniKartonPrikaz((TerminDTO)dgUsers.SelectedItem);
        }

        private void otkaziUput(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {

                otkaziUput ou = new otkaziUput(lekarStart.uputi, (TerminDTO)dgUsers.SelectedItem, ids);
                ou.Show();
                //otkaziUput ou = new otkaziUput(lekarStart.uputi, (Termin)dgUsers.SelectedItem, ids);
                //ou.Show();
            }
        }

       

        private void zakaziHitno(object sender, RoutedEventArgs e)
        {
            //zakaziHitniLekar zh = new zakaziHitniLekar(lekarStart.uputi, ids);
            //zh.Show();
            test.prozor.Content = new zakaziHitniLekar(lekarStart.uputi, ids);
        }

    }
}


