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
        private ProstorijaRepozitorijum pRep = new ProstorijaRepozitorijum();
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private PacijentService pacijentiStorage = new PacijentService();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Lekar> slobodniLekari;
        private List<Prostorija> slobodneProstorije;
        private List<Prostorija> prostorije = new List<Prostorija>();

        private Termin p;
        private ObservableCollection<Termin> pregledi;

        private Dictionary<int, int> ids = new Dictionary<int, int>();

        DateTime dateTime = DateTime.Now;
        public zakaziPregledSekretar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            p = new Termin();
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;


            lekari = lekariDat.dobaviSve();
            Lekari.ItemsSource = lekari;

            slobodniLekari = lekari;
            Lekari.ItemsSource = slobodniLekari;
            

            this.ids = ids;
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());

            }

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);







            prostorije = pRep.dobaviSve();
            cbProstorija.ItemsSource = prostorije;

            slobodneProstorije = prostorije;
            cbProstorija.ItemsSource = slobodneProstorije;
            p.Trajanje = 0.5;


            cbPacijent.IsEnabled = false;
            cbProstorija.IsEnabled = false;
            Lekari.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbPacijent.IsEnabled = true;
            cbProstorija.IsEnabled = true;
            Lekari.IsEnabled = true;

            foreach (Termin t in pregledi)
            {
                if (t.Pocetak.Equals(p.Pocetak))
                {
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Jmbg.Equals(t.Lekar.Jmbg))
                        {
                            slobodniLekari.Remove(l);
                            
                        }
                    }
                }
            }

            foreach (Termin t in pregledi)
            {
                if (t.Pocetak.Equals(p.Pocetak))
                {
                    foreach (Prostorija p in prostorije.ToArray())
                    {
                        if (t.prostorija.Id.Equals(p.Id))
                        {
                            slobodneProstorije.Remove(p);
                        }
                    }
                }
            }





        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }
            p.Id = id;
            p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            Pacijent pac = (Pacijent)cbPacijent.SelectedItem;


            p.prostorija = (Prostorija)cbProstorija.SelectedItem;
            p.Lekar = (Lekar)Lekari.SelectedItem;
            if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
                p.hitno = false;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }
            if (pac.ZdravstveniKarton != null)
                p.zdravstveniKarton = pac.ZdravstveniKarton;
            else
            {
                p.zdravstveniKarton = new ZdravstveniKarton(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                pac.ZdravstveniKarton = new ZdravstveniKarton(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
            }

            Termin tZaLekara = new Termin();
            tZaLekara.Id = p.Id;
            p.Lekar.AddTermin(tZaLekara);

            if (ts.ZakaziTermin(p, ids))
            {
                this.pregledi.Add(p);
                lekari = lekariDat.dobaviSve();
                lekariDat.sacuvaj(lekari);

            }
            pac.AddTermin(p);
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
                p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());




         
                
            }
        }
    }
}
