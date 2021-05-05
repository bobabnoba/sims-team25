using Model;
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

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for dodajZaposlenog.xaml
    /// </summary>
    public partial class dodajZaposlenog : Window
    {
        
        public dodajZaposlenog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Korisnik osoba = new Korisnik(textBoxIme.Text, textBoxPrezime.Text);
            Registracija registracija = new Registracija(textBoxIme.Text,textBoxPrezime.Text,osoba);
            registracija.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
