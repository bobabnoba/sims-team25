using Model;
using Repository;
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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.Model;


namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinStart.xaml
    /// </summary>
    public partial class MagacinStart : Window
    {
        Dictionary<int, int> ids = new Dictionary<int, int>();

        ObservableCollection<Inventar> filtrirana_oprema = new ObservableCollection<Inventar>();

        public MagacinStart()
        {
            InitializeComponent();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapMagacin");
            ids = datotekaID.dobaviSve();
            UpravnikController uc = new UpravnikController();
            uc.DodajIzMagacina();
            dgMagacinOprema.ItemsSource = MagacinRepozitorijum.Instance.magacinOprema;
           
        }

        private void dgMagacinOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgMagacinOprema.ItemsSource = MagacinRepozitorijum.Instance.magacinOprema;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinDodavanje mc = new MagacinDodavanje(ids);
            mc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.filtrirana_oprema = new ObservableCollection<Inventar>();
            foreach (Inventar inv in MagacinRepozitorijum.Instance.magacinOprema)
            {
                if (inv.Naziv.Contains(searchBox.Text))
                {
                    filtrirana_oprema.Add(inv);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (filtrirana_oprema != null) {
                dgMagacinOprema.ItemsSource = this.filtrirana_oprema;
            }
        }
    }
}
