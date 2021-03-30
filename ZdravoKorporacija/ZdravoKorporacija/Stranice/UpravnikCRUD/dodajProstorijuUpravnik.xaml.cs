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
    /// Interaction logic for dodajProstorijuUpravnik.xaml
    /// </summary>
    public partial class dodajProstorijuUpravnik : Window
    {
        private ProstorijaFileStorage storage = new ProstorijaFileStorage();
        private ObservableCollection<Prostorija> prostorije ;
        public dodajProstorijuUpravnik(ObservableCollection<Prostorija> pr)
        {
            InitializeComponent();
            this.prostorije = pr;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(textBoxId.Text);
            string ime = textboxNaziv.Text;
            TipProstorijeEnum tip;
            int sprat;
            if (comboBoxTip.SelectedIndex == 0)
            {
                tip = TipProstorijeEnum.OperacionaSala;
            }
            else if (comboBoxTip.SelectedIndex == 1)
            {
                tip = TipProstorijeEnum.Soba;
            }
            else
            {
                tip = TipProstorijeEnum.Ordinacija;
            }
            sprat = comboBoxSprat.SelectedIndex;

            Prostorija prostorija = new Prostorija(id,ime,tip,true,sprat);
            if (storage.DodajProstoriju(prostorija))
            {
                this.prostorije.Add(prostorija);
                System.Console.WriteLine("dodao");
                this.Close();
            }
            
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBoxSprat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
