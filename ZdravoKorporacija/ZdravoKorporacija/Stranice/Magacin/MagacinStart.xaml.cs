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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinStart.xaml
    /// </summary>
    public partial class MagacinStart : Window
    {
        Dictionary<int, int> ids = new Dictionary<int, int>();


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
    }
}
