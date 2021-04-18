using Model;
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

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for pregledPacijenata.xaml
    /// </summary>
    public partial class pregledPacijenata : Window
    {
        private PacijentService storagePacijent = new PacijentService();
        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        public pregledPacijenata()
        {
            InitializeComponent();
            pacijenti = new ObservableCollection<Pacijent>(storagePacijent.PregledSvihPacijenata());
            dgUsers.ItemsSource = pacijenti;
            this.DataContext = this;
        }
        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lekarStart ls = new lekarStart();
            ls.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {   
          
        }

        private void prikazKartona(object sender, RoutedEventArgs e)
        {
            zdravstveniKartonPrikaz zk = new zdravstveniKartonPrikaz((Pacijent)dgUsers.SelectedItem,pacijenti);
            zk.Show();
        }
    }
}
