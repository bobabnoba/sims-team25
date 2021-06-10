using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zakaziPregledLekar.xaml
    /// </summary>
    public partial class zakaziPregledLekar : Window
    {
        private ObservableCollection<ProstorijaDTO> slobodneProstorije;
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();

        private int idTermina;
        private TipTerminaEnum tipTermina;
        private DateTime pocetakTermina;
        private ProstorijaDTO prostorijaTermina;

        private TerminDTO noviTermin;
        private TerminController tc = new TerminController();
        private TerminService terminServis = new TerminService();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private ProstorijaService prostorijeServis = new ProstorijaService();
        private ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        private PacijentService pacijentiServis = new PacijentService();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Termin> termini = new List<Termin>();

        private Termin p;
        private ObservableCollection<Termin> pregledi;
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        private Dictionary<int, int> ids = new Dictionary<int, int>();



        public zakaziPregledLekar( Dictionary<int, int> ids)
        {
            InitializeComponent();

            noviTermin = new TerminDTO();
            

            
            cbPacijent.ItemsSource = tc.PregledSvihPacijenata2DTO();


         

            prostorije = tc.PregledSvihProstorijaDTO(tc.PregledSvihProstorija());
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
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = tc.MapaTermina(ids);
            PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;


            idTermina = id;
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;

            String t = cboItem.Content.ToString();
            pocetakTermina = DateTime.Parse(date.Text + " " + t);
            prostorijaTermina = (ProstorijaDTO)cbProstorija.SelectedItem;
          
            String d = date.Text;
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
            

            if (cbTip.SelectedIndex == 0)
                tipTermina = TipTerminaEnum.Pregled;
            else if (cbTip.SelectedIndex == 1)
                tipTermina = TipTerminaEnum.Operacija;

            //noviTermin = new TerminDTO(new ZdravstveniKartonDTO(tc.NadjiKartonID(pac.Jmbg)), prostorijaTermina, tc.NadjiLekaraPoJMBG(lekarLogin.jmbg), tipTermina, pocetakTermina, 0.5, null);

            //noviTermin.Id = idTermina;

            //if (tc.ZakaziTermin(tc.TerminDTO2Model(noviTermin), ids))
            //{
            //    tc.DodajTermin(tc.TerminDTO2Model(noviTermin));
            //    tc.AzurirajLekare();
            //}

            noviTermin = new TerminDTO();
            noviTermin.Lekar = tc.NadjiLekaraPoJMBG(lekarLogin.jmbg);
            noviTermin.zdravstveniKarton = new ZdravstveniKartonDTO(tc.NadjiKartonID(pac.Jmbg));
            noviTermin.prostorija = prostorijaTermina;
            noviTermin.Tip = tipTermina;

            tc.zakaziTermin(noviTermin);


            tc.DodajTermin(tc.PacijentDTO2Model(pac), tc.TerminDTO2Model(noviTermin));
            tc.AzurirajPacijenta(tc.PacijentDTO2Model(pac));

            if (terminServis.ZakaziTermin(p, ids))
            {
                this.pregledi.Add(p);
                lekariDat.sacuvaj(lekari);
                //pacijentiDat.sacuvaj(pacijenti); // višakk?
            }
            pac.AddTermin(new TerminDTO(p));
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
