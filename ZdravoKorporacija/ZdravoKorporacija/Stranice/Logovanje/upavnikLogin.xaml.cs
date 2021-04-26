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
using ZdravoKorporacija.Stranice.UpravnikCRUD;

namespace ZdravoKorporacija.Stranice.Logovanje
{
    /// <summary>
    /// Interaction logic for upavnikLogin.xaml
    /// </summary>
    public partial class upavnikLogin : Window
    {
        KorisnikService ks = new KorisnikService();
        UlogaEnum upravnik;
        public upavnikLogin(global::Model.UlogaEnum uloga)
        {
            InitializeComponent();
            this.upravnik = uloga;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ks.Uloguj(this.upravnik, textBoxIme.Text, textBoxSifra.Text);
            upravnikPocetna uP = new upravnikPocetna();
            uP.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ks.DodajKorisnika(textBoxIme.Text, textBoxSifra.Text,this.upravnik);
        }
    }
}
