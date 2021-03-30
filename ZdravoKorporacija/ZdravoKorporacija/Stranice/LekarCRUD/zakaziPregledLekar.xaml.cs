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
        private List<Pacijent> pacijenti = new List<Pacijent>();
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

            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            p.Trajanje = 0.5;
            p.Id = pregledi.Count + 1;

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
