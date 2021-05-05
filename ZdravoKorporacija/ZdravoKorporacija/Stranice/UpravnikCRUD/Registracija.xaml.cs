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

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        KorisnikService ks = new KorisnikService();
        Korisnik registrovani;
        public Registracija(String ime, String prezime, Korisnik osoba)
        {
            InitializeComponent();
            naziv.Content = "Registruješ " + ime +" "+prezime;
            this.registrovani = osoba;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.registrovani.Username = textBoxUsername.Text;
            this.registrovani.Password = textBoxPassword.Text;

            ks.DodajKorisnika(this.registrovani);
        }
    }
}
