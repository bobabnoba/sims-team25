﻿using Model;
using Service;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.Logovanje
{
    /// <summary>
    /// Interaction logic for lekarLogin.xaml
    /// </summary>
    public partial class lekarLogin : Page
    {
        LekarRepozitorijum lr = new LekarRepozitorijum();
        KorisnikService ks = new KorisnikService();
        Korisnik ulogovan;
        public static Lekar lekar = new Lekar();
        public static long jmbg;
        UlogaEnum uloga;
        public lekarLogin(UlogaEnum uloga)
        {
            InitializeComponent();
            this.uloga = uloga;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ulogovan = ks.Uloguj(uloga, imeText.Text, lozinkaText.Password);
            if (ulogovan != null)
            {
                foreach (Lekar l in lr.dobaviSve())
                {
                    if (l.Username.Equals(imeText.Text) && l.Password.Equals(lozinkaText.Password))
                    {
                        lekar = l;
                        test t = new test();
                        t.Show();
                        MainWindow.mw.Close();
                        return;
                    }
                }
            }
        }
    }
}
