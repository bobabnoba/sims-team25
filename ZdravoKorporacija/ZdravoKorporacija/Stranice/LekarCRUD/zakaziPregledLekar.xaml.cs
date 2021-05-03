using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zakaziPregledLekar.xaml
    /// </summary>
    public partial class zakaziPregledLekar : Window
    {
        private TerminService terminServis = new TerminService();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private ProstorijaService prostorijeServis = new ProstorijaService();
        private ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        private PacijentService pacijentiServis = new PacijentService();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Termin> termini = new List<Termin>();
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
            pacijenti = pacijentiServis.PregledSvihPacijenata();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;

            this.ids = ids;


            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);


            lekari = lekariDat.dobaviSve();

            prostorije = prostorijeServis.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            p.Trajanje = 0.5;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            termini = terminServis.PregledSvihTermina();
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
            //Izvestaj iz = new Izvestaj();
            //iz.Id = 0;
            //iz.Opis = "Temperature";
            //iz.Simptomi = "Covid";
            //p.izvestaj = iz;
            
            String d = date.Text;
            String t = null;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1 || cbTip.SelectedIndex == -1
                || cbProstorija.SelectedIndex == -1 || cbPacijent.SelectedIndex == -1)
            {
                MessageBox.Show("Niste popunili sva polja", "Greska");
                return;
            }
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
            foreach (Termin ter in termini)
            {
                if (ter.Pocetak == p.Pocetak)
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }
            if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }

            

            ZdravstveniKarton zk = new ZdravstveniKarton(null, pac.Jmbg, StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);

            p.prostorija = (Prostorija)cbProstorija.SelectedItem;
            p.Lekar = lekarLogin.lekar;
            if (pac.ZdravstveniKarton != null)
                p.zdravstveniKarton = pac.ZdravstveniKarton;
            else
            {
                p.zdravstveniKarton = zk ;
                pac.ZdravstveniKarton = zk;
                //pac.ZdravstveniKarton.AddTermin(p);
                zdravstveniKartonServis.KreirajZdravstveniKarton(pac.ZdravstveniKarton,ids);
            }
           
            Termin tZaLjekara = new Termin();
            tZaLjekara.Id = p.Id;
            p.Lekar.AddTermin(tZaLjekara);
            //p.zdravstveniKarton.AddTermin(tZaLjekara);

            if (terminServis.ZakaziTermin(p, ids))
            {
                Trace.WriteLine("Upisao");
                this.pregledi.Add(p);
                lekariDat.sacuvaj(lekari);
                //pacijentiDat.sacuvaj(pacijenti); // višakk?
            }
            pac.AddTermin(p);
            pacijentiServis.AzurirajPacijenta(pac);
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
