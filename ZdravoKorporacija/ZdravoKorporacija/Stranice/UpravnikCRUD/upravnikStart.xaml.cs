using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikStart.xaml
    /// </summary>
    public partial class upravnikStart : Window
    {
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();
        public upravnikStart()
        {
            InitializeComponent();
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            prostorije = new ObservableCollection<Prostorija>(datoteka.CitanjeIzFajla());
            dgUsers.ItemsSource = prostorije;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dodajProstorijuUpravnik dp = new dodajProstorijuUpravnik(prostorije);
            dp.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izbrisiProstorijuUpravnik ip = new izbrisiProstorijuUpravnik(prostorije, (Prostorija)dgUsers.SelectedItem);
                ip.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red","Greska");
            else
            {
                izmeniProstorijuUpravnik ip = new izmeniProstorijuUpravnik(prostorije, (Prostorija)dgUsers.SelectedItem);
                ip.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
