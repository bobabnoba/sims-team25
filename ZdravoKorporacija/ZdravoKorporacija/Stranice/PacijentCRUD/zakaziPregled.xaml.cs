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
    /// Interaction logic for zakaziPregled.xaml
    /// </summary>
    public partial class zakaziPregled : Window
    {
        private TerminFileStorage storage = new TerminFileStorage();
        private DatotekaLekarJSON ljekariDat = new DatotekaLekarJSON();
        private List<Lekar> ljekari;
        private Termin p;
        private ObservableCollection<Termin> pregledi;


        public zakaziPregled(ObservableCollection<Termin> termini)
        {
            InitializeComponent();
            p = new Termin();
            ljekari = ljekariDat.CitanjeIzFajla();
            ljekar.ItemsSource = ljekari;
            pregledi = termini;

            p.Tip = TipTerminaEnum.Pregled;
            p.Trajanje = 0.5;
            p.Id = pregledi.Count + 1;

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            p.Lekar = (Lekar)ljekar.SelectedItem;
            if (storage.ZakaziTermin(p))
            {
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
