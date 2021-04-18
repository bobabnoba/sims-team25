using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.SekretarPREGLEDI;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for sekretarStart.xaml
    /// </summary>
    public partial class sekretarStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        
        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        public sekretarStart()
        {
            InitializeComponent();
            PacijentRepozitorijum dat = new PacijentRepozitorijum();
            pacijenti = new ObservableCollection<Pacijent>(dat.dobaviSve());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new sekretarPREGLEDI();
        }
    }
}
