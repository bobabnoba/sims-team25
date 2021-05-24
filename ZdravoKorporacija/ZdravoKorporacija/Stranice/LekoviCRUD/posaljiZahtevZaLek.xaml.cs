using Controller;
using Model;
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
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for posaljiZahtevZaLek.xaml
    /// </summary>
    public partial class posaljiZahtevZaLek : Window
    {
        LekServis lekServis = new LekServis();
        private ObservableCollection<ZahtevLekDTO> zahteviPrikaz;
        private ZahtevLekDTO zahtev;

        public posaljiZahtevZaLek(ObservableCollection<ZahtevLekDTO> zahteviPrikaz, ZahtevLekDTO zahtevLek)
        {
            InitializeComponent();
            this.zahteviPrikaz = zahteviPrikaz;
            this.zahtev = zahtevLek;
        }
        private void da(object sender, RoutedEventArgs e)
        {
            lekServis.DodajZahtevLeka(zahtev);
            NeodobreniLekController neodobreniLekoviController = new NeodobreniLekController();
            if (neodobreniLekoviController.obrisiNeodobreniLek(this.zahtev)){
                zahteviPrikaz.Remove(zahtev);
            }
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
