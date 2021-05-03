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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Stranice.sekretarObavestenja
{
    /// <summary>
    /// Interaction logic for sekretarObavestenja.xaml
    /// </summary>
    public partial class sekretarObavestenja : Page
    {
        private ObavestenjaService os = new ObavestenjaService();
        private List<Notifikacija> obavestenja;
        public sekretarObavestenja()
        {
            InitializeComponent();
            obavestenja = os.pregled();
            globalna.ItemsSource = obavestenja;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kreirajObavestenje ko = new kreirajObavestenje(obavestenja);
            ko.Show();
        }

        private void globalna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Notifikacija n = new Notifikacija();
            n = (Notifikacija)globalna.SelectedItem;
            os.obrisiObavestenje(n.Sadrzaj);
            globalna.ItemsSource = os.pregled(); 
        }
    }
}
