using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zakaziPregledLekar.xaml
    /// </summary>
    public partial class zakaziPregledLekar : Window
    {
        private TerminService storage = new TerminService();
        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private PacijentService pacijentiStorage = new PacijentService();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private Termin p;
        private ObservableCollection<Termin> pregledi;
<<<<<<< HEAD
        private Dictionary<int, int> ids = new Dictionary<int, int>();
=======
        DateTime dateTime = DateTime.Now;
>>>>>>> prikazpacijenta


        public zakaziPregledLekar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            p = new Termin();
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;
<<<<<<< HEAD
            this.ids = ids;

=======
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);
>>>>>>> prikazpacijenta

            lekari = lekariDat.dobaviSve();
            Lekari.ItemsSource = lekari;

            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            p.Trajanje = 0.5;
            //p.Id = pregledi.Count + 1;

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
            Pacijent pac = (Pacijent)cbPacijent.SelectedItem;
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            
            String d = date.Text;
            String t = null;
            if (cboItem != null)
            {

                t = cboItem.Content.ToString();

            }
            try
            {
                p.Pocetak = DateTime.Parse(d + " " + t);
            }
            catch(InvalidCastException ex)
            { }
                    if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }

            p.prostorija = (Prostorija)cbProstorija.SelectedItem;
            p.Lekar = (Lekar)Lekari.SelectedItem;
            if (pac.ZdravstveniKarton != null)
                p.zdravstveniKarton = pac.ZdravstveniKarton;
            else
            {
                p.zdravstveniKarton = new ZdravstveniKarton(null, pacijenti.Count + 1, StanjePacijentaEnum.None,null,KrvnaGrupaEnum.None,null) ;
                pac.ZdravstveniKarton = new ZdravstveniKarton(null, pacijenti.Count + 1, StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
            }

            Termin tZaLjekara = new Termin();
            tZaLjekara.Id = p.Id;
            p.Lekar.AddTermin(tZaLjekara);

            if (storage.ZakaziTermin(p, ids))
            {
                this.pregledi.Add(p);
                lekariDat.sacuvaj(lekari);
                //pacijentiDat.sacuvaj(pacijenti); // višakk?
            }
            pac.AddTermin(p);
            pacijentiStorage.AzurirajPacijenta(pac);
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
