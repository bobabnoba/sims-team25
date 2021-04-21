using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for izmeniPregled.xaml
    /// </summary>
    public partial class izmeniPregled : Window
    {
        private TerminService storage = new TerminService();
        private LekarRepozitorijum ljekariDat = new LekarRepozitorijum();
        private List<Lekar> ljekari = new List<Lekar>();
        private List<Lekar> dostupniLjekari = new List<Lekar>();
        private ObservableCollection<Termin> pregledi;
        private Termin p;
        private Termin s;
        String datumSelekt;
        String vrijemeSelekt;

        public izmeniPregled(Termin selektovani, ObservableCollection<Termin> termini)
        {

            InitializeComponent();
            ljekari = ljekariDat.dobaviSve();
            dostupniLjekari.AddRange(ljekari);
            ljekar.ItemsSource = ljekari;
            time.SelectedItem = selektovani.Pocetak.ToShortTimeString();

            datumSelekt = selektovani.Pocetak.ToShortDateString();
            vrijemeSelekt = selektovani.Pocetak.ToShortTimeString();

            p = selektovani;
            s = selektovani; // samo za uklanjanje iz pregleda
            pregledi = termini;

            foreach (Lekar l in ljekari)
            {
                if (l.Jmbg == selektovani.Lekar.Jmbg)
                {
                    ljekar.SelectedItem = l;
                }
            }
            ////// **********************
            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, selektovani.Pocetak.AddDays(-3));
            CalendarDateRange kalendar1 = new CalendarDateRange(selektovani.Pocetak.AddDays(3), DateTime.MaxValue);
            date.BlackoutDates.Add(kalendar);
            date.BlackoutDates.Add(kalendar1);

            date.SelectedDate = selektovani.Pocetak;
            DateTime danas = DateTime.Today;
            List<String> source = new List<String>();
            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                time.Items.Add(tm.ToShortTimeString());
            }
            //date.SelectedDate = selektovani.Pocetak;
            //time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            p.Lekar = (Lekar)ljekar.SelectedItem;
            p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

            //ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            //String t = null;
            //String d = date.Text;
            //if (cboItem != null)
            //{

            //    t = cboItem.Content.ToString();

            //}
            //p.Pocetak = DateTime.Parse(d + " " + t);

            if (storage.AzurirajTermin(p))
            {
                this.pregledi.Remove(s);
                this.pregledi.Add(p);
            }
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void timeChanged(object sender, SelectionChangedEventArgs e)
        {
            p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if (!(p.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
            {

                if (!((p.Pocetak.ToShortDateString().Equals(datumSelekt)) && p.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
                {

                    pregledi.Remove(p);
                    foreach (Termin term in pregledi)
                    {
                        if (term.Pocetak.Equals(p.Pocetak))
                        {
                            foreach (Lekar l in ljekari.ToArray())
                            {
                                if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l);  
                                    ljekar.ItemsSource = dostupniLjekari;
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
            p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem);

            if (!(p.Pocetak.ToShortDateString().Equals(datumSelekt)))
            {
                if (!((p.Pocetak.ToShortDateString().Equals(datumSelekt)))) //&& p.Pocetak.ToShortTimeString().Equals(vrijemeSelekt)))
                {
                    pregledi.Remove(p);

                    foreach (Termin term in pregledi)
                    {
                    

                        if (term.Pocetak.ToString().Equals(p.Pocetak.ToString()))
                        {
                            foreach (Lekar l in ljekari.ToArray())
                            {
                                if (l.Jmbg.Equals(term.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l);  
                                    ljekar.ItemsSource = dostupniLjekari;
                                    ljekar.SelectedItem = null;
                                }
                            }
                        }
                    }
                    //ljekar.ItemsSource = dostupniLjekari;
                }
            }





        }

    }
}
