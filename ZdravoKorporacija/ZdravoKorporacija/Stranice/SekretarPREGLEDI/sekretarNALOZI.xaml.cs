using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using ZdravoKorporacija.Stranice.SekretarCRUD;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for sekretarNALOZI.xaml
    /// </summary>
    public partial class sekretarNALOZI : Page

    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();

        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        public sekretarNALOZI()
        {
            
            InitializeComponent();
            PacijentRepozitorijum dat = new PacijentRepozitorijum();
            pacijenti = new ObservableCollection<Pacijent>(dat.dobaviSve());
            foreach (Pacijent p in pacijenti.ToList())
            {
                if (p.Ime.Equals("NEREGISTROVANI"))
                {
                    pacijenti.Remove(p);
                }
            }
            
            dgUsers.ItemsSource = pacijenti;

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());

            this.DataContext = this;
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            kreirajNalogSekretar kn = new kreirajNalogSekretar(pacijenti);
            kn.Show();
        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniNalogSekretar izn = new izmeniNalogSekretar((Pacijent)dgUsers.SelectedItem, pacijenti);
                izn.Show();
            }
        }
        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                obrisiNalogSekretar on = new obrisiNalogSekretar((Pacijent)dgUsers.SelectedItem, pacijenti);
                on.Show();
            }
        }
        private void dodajAlergen(object sender, RoutedEventArgs e)
        {
            dodajAlergen da = new dodajAlergen((Pacijent)dgUsers.SelectedItem);
            da.Show();
        }

        private void pogledaj(object sender, RoutedEventArgs e)
        {
            prikaziKarton pk = new prikaziKarton((Pacijent)dgUsers.SelectedItem);
            pk.Show();
        }
    }
}
