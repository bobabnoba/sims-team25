using Model;
using Repository;
using Service;
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
using ZdravoKorporacija.Stranice.UpravnikCRUD;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for LekStart.xaml
    /// </summary>
    public partial class LekStart : Page
    {

        LekServis lekServis = new LekServis();
        public LekStart()
        {
            InitializeComponent();
            // dgLekovi.ItemsSource = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());
            lekServis.PregledSvihLekova();
            dgLekovi.ItemsSource = LekRepozitorijum.Instance.lekovi;
            
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            DodavanjeZahtevaZaLek dodavanjeZahtevaZaLek = new DodavanjeZahtevaZaLek();
            dodavanjeZahtevaZaLek.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void dgLekovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pregledNeodobrenihLekova_Click(object sender, RoutedEventArgs e)
        {
            test2.f.Content = new NeodobreniZahteviZaLek();
        }
    }
}
