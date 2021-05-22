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
        private List<LekarDTO> lekari = new List<LekarDTO>();
        private List<ProstorijaDTO> slobodneProstorije;
        private List<ProstorijaDTO> prostorije = new List<ProstorijaDTO>();
        private ObservableCollection<Termin> pregledi;

        private int idTermina;
        private TipTerminaEnum tipTermina;
        private DateTime pocetakTermina;
        private LekarDTO lekarTermina;
        private ProstorijaDTO prostorijaTermina;

        private TerminDTO noviTermin;
        private TerminController tc = new TerminController();
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        private Dictionary<int, int> ids = new Dictionary<int, int>();



        public zakaziPregledLekar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            noviTermin = new TerminDTO();
            pregledi = termini;

            
            cbPacijent.ItemsSource = tc.PregledSvihPacijenata();

            lekari = tc.PregledSvihLekaraDTO(tc.PregledSvihLekara());

         

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
            Pacijent pac = (Pacijent)cbPacijent.SelectedItem;


            idTermina = id;
            pocetakTermina = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            prostorijaTermina = (ProstorijaDTO)cbProstorija.SelectedItem;
            

            if (cbTip.SelectedIndex == 0)
                tipTermina = TipTerminaEnum.Pregled;
            else if (cbTip.SelectedIndex == 1)
                tipTermina = TipTerminaEnum.Operacija;

            noviTermin = new TerminDTO(tc.NadjiKartonID(pac.Jmbg), prostorijaTermina, tc.Model2DTO(lekarLogin.lekar), tipTermina, pocetakTermina, 0.5, null);
            noviTermin.Id = idTermina;

            if (tc.ZakaziTermin(tc.TerminDTO2Model(noviTermin), ids))
            {
                tc.DodajTermin(tc.TerminDTO2Model(noviTermin));
                lekari = tc.PregledSvihLekaraDTO(tc.PregledSvihLekara());
                tc.AzurirajLekare(tc.PregledSvihLekaraModel(lekari));
            }


            tc.DodajTermin(pac, tc.TerminDTO2Model(noviTermin));
            tc.AzurirajPacijenta(pac);
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
