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
        private ObservableCollection<Termin> pregledi;
        private Termin p;
        private Termin s;

        public izmeniPregled(Termin selektovani, ObservableCollection<Termin> termini)
        {

            InitializeComponent();
            ljekari = ljekariDat.dobaviSve();
            ljekar.ItemsSource = ljekari;

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
            date.SelectedDate = selektovani.Pocetak;
            time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            p.Lekar = (Lekar)ljekar.SelectedItem;

            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            String d = date.Text;
            if (cboItem != null)
            {

                t = cboItem.Content.ToString();

            }
            p.Pocetak = DateTime.Parse(d + " " + t);

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


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (cboItem != null)
            {
                String t = cboItem.Content.ToString();
                String d = date.Text;
                p.Pocetak = DateTime.Parse(d + " " + t);

            }

        }

    }
}
