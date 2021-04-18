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
        private Dictionary<int, int> ids = new Dictionary<int, int>();


        public zakaziPregled(ObservableCollection<Termin> termini, Dictionary<int,int> ids)
        {
            InitializeComponent();
            p = new Termin();
            ljekari = ljekariDat.dobaviSve();
            ljekar.ItemsSource = ljekari;
            pregledi = termini;
            this.ids = ids;

            p.Tip = TipTerminaEnum.Pregled;
            p.Trajanje = 0.5;
            //p.Id = pregledi.Count + 1;

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

            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            String d = date.Text;
            if (cboItem != null)
            {

                t = cboItem.Content.ToString();

            }
            p.Pocetak = DateTime.Parse(d + " " + t);

            p.Lekar = (Lekar)ljekar.SelectedItem;
            Termin tZaLjekara = new Termin();
            tZaLjekara.Id = p.Id;
            p.Lekar.AddTermin(tZaLjekara);

            if (storage.ZakaziTermin(p, ids))
            {
                this.pregledi.Add(p);
                ljekariDat.sacuvaj(ljekari);
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
