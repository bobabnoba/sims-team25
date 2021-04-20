using Model;
using Repository;
using System.Collections.Generic;
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

        Dictionary<int, int> ids = new Dictionary<int, int>();

        public upravnikStart()
        {
            InitializeComponent();
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            prostorije = new ObservableCollection<Prostorija>(datoteka.dobaviSve());
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
            ids = datotekaID.dobaviSve();
            dgUsers.ItemsSource = prostorije;
            // inicijalizacija
            //for(int i = 0; i < 1000; i++)
            //{
            //ids[i] =0;
            //}
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
                izmeniProstorijuUpravnik ip = new izmeniProstorijuUpravnik(prostorije, (Prostorija)dgUsers.SelectedItem);
                ip.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
