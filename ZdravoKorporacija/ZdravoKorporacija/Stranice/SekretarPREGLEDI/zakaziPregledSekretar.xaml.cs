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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for zakaziPregledSekretar.xaml
    /// </summary>
    public partial class zakaziPregledSekretar : Window
    {

        
        private List<LekarDTO> lekari = new List<LekarDTO>();
        private List<LekarDTO> slobodniLekari;
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

        private Dictionary<int, int> ids = new Dictionary<int, int>();

        DateTime dateTime = DateTime.Now;
        public zakaziPregledSekretar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            noviTermin = new TerminDTO();
            pregledi = termini;

            
            cbPacijent.ItemsSource = tc.PregledSvihPacijenata();

            lekari = tc.PregledSvihLekaraDTO(tc.PregledSvihLekara());

            slobodniLekari = lekari;
            Lekari.ItemsSource = slobodniLekari;

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

            cbPacijent.IsEnabled = false;
            cbProstorija.IsEnabled = false;
            Lekari.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbPacijent.IsEnabled = true;
            cbProstorija.IsEnabled = true;
            Lekari.IsEnabled = true;

            slobodniLekari      = tc.PregledSvihLekaraDTO( tc.DobaviSlobodneLekare(tc.PregledSvihLekaraModel( lekari), pregledi, pocetakTermina));
            Lekari.ItemsSource = slobodniLekari;
            slobodneProstorije  = tc.PregledSvihProstorijaDTO( tc.DobaviSlobodneProstorije(tc.PregledSvihProstorija2Model( prostorije), pregledi, tc.TerminDTO2Model(noviTermin)));
            cbProstorija.ItemsSource = slobodneProstorije;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = tc.MapaTermina(ids);
            Pacijent pac = (Pacijent)cbPacijent.SelectedItem;


            idTermina = id;
            pocetakTermina      = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            prostorijaTermina   = (ProstorijaDTO)cbProstorija.SelectedItem;
            lekarTermina        = (LekarDTO)Lekari.SelectedItem;
            
            if (cbTip.SelectedIndex == 0)            
                tipTermina      = TipTerminaEnum.Pregled;            
            else if (cbTip.SelectedIndex == 1)            
                tipTermina      = TipTerminaEnum.Operacija;

            noviTermin = new TerminDTO(tc.NadjiKartonID(pac.Jmbg), prostorijaTermina, lekarTermina, tipTermina, pocetakTermina, 0.5, null);
            noviTermin.Id = idTermina;
            
            if (tc.ZakaziTermin(tc.TerminDTO2Model(noviTermin), ids))
            {
                tc.DodajTermin(tc.TerminDTO2Model(noviTermin));
                lekari = tc.PregledSvihLekaraDTO( tc.PregledSvihLekara());
                tc.AzurirajLekare(tc.PregledSvihLekaraModel(lekari));
            }
            
            
            tc.DodajTermin(pac,tc.TerminDTO2Model(noviTermin));
            tc.AzurirajPacijenta(pac);
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
