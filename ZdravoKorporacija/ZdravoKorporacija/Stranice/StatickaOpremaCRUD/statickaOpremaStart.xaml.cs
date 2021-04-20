using Repository;
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


namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaStart.xaml
    /// </summary>
    public partial class statickaOpremaStart : Window
    {
        public statickaOpremaStart()
        {
            InitializeComponent();
            dgStatickaOprema.ItemsSource = StatickaOpremaRepozitorijum.Instance.magacinStatickaOprema;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            statickaOpremaPremestiIzMagacina statickaPremestanjeiIzMagacina = new statickaOpremaPremestiIzMagacina();
            statickaPremestanjeiIzMagacina.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void dgStatickaOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
