using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ZdravoKorporacija.Stranice.DinamickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for dinamickaOpremaPremestanjeIzMagacina.xaml
    /// </summary>
    public partial class dinamickaOpremaPremestanjeIzMagacina : Window
    {

        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private DinamickaOpremaService dinamickaopremaStorage = new DinamickaOpremaService();
        private MagacinService magacineStorage = new MagacinService();
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();
        private List<Inventar> magacin = new List<Inventar>();
        private List<DinamickaOprema> dinamickaMagacin = new List<DinamickaOprema>();
        public dinamickaOpremaPremestanjeIzMagacina()
        {
            InitializeComponent();

            magacin = magacineStorage.PregledSveOpreme();
            cbMagacin.ItemsSource = magacin;
            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;

           
        }

        private void cbMagacin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Inventar inv = (Inventar)cbMagacin.SelectedItem;
            dinamickaopremaStorage.DodajOpremu(inv,textboxKolicina.Text,(Prostorija)cbProstorija.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
