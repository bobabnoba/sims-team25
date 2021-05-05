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
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for obrisiZahtevZaLek.xaml
    /// </summary>
    public partial class obrisiZahtevZaLek : Window
    {
        LekServis lekServis = new LekServis();
        private ObservableCollection<ZahtevLek> zahteviPrikaz;
        private ZahtevLek zahtev;
        private Dictionary<int, int> ids = new Dictionary<int, int>();

        public obrisiZahtevZaLek(ObservableCollection<ZahtevLek> zahteviPrikaz, ZahtevLek zahtevLek, Dictionary<int, int> ids)
        {
            InitializeComponent();
            this.zahteviPrikaz = zahteviPrikaz;
            this.zahtev = zahtevLek;
            this.ids = ids;
        }
        private void da(object sender, RoutedEventArgs e)
        {
            this.ids[this.zahtev.Id] = 0;
            lekServis.ObrisiZahtevZaLek(zahtev, ids);
            zahteviPrikaz.Remove(zahtev);
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
