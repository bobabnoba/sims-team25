using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for izmeniProstorijuUpravnik.xaml
    /// </summary>
    public partial class izmeniProstorijuUpravnik : Window
    {
        private ProstorijaFileStorage storage = new ProstorijaFileStorage();
        private ObservableCollection<Prostorija> prostorije;
        private Prostorija prostorijaIzmenjena;
        public izmeniProstorijuUpravnik(ObservableCollection<Prostorija> pr, Prostorija p)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.prostorijaIzmenjena = p;

            textBoxIzmenaNaziv.Text = p.Naziv;
            if (p.Tip == TipProstorijeEnum.OperacionaSala)
            {
                comboBoxIzmenaTip.SelectedIndex = 0;
            }
            else if (p.Tip == TipProstorijeEnum.Soba)
            {
                comboBoxIzmenaTip.SelectedIndex = 1;
            }
            else
            {
                comboBoxIzmenaTip.SelectedIndex = 2;
            }

            comboBoxIzmenaSprat.SelectedIndex = p.Sprat;

            if (p.Slobodna) { checkBoxIzmenaZauzeta.IsChecked = false; }
            else { checkBoxIzmenaZauzeta.IsChecked = true; }

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            string ime = textBoxIzmenaNaziv.Text;
            bool zauzeta;
            TipProstorijeEnum tip;
            int sprat;
            if (comboBoxIzmenaTip.SelectedIndex == 0)
            {
                tip = TipProstorijeEnum.OperacionaSala;
            }
            else if (comboBoxIzmenaTip.SelectedIndex == 1)
            {
                tip = TipProstorijeEnum.Soba;
            }
            else
            {
                tip = TipProstorijeEnum.Ordinacija;
            }
            sprat = comboBoxIzmenaSprat.SelectedIndex;
            if (checkBoxIzmenaZauzeta.IsChecked == true) { zauzeta = true; }
            else
            {
                zauzeta = false;
            }
            Prostorija prostorija = new Prostorija(prostorijaIzmenjena.Id, ime, tip, zauzeta, sprat);
            if (storage.AzurirajProstoriju(prostorija))
            {
                prostorije.Remove(prostorijaIzmenjena);
                this.prostorije.Add(prostorija);

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

        private void comboBoxIzmenaSprat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
