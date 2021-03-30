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
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for izmeniPregled.xaml
    /// </summary>
    public partial class izmeniPregled : Window
    {
        private TerminFileStorage storage = new TerminFileStorage();
        private DatotekaLekarJSON ljekariDat = new DatotekaLekarJSON();
        private List<Lekar> ljekari = new List<Lekar>();
        private ObservableCollection<Termin> pregledi;
        private Termin p;
        private Termin s;

        public izmeniPregled(Termin selektovani, ObservableCollection<Termin> termini)
        {

            InitializeComponent();
            ljekari = ljekariDat.CitanjeIzFajla();
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
