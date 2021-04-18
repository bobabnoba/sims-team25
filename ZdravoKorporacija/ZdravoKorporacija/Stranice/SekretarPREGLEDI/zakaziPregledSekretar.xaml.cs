using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for zakaziPregledSekretar.xaml
    /// </summary>
    public partial class zakaziPregledSekretar : Window
    { 
           private TerminService storage = new TerminService();
    private ProstorijaService prostorijeStorage = new ProstorijaService();
    private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
    private PacijentService pacijentiStorage = new PacijentService();
    private List<Pacijent> pacijenti = new List<Pacijent>();
    private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
    private List<Lekar> lekari = new List<Lekar>();
    private List<Prostorija> prostorije = new List<Prostorija>();
    private Termin p;
    private ObservableCollection<Termin> pregledi;
    
        public zakaziPregledSekretar(ObservableCollection<Termin> termini)
        {
            InitializeComponent();
            p = new Termin();
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;

            lekari = lekariDat.dobaviSve();
            Lekari.ItemsSource = lekari;

            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            p.Trajanje = 0.5;
            p.Id = pregledi.Count + 1;
        }

        private void da(object sender, RoutedEventArgs e)
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
        private void ne(object sender, RoutedEventArgs e)
        {

        }
        private void vreme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
    }
}
