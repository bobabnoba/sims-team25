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


            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());

            this.DataContext = this;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fr.Content = new sekretarNALOZI();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fr.Content = new sekretarPREGLEDI();
        }
    }
}
