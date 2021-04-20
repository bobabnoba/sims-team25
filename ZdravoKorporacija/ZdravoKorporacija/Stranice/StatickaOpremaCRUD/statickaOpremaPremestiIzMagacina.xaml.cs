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
using ZdravoKorporacija.Model;



namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaPremestiIzMagacina.xaml
    /// </summary>
    public partial class statickaOpremaPremestiIzMagacina : Window
    {

        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private StatickaOpremaService statickaopremaStorage = new StatickaOpremaService();
        private MagacinService magacineStorage = new MagacinService();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private List<Inventar> magacin = new List<Inventar>();
        private List<StatickaOprema> statickaMagacin = new List<StatickaOprema>();
        public statickaOpremaPremestiIzMagacina()
        {
            InitializeComponent();


            magacin = magacineStorage.PregledSveOpreme();
            cbMagacin.ItemsSource = magacin;
            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inventar inv = (Inventar)cbMagacin.SelectedItem;
            StatickaOprema st = new StatickaOprema(null, inv);
            statickaopremaStorage.DodajOpremu(st);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbMagacin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
