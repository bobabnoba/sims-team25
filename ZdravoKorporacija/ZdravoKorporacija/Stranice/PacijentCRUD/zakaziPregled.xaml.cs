using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for zakaziPregled.xaml
    /// </summary>
    public partial class zakaziPregled : Window
    {
      
      
        private ObservableCollection<Termin> pregledi;
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private Boolean selected; // true ljekar, false vrijeme
        private Pacijent pacijent;
        private TerminController tc = new TerminController();
        private List<LekarDTO> lekari = new List<LekarDTO>();
        private List<LekarDTO> slobodniLekari;
        private List<ProstorijaDTO> slobodneProstorije;
        private TerminDTO noviTermin = new TerminDTO();
        private PacijentService pacijentServis = new PacijentService();


        public zakaziPregled(ObservableCollection<Termin> termini, Dictionary<int,int> ids, Pacijent pacijent)
        {
            InitializeComponent();
            this.ids = ids;           
            this.pacijent = pacijent;            
            pregledi = termini;
            lekari = tc.PregledSvihLekaraDTO(tc.PregledSvihLekara());
            slobodniLekari = lekari;           

            noviTermin.Tip = TipTerminaEnum.Pregled;
            noviTermin.Trajanje = 0.5;

            date.IsEnabled = false;
            time.IsEnabled = false;
            ljekar.IsEnabled = false;

            selektovaneVrijednosti();
        }

        private void selektovaneVrijednosti()
        {

            ljekar.SelectedItem = null;
            time.SelectedItem = null;
            date.SelectedDate = null;
            slobodniLekari = lekari;
            ljekar.ItemsSource = slobodniLekari;

            time.Items.Clear();
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());

            }
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(kalendar);

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = tc.MapaTermina(ids);   

          

            noviTermin.Id = id;
            noviTermin.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            noviTermin.Lekar = (LekarDTO)ljekar.SelectedItem;
            noviTermin.zdravstveniKarton = pacijent.ZdravstveniKarton;

            if (tc.ZakaziTermin(tc.TerminDTO2Model(noviTermin), ids))
            {
                this.pregledi.Add(tc.TerminDTO2Model(noviTermin));
                lekari = tc.PregledSvihLekaraDTO(tc.PregledSvihLekara());
                tc.AzurirajLekare();

            }

            pacijent.AddTermin(tc.TerminDTO2Model(noviTermin));
            pacijentServis.AzurirajPacijenta(pacijent);
            this.Close();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void VremenskiSlotChecked(object sender, RoutedEventArgs e)
        {
            selektovaneVrijednosti();
            selected = false;
            date.IsEnabled = true;
            time.IsEnabled = true;
            ljekar.IsEnabled = false;

        }

        private void LekarChecked(object sender, RoutedEventArgs e)
        {
            selektovaneVrijednosti();
            selected = true;
            date.IsEnabled = true;
            time.IsEnabled = false;
            ljekar.IsEnabled = true;


        }
        private void time_changed(object sender, SelectionChangedEventArgs e)
        {
            if (selected)
            {
                if (ljekar.SelectedItem != null && date.SelectedDate != null)
                {
                    noviTermin.Lekar = (LekarDTO)ljekar.SelectedItem;

                    foreach (Termin t in pregledi)
                    {
                        
                        if (t.Lekar.Jmbg.Equals(noviTermin.Lekar.Jmbg))
                        {
                            if (t.Pocetak.Date.Equals(((DateTime)date.SelectedDate).Date))
                            {
                                time.Items.Remove(t.Pocetak.ToShortTimeString());
                            }
                        }
                    }
                    time.IsEnabled = true;
                }
            }
            else
            {
                if (time.SelectedItem != null && date.SelectedDate != null)
                {
                    noviTermin.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    slobodniLekari = tc.PregledSvihLekaraDTO(tc.DobaviSlobodneLekare(tc.PregledSvihLekaraModel(lekari), pregledi, noviTermin.Pocetak));

                    slobodni();
                }
            }

        }

        private void date_changed(object sender, SelectionChangedEventArgs e)
        {
            if (selected)
            {
                if (ljekar.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    noviTermin.Lekar = (LekarDTO)ljekar.SelectedItem;

                    foreach (Termin t in pregledi)
                    {
                        if (t.Lekar.Jmbg.Equals(noviTermin.Lekar.Jmbg)) 
                        {
                            if (t.Pocetak.Date.Equals(((DateTime)date.SelectedDate).Date)) 
                            {
                                time.Items.Remove(t.Pocetak.ToShortTimeString());
                            }
                        }
                    }
                    time.IsEnabled = true;
                }
            }
            else
            {
                if (time.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    noviTermin.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    slobodniLekari = tc.PregledSvihLekaraDTO(tc.DobaviSlobodneLekare(tc.PregledSvihLekaraModel(lekari), pregledi, noviTermin.Pocetak));


                    slobodni();
                }
            }

        }
        private void slobodni()
        {
            ljekar.IsEnabled = true;
            
        }
        private void ljekar_changed(object sender, SelectionChangedEventArgs e)
        {
            time.IsEnabled = true;

            if (selected)
            {
                if (date.SelectedDate != null && ljekar.SelectedItem != null)
                {
                    noviTermin.Lekar = (LekarDTO)ljekar.SelectedItem;

                    foreach (Termin t in pregledi)
                    {
                        if (t.Lekar.Jmbg.Equals((int)noviTermin.Lekar.Jmbg))
                        {
                            if (t.Pocetak.Date.Equals(((DateTime)date.SelectedDate).Date))
                            {
                                time.Items.Remove(t.Pocetak.ToShortTimeString());
                            }
                        }
                    }
                    time.IsEnabled = true;
                }
            }
            else
            {
                if (time.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    noviTermin.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());


                    slobodniLekari = tc.PregledSvihLekaraDTO(tc.DobaviSlobodneLekare(tc.PregledSvihLekaraModel(lekari), pregledi, noviTermin.Pocetak));

                    slobodni();
                }
            }

        }
    }
}
