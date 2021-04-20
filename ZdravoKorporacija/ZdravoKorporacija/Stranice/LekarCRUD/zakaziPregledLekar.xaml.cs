using Model;
using Service;
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
        private ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private PacijentService pacijentiStorage = new PacijentService();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private Termin p;
        private ObservableCollection<Termin> pregledi;
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        private Dictionary<int, int> ids = new Dictionary<int, int>();



        public zakaziPregledLekar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            p = new Termin();
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;

            this.ids = ids;


            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);


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
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;

            if (cboItem != null)
            {
                t = cboItem.Content.ToString();
                if (d.Equals(today.ToString("dd.M.yyyy.")))
                {
                    if (Int32.Parse(t.Substring(0, 2)) < (now.Substring(9, 8).Equals("po podne") ? popodne : prepodne))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");

                        return;
                    }
                    else if ((Int32.Parse(t.Substring(0, 2)) == prepodne || Int32.Parse(t.Substring(0, 2)) == popodne) && Int32.Parse(t.Substring(3, 2)) < Int32.Parse(now.Substring(3, 2)))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        return;
                    }
                }
            }
            try
            {
                p.Pocetak = DateTime.Parse(d + " " + t);
            }
            catch(InvalidCastException)
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
                p.zdravstveniKarton = new ZdravstveniKarton(null, 0, StanjePacijentaEnum.None,null,KrvnaGrupaEnum.None,null) ;
                pac.ZdravstveniKarton = new ZdravstveniKarton(null, 0, StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                zdravstveniKartonServis.KreirajZdravstveniKarton(pac.ZdravstveniKarton,ids);
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
