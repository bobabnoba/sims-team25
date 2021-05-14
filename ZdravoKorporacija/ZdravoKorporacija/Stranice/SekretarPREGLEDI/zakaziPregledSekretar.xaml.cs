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
using System.Windows.Shapes;
using Model;
using Repository;
using Service;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for zakaziPregledSekretar.xaml
    /// </summary>
    public partial class zakaziPregledSekretar : Window
    {
        private TerminService ts = new TerminService();

        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private ProstorijaRepozitorijum pRep = ProstorijaRepozitorijum.Instance;
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private PacijentService pacijentiStorage = new PacijentService();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Lekar> slobodniLekari;
        private ObservableCollection<Prostorija> slobodneProstorije;
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();
        private ObservableCollection<Termin> pregledi;

        private int idTermina;
        private TipTerminaEnum tipTermina;
        private DateTime pocetakTermina;
        private Lekar lekarTermina;
        private ZdravstveniKarton kartonTermina;
        private Prostorija prostorijaTermina;

        private Termin noviTermin;
       

        private Dictionary<int, int> ids = new Dictionary<int, int>();

        DateTime dateTime = DateTime.Now;
        public zakaziPregledSekretar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            noviTermin = new Termin();
            pregledi = termini;

            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;

            lekari = lekariDat.dobaviSve();
            Lekari.ItemsSource = lekari;

            slobodniLekari = lekari;
            Lekari.ItemsSource = slobodniLekari;

            prostorije = pRep.dobaviSve();
            cbProstorija.ItemsSource = prostorije;

            slobodneProstorije = prostorije;
            cbProstorija.ItemsSource = slobodneProstorije;

            this.ids = ids;
            DateTime danas = DateTime.Today;
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);

            cbPacijent.IsEnabled = false;
            cbProstorija.IsEnabled = false;
            Lekari.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbPacijent.IsEnabled = true;
            cbProstorija.IsEnabled = true;
            Lekari.IsEnabled = true;

            slobodniLekari      = ts.DobaviSlobodneLekare(lekari, pregledi, pocetakTermina);

            slobodneProstorije = ts.DobaviSlobodneProstorije(prostorije, pregledi, noviTermin);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = ts.MapaTermina(ids);
            Pacijent pac = (Pacijent)cbPacijent.SelectedItem;


            idTermina = id;
            pocetakTermina      = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            prostorijaTermina   = (Prostorija)cbProstorija.SelectedItem;
            lekarTermina        = (Lekar)Lekari.SelectedItem;
            kartonTermina       = ts.ProveriKartonKodZakazivanja(pac);
            if (cbTip.SelectedIndex == 0)            
                tipTermina      = TipTerminaEnum.Pregled;            
            else if (cbTip.SelectedIndex == 1)            
                tipTermina      = TipTerminaEnum.Operacija;

            noviTermin   = ts.InicijalizujTermin(idTermina, tipTermina, pocetakTermina, pac, lekarTermina, prostorijaTermina);

            ts.InicijalizujTerminLekaru(noviTermin);

            if (ts.ZakaziTermin(noviTermin, ids))
            {
                this.pregledi.Add(noviTermin);
                lekari = lekariDat.dobaviSve();
                lekariDat.sacuvaj(lekari);
            }
            pac.AddTermin(noviTermin);
            pacijentiStorage.AzurirajPacijenta(pac);
            this.Close();
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void time_changed(object sender, SelectionChangedEventArgs e)
        {
            if (time.SelectedIndex != -1)
            {
                pocetakTermina = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            }
        }
    }
}
