using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Izmeni.xaml
    /// </summary>
    public partial class Izmeni : Window
    {
        private PacijentDTO pacijentDTO;
        private TerminDTO selektovanidto;
        private TerminDTO noviTermindDTO;
        private ObservableCollection<TerminDTO> mojiPregledi;
        private BindingList<LekarDTO> dostupniLjekaridto;
        private List<LekarDTO> ljekaridto;
        private LekarController lekarKontroler = new LekarController();
        private TerminController terminKontroler = new TerminController();

        public Izmeni(TerminDTO selektovani, ObservableCollection<TerminDTO> termini, PacijentDTO pacijentDTO)
        {
            InitializeComponent();

            this.pacijentDTO = pacijentDTO;
            this.selektovanidto = selektovani;
            this.noviTermindDTO = new TerminDTO();
            this.mojiPregledi = termini; //pregledi
            this.dostupniLjekaridto = new BindingList<LekarDTO>();
            this.ljekaridto = (List<LekarDTO>)lekarKontroler.dobaviListuDTOLekara();

            azurirajDostupne();
            inicijalizujKomponente();
        }

        private void inicijalizujKomponente()
        {
            foreach (LekarDTO l in ljekaridto)
            {
                if (l.Jmbg == selektovanidto.Lekar.Jmbg)
                {
                    ljekar.SelectedItem = l;
                }
            }

            ////// **********************
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, selektovanidto.Pocetak.AddDays(-3));
            CalendarDateRange kalendar1 = new CalendarDateRange(selektovanidto.Pocetak.AddDays(3), DateTime.MaxValue);
            date.BlackoutDates.Add(kalendar);
            date.BlackoutDates.Add(kalendar1);

            date.SelectedDate = selektovanidto.Pocetak;
            DateTime danas = DateTime.Today;
            List<String> source = new List<String>();
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }

            time.SelectedItem = selektovanidto.Pocetak.ToShortTimeString();

        }

        private void azurirajDostupne()
        {

            if (dostupniLjekaridto != null)
            {
                dostupniLjekaridto.Clear();
            }

            foreach (LekarDTO lll in ljekaridto)
            {
                dostupniLjekaridto.Add(lll);
            }
            
            ljekar.ItemsSource = dostupniLjekaridto;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            noviTermindDTO.Lekar = (LekarDTO)ljekar.SelectedItem;
            noviTermindDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());
            noviTermindDTO.zdravstveniKarton = pacijentDTO.ZdravstveniKarton;

            if (terminKontroler.pomeriPregled(noviTermindDTO, pacijentDTO))
            {
                this.mojiPregledi.Remove(selektovanidto);
                this.mojiPregledi.Add(noviTermindDTO);

            }
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void timeChanged(object sender, SelectionChangedEventArgs e)
        {
            azurirajDostupne();

            noviTermindDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if (!(noviTermindDTO.Pocetak.ToShortTimeString().Equals(selektovanidto.Pocetak.ToShortTimeString())))
            {

                if (!((noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString())) && noviTermindDTO.Pocetak.ToShortTimeString().Equals(selektovanidto.Pocetak.ToShortTimeString())))
                {

                    mojiPregledi.Remove(noviTermindDTO);
                    foreach (TerminDTO term in mojiPregledi)
                    {
                        if (term.Pocetak.Equals(noviTermindDTO.Pocetak))
                        {
                            foreach (LekarDTO l in ljekaridto.ToArray())
                            {
                                if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                {
                                    dostupniLjekaridto.Remove(l);
                                    ljekar.SelectedItem = null;
                                }
                            }
                        }
                    }
                }

            }

        }
        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            azurirajDostupne();

            noviTermindDTO.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if (!(noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString())))
            {
                if (!((noviTermindDTO.Pocetak.ToShortDateString().Equals(selektovanidto.Pocetak.ToShortDateString())))) //&& p.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
                {
                    mojiPregledi.Remove(noviTermindDTO);

                    foreach (TerminDTO term in mojiPregledi)
                    {


                        if (term.Pocetak.ToString().Equals(noviTermindDTO.Pocetak.ToString()))
                        {
                            foreach (LekarDTO l in ljekaridto.ToArray())
                            {
                                if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                {
                                    dostupniLjekaridto.Remove(l);
                                    ljekar.SelectedItem = null;
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
