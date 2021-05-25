using Controller;
using Model;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for izmeniProstorijuUpravnik.xaml
    /// </summary>
    public partial class izmeniProstorijuUpravnik : Window
    {
        private ProstorijaController prostorijaKontroler = new ProstorijaController();
        private ObservableCollection<ProstorijaDTO> prostorije;
        private ProstorijaDTO prostorijaIzmenjena;
        private int indeks;
        public izmeniProstorijuUpravnik(ObservableCollection<ProstorijaDTO> pr, ProstorijaDTO p, int selectedIndex)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.prostorijaIzmenjena = p;
            this.indeks = selectedIndex;
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

          

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            string ime = textBoxIzmenaNaziv.Text;
            
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
            
            ProstorijaDTO prostorijaDTO = new ProstorijaDTO(prostorijaIzmenjena.Id, ime, tip, false, sprat);

            if (prostorijaKontroler.AzurirajProstoriju(prostorijaDTO, this.indeks))
            {
                prostorije.RemoveAt(indeks);
                prostorije.Insert(indeks,prostorijaDTO);
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
