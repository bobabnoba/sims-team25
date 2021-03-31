using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private TerminFileStorage storage = new TerminFileStorage();
        private ProstorijaFileStorage prostorijeStorage = new ProstorijaFileStorage();
        private DatotekaPacijentJSON pacijentiDat = new DatotekaPacijentJSON();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private DatotekaLekarJSON lekariDat = new DatotekaLekarJSON();
        private List<Lekar> lekari = new List<Lekar>();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private Termin p;
        private Termin s; // selektovani, za ukloniti
        private ObservableCollection<Termin> pregledi;
        public izmeniPregledLekar(Termin selektovani, ObservableCollection<Termin> termini)
        {
            InitializeComponent();
            p = selektovani;
            s = selektovani;
            pacijenti = pacijentiDat.CitanjeIzFajla();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;

            lekari = lekariDat.CitanjeIzFajla();
            Lekari.ItemsSource = lekari;

            //Termin ne vidi pacijenta ni doktora -- cb nemaju selected item

            date.SelectedDate = selektovani.Pocetak;
            time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");

            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            foreach (Prostorija p in prostorije)
            {
                if(selektovani.prostorija == null)
                {
                    break;
                }
                if (p.Id == selektovani.prostorija.Id)
                {
                    cbProstorija.SelectedItem = p;
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
            p.Id = pregledi.Count + 1;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }

            p.prostorija = (Prostorija)cbProstorija.SelectedItem;

            if (storage.AzurirajTermin(p))
            {
                this.pregledi.Remove(s);
                this.pregledi.Add(p);
            }
            this.Close();
            this.Close();

        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            if (cboItem != null)
            {
                String t = cboItem.Content.ToString();
                String d = date.Text;
                p.Pocetak = DateTime.Parse(d + " " + t);

            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}