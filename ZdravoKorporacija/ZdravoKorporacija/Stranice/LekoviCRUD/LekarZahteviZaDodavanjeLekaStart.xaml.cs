using Model;
using Repository;
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
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for LekarZahteviZaDodavanjeLekaStart.xaml
    /// </summary>
    public partial class LekarZahteviZaDodavanjeLekaStart : Window
    {
        LekServis lekServis = new LekServis();
        public LekarZahteviZaDodavanjeLekaStart()
        {
            InitializeComponent();
            dgZahtevi.ItemsSource = lekServis.PregledSvihZahtevaLek();
        }

        private void dgZahtevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            if (dgZahtevi.SelectedItem != null) {
                IDRepozitorijum datoteka = new IDRepozitorijum("iDMapLekova");
                Dictionary<int, int> ids = datoteka.dobaviSve();

                int id = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (ids[i] == 0)
                    {
                        id = i;
                        ids[i] = 1;
                        break;
                    }
                }


                ZahtevLek zahtev = (ZahtevLek)dgZahtevi.SelectedItem;
                Lek l = new Lek(id,zahtev.Lek.Proizvodjac,zahtev.Lek.Sastojci,zahtev.Lek.NusPojave,zahtev.Lek.NazivLeka);
                
                 lekServis.DodajLek(l,ids);
             }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
