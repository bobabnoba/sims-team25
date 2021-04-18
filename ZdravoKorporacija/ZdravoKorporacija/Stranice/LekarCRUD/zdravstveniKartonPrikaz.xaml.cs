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

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zdravstveniKartonPrikaz.xaml
    /// </summary>
    public partial class zdravstveniKartonPrikaz : Window
    {
        private ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        private ObservableCollection<ZdravstveniKarton> zdravstveniKartoni = new ObservableCollection<ZdravstveniKarton>();
        private DijagnozaServis dijagnozaServis = new DijagnozaServis();
        private Pacijent p;
        private Pacijent s;
        private ObservableCollection<Dijagnoza> dijagnoze = new ObservableCollection<Dijagnoza>();

        public zdravstveniKartonPrikaz(Pacijent selektovani, ObservableCollection<Pacijent> pacijenti)
        {
         InitializeComponent();
            p = selektovani;
            s = selektovani;
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());
            dgUsers.ItemsSource = dijagnoze;
            this.DataContext = this;

            ImeLabel.Content = selektovani.Ime;
            PrezimeLabel.Content = selektovani.Prezime;
            BrojTelefonaLabel.Content = selektovani.BrojTelefona;
            JMBGLabel.Content = selektovani.Jmbg;
            PolLabel.Content = selektovani.Pol;
            /*try { KrvnaGrupaLabel.Content = selektovani.ZdravstveniKarton.KrvnaGrupa; }
            catch(NullReferenceException ex)
            { }*/
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KrvnaGrupaLabel_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
