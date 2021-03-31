using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zakaziPregledLekar.xaml
    /// </summary>
    public partial class zakaziPregledLekar : Window
    {
        private TerminFileStorage storage = new TerminFileStorage();
        private ProstorijaFileStorage prostorijeStorage = new ProstorijaFileStorage();
        private DatotekaPacijentJSON pacijentiDat = new DatotekaPacijentJSON();
        private PacijentFileStorage pacijentiStorage = new PacijentFileStorage();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private DatotekaLekarJSON lekariDat = new DatotekaLekarJSON();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private Termin p;
        private ObservableCollection<Termin> pregledi;

        public zakaziPregledLekar(ObservableCollection<Termin> termini)
        {
            InitializeComponent();
            p = new Termin();
            pacijenti = pacijentiDat.CitanjeIzFajla();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;

            lekari = lekariDat.CitanjeIzFajla();
            Lekari.ItemsSource = lekari;

            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            p.Trajanje = 0.5;
            p.Id = pregledi.Count + 1;

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            Pacijent pac = (Pacijent)cbPacijent.SelectedItem;
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String d = date.Text;
            String t = null;
            if (cboItem != null)
            {

                t = cboItem.Content.ToString();

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

            p.prostorija = (Prostorija)cbProstorija.SelectedItem;
            p.Lekar = (Lekar)Lekari.SelectedItem;

            if (storage.ZakaziTermin(p))
            {
                this.pregledi.Add(p);
            }
            pac.AddTermin(p);
            pacijentiStorage.AzurirajPacijenta(pac);
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
