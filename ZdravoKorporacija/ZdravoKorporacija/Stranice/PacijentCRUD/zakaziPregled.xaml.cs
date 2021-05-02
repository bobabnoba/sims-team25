using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for zakaziPregled.xaml
    /// </summary>
    public partial class zakaziPregled : Window
    {
        private TerminService storage = new TerminService();
        private LekarRepozitorijum ljekariDat = new LekarRepozitorijum();
        private List<Lekar> ljekari;
        private BindingList<Lekar> dostupniLjekari;
        private Termin p;
        private ObservableCollection<Termin> pregledi;
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private Boolean selected; // true ljekar, false vrijeme
        private Pacijent pacijent;


        public zakaziPregled(ObservableCollection<Termin> termini, Dictionary<int,int> ids, Pacijent pacijent)
        {
            InitializeComponent();
            this.ids = ids;
            p = new Termin();
            this.pacijent = pacijent;
            ljekari = ljekariDat.dobaviSve();
            pregledi = termini;
            dostupniLjekari = new BindingList<Lekar>();

            p.Tip = TipTerminaEnum.Pregled;
            p.Trajanje = 0.5;

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
            if (dostupniLjekari != null)
                dostupniLjekari.Clear();
            foreach (Lekar lll in ljekari)
            {
                dostupniLjekari.Add(lll);
            }
            ljekar.ItemsSource = dostupniLjekari;

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

            p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

            //ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            //String t = null;
            //String d = date.Text;
            //if (cboItem != null)
            //{

            //    t = cboItem.Content.ToString();

            //}
            //p.Pocetak = DateTime.Parse(d + " " + t);

            p.Lekar = (Lekar)ljekar.SelectedItem;
            Termin tZaLjekara = new Termin();
            tZaLjekara.Id = p.Id;
            p.Lekar.AddTermin(tZaLjekara);

            if (storage.ZakaziTermin(p, ids))
            {
                this.pregledi.Add(p);
                ljekariDat.sacuvaj(ljekari);
                KorisnikService.b.zakazanCnt++;
            }

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
                    p.Lekar = (Lekar)ljekar.SelectedItem;

                    foreach (Termin t in pregledi)
                    {
                        if (t.Lekar.Jmbg.Equals(p.Lekar.Jmbg))
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
                    p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    foreach (Termin t in pregledi)
                    {
                        if (t.Pocetak.Equals(p.Pocetak))
                        {
                            foreach (Lekar l in ljekari.ToArray()) 
                            {
                                if (l.Jmbg.Equals(t.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l);
                                }
                            }
                        }
                    }

                    ljekar.IsEnabled = true;
                }
            }

        }

        private void date_changed(object sender, SelectionChangedEventArgs e)
        {
            if (selected)
            {
                if (ljekar.SelectedIndex != -1 && date.SelectedDate != null)
                {
                    p.Lekar = (Lekar)ljekar.SelectedItem;

                    foreach (Termin t in pregledi)
                    {
                        if (t.Lekar.Jmbg.Equals(p.Lekar.Jmbg)) 
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
                    p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    foreach (Termin t in pregledi)
                    {
                        if (t.Pocetak.Equals(p.Pocetak))
                        {
                            foreach (Lekar l in ljekari.ToArray())
                            {
                                if (l.Jmbg.Equals(t.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l); 
                                }
                            }
                        }
                    }

                    ljekar.IsEnabled = true;
                }
            }

        }

        private void ljekar_changed(object sender, SelectionChangedEventArgs e)
        {
            time.IsEnabled = true;

            if (selected)
            {
                if (date.SelectedDate != null && ljekar.SelectedItem != null)
                {
                    p.Lekar = (Lekar)ljekar.SelectedItem;

                    foreach (Termin t in pregledi)
                    {
                        if (t.Lekar.Jmbg.Equals(p.Lekar.Jmbg)) 
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
                    p.Pocetak = DateTime.Parse(date.Text + " " + time.SelectedItem.ToString());

                    foreach (Termin t in pregledi)
                    {
                        if (t.Pocetak.Equals(p.Pocetak))
                        {
                            foreach (Lekar l in ljekari.ToArray())
                            {
                                if (l.Jmbg.Equals(t.Lekar.Jmbg))
                                {
                                    dostupniLjekari.Remove(l);  
                                }
                            }
                        }
                    }

                    ljekar.IsEnabled = true;
                }
            }

        }
    }
}
