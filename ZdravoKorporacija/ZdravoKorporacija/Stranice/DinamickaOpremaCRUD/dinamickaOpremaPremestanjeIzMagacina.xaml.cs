using Model;
using Service;
using System.Windows;
using System.Windows.Controls;


namespace ZdravoKorporacija.Stranice.DinamickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for dinamickaOpremaPremestanjeIzMagacina.xaml
    /// </summary>
    public partial class dinamickaOpremaPremestanjeIzMagacina : Window
    {

        private DinamickaOpremaService dinamickaopremaStorage = new DinamickaOpremaService();
        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private MagacinService magacineStorage = new MagacinService();

        public dinamickaOpremaPremestanjeIzMagacina()
        {
            InitializeComponent();
            cbMagacin.ItemsSource = magacineStorage.PregledSveOpreme();
            cbProstorija.ItemsSource = prostorijeStorage.PregledSvihProstorija();
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

        private void cbMagacin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
