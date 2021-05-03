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
using ZdravoKorporacija.DTO;
using System.Linq;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for Renoviranje.xaml
    /// </summary>
    public partial class Renoviranje : Window
    {
        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private List<Prostorija> prostorije = new List<Prostorija>();
        RenoviranjeService rs = new RenoviranjeService();
        public Renoviranje(int index)
        {
            InitializeComponent();
            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;
            cbProstorija.SelectedIndex = index ;

            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                sati.Items.Add(tm.ToShortTimeString());

            }
        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ZahtevRenoviranjeDTO zahtevRenoviranje = new ZahtevRenoviranjeDTO(0,(Prostorija) cbProstorija.SelectedItem, (DateTime)timePicker.SelectedDate, (String)sati.SelectedItem, textBoxTrajanje.Text);

            rs.ZakaziRenoviranje(zahtevRenoviranje);
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void date_changed(object sender, SelectionChangedEventArgs e)
        { 
        
        }

            private void sati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
