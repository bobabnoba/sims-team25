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
    /// Interaction logic for obrisiNeodobreniLek.xaml
    /// </summary>
    public partial class obrisiNeodobreniLek : Window
    {
        LekServis lekServis = new LekServis();
        private ObservableCollection<ZahtevLekDTO> zahteviNeodobreniLek;
        private ZahtevLekDTO zahtev;
        private Dictionary<int, int> ids = new Dictionary<int, int>();

        public obrisiNeodobreniLek(ObservableCollection<ZahtevLekDTO> zahteviLek, ZahtevLekDTO zahtevLek)
        {
            InitializeComponent();
            this.zahteviNeodobreniLek = zahteviLek;
            this.zahtev = zahtevLek;
            this.ids = ids;
        }
        private void da(object sender, RoutedEventArgs e)
        {
            NeodobreniLekController neodobreniLekoviController = new NeodobreniLekController();
            if (neodobreniLekoviController.obrisiNeodobreniLek(this.zahtev)){
                this.zahteviNeodobreniLek.Remove(zahtev);
            }
            this.Close();
        }
        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
