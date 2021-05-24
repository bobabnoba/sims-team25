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

namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaStart.xaml
    /// </summary>
    public partial class statickaOpremaStart : Page
    {

        private UpravnikController upravnikKontroler = new UpravnikController();
        public statickaOpremaStart()
        {
            InitializeComponent();
            dgStatickaOprema.ItemsSource = upravnikKontroler.PregledMagacinaStaticke();
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            statickaOpremaPremestiIzMagacina statickaPremestanjeiIzMagacina = new statickaOpremaPremestiIzMagacina();
            statickaPremestanjeiIzMagacina.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void dgStatickaOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
