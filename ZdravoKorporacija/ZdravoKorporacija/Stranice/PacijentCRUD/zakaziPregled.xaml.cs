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
    /// Interaction logic for zakaziPregled.xaml
    /// </summary>
    public partial class zakaziPregled : Window
    {
        private TerminService storage = new TerminService();
        private LekarRepozitorijum ljekariDat = new LekarRepozitorijum();
        private List<Lekar> ljekari;
        private Termin p;
        private ObservableCollection<Termin> pregledi;


        public zakaziPregled(ObservableCollection<Termin> termini)
        {
            InitializeComponent();
            p = new Termin();
            ljekari = ljekariDat.dobaviSve();
            ljekar.ItemsSource = ljekari;
            pregledi = termini;

            p.Tip = TipTerminaEnum.Pregled;
            p.Trajanje = 0.5;
            p.Id = pregledi.Count + 1;

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            String d = date.Text;
            if (cboItem != null)
            {

                t = cboItem.Content.ToString();

            }
            p.Pocetak = DateTime.Parse(d + " " + t);

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


        }

    }
}
