using Controller;
using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikStart.xaml
    /// </summary>
    public partial class prostorijeStart : Page
    {
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();

        Dictionary<int, int> ids = new Dictionary<int, int>();
       
        public prostorijeStart()
        {
            InitializeComponent();
            ProstorijaController prostorijaController = new ProstorijaController();
            prostorije   = prostorijaController.PregledSvihProstorija();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
            ids = datotekaID.dobaviSve();
            dgUsers.ItemsSource = prostorije;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dodajProstorijuUpravnik dp = new dodajProstorijuUpravnik(prostorije, ids);
            dp.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izbrisiProstorijuUpravnik ip = new izbrisiProstorijuUpravnik(prostorije, (Prostorija)dgUsers.SelectedItem, ids);
                ip.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red","Greska");
            else
            {
                izmeniProstorijuUpravnik ip = new izmeniProstorijuUpravnik(prostorije, (Prostorija)dgUsers.SelectedItem, dgUsers.SelectedIndex);
                ip.Show();
            }
        }

        private void zakaziRenoviranje(object sender, RoutedEventArgs e)
        {
            Renoviranje r = new Renoviranje(dgUsers.SelectedIndex);
            r.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
