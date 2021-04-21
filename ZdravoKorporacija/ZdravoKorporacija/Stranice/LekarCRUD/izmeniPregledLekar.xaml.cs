using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for izmeniPregledLekar.xaml
    /// </summary>
    public partial class izmeniPregledLekar : Window
    {
        private TerminService storage = new TerminService();
        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private Termin p;
        private Termin s; // selektovani, za ukloniti
        private ObservableCollection<Termin> pregledi;
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;
        public izmeniPregledLekar(Termin selektovani, ObservableCollection<Termin> termini)
        {
            InitializeComponent();
            p = selektovani;
            s = selektovani;
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            try
            {

               // if(pacijent.ZdravstveniKarton.Id== selektovani.GetZdravstveniKarton().Id)

                foreach (Pacijent pacijent in pacijenti)
                {
                    if (pacijent.ZdravstveniKarton != null)
                    {
                        if (pacijent.ZdravstveniKarton.Id == selektovani.GetZdravstveniKarton().Id)
                            cbPacijent.SelectedItem = pacijent;
                    }
                }

            }
            catch (NullReferenceException) { }
            pregledi = termini;

            lekari = lekariDat.dobaviSve();
            Lekari.ItemsSource = lekari;
            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);

            //Termin ne vidi pacijenta ni doktora -- cb nemaju selected item
            try
            {
                date.SelectedDate = selektovani.Pocetak;
                time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");
            }
            catch(Exception) { }
            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            foreach (Prostorija p in prostorije)
            {
                if (selektovani.prostorija == null)
                {
                    break;
                }
                if (p.Id == selektovani.prostorija.Id)
                {
                    cbProstorija.SelectedItem = p;
                }
            }
            foreach (Lekar l in lekari)
            {
                if (selektovani.Lekar == null)
                {
                    break;
                }
                if (l.Jmbg == selektovani.Lekar.Jmbg)
                {
                    Lekari.SelectedItem = l;
                }
            }

            foreach (Pacijent p in pacijenti)
            {
                if (p.ZdravstveniKarton == selektovani.zdravstveniKarton)
                {
                    cbPacijent.SelectedItem = p;
                }
            }

            if (s.Tip == TipTerminaEnum.Pregled)
            {
                cbTip.SelectedIndex = 0;
            }
            else if (s.Tip == TipTerminaEnum.Operacija)
            {
                cbTip.SelectedIndex = 1;
            }


            p.Trajanje = 0.5;
            p.Id = s.Id;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            String d = date.Text;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            
            if (cboItem != null)
            {
                t = cboItem.Content.ToString();

                /* if (Int32.Parse(t.Substring(0, 2)) < (now.Substring(9, 8).Equals("po podne") ? Int32.Parse(now.Substring(0, 2)) + 12 : Int32.Parse(now.Substring(0, 2))))
                { MessageBox.Show("Nevalidno Vreme","Greska");
                    return;
                }
                else if (Int32.Parse(t.Substring(3, 2)) < Int32.Parse(now.Substring(3, 2))) 
                { MessageBox.Show("Nevalidno Vreme", "Greska");
                    return;
                } */


                if (d.Equals(today.ToString("dd.M.yyyy.")))
                {
                    if (Int32.Parse(t.Substring(0, 2)) < (now.Substring(9, 8).Equals("po podne") ? popodne: prepodne))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        
                        return;
                    }
                    else if ((Int32.Parse(t.Substring(0, 2))==prepodne || Int32.Parse(t.Substring(0, 2))==popodne) && Int32.Parse(t.Substring(3, 2)) < Int32.Parse(now.Substring(3, 2)))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        return;
                    }
                }

            }
            p.Pocetak = DateTime.Parse(d + " " + t);
            if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }

            p.Lekar = (Lekar)Lekari.SelectedItem;
            p.prostorija = (Prostorija)cbProstorija.SelectedItem;

            if (storage.AzurirajTermin(p))
            {
                this.pregledi.Remove(s);
                this.pregledi.Add(p);
            }
            this.Close();

        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}