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
        private List<ProstorijaDTO> slobodneProstorije;
        private List<ProstorijaDTO> prostorije = new List<ProstorijaDTO>();

        private int idTermina;
        private TipTerminaEnum tipTermina;
        private DateTime pocetakTermina;
        private ProstorijaDTO prostorijaTermina;

        private TerminDTO noviTermin;
        private TerminController tc = new TerminController();
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
            

            if (cbTip.SelectedIndex == 0)
                tipTermina = TipTerminaEnum.Pregled;
            else if (cbTip.SelectedIndex == 1)
                tipTermina = TipTerminaEnum.Operacija;

            noviTermin = new TerminDTO(tc.NadjiKartonID(pac.Jmbg), prostorijaTermina, tc.NadjiLekaraPoJMBG(lekarLogin.jmbg), tipTermina, pocetakTermina, 0.5, null);
            noviTermin.Id = idTermina;

            if (tc.ZakaziTermin(tc.TerminDTO2Model(noviTermin), ids))
            {
                tc.DodajTermin(tc.TerminDTO2Model(noviTermin));
                tc.AzurirajLekare();
            }


            tc.DodajTermin(tc.PacijentDTO2Model(pac), tc.TerminDTO2Model(noviTermin));
            tc.AzurirajPacijenta(tc.PacijentDTO2Model(pac));
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
