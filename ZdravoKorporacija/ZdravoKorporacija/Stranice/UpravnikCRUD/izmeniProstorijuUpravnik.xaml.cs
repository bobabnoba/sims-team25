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

            textBoxIzmenaId.Text = "" + p.Id;
            textBoxIzmenaNaziv.Text = p.Naziv;
            if (p.Tip == TipProstorijeEnum.OperacionaSala) {
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
            prostorije.Remove(prostorijaIzmenjena);
            int id = int.Parse(textBoxIzmenaId.Text);
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
            Prostorija prostorija = new Prostorija(id, ime, tip, zauzeta, sprat);
            if (storage.AzurirajProstoriju(prostorija))
            {
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
