using Model;
using Service;
using System.Windows;
using ZdravoKorporacija.Stranice.UpravnikCRUD;

namespace ZdravoKorporacija.Stranice.Logovanje
{
    /// <summary>
    /// Interaction logic for upavnikLogin.xaml
    /// </summary>
    public partial class upavnikLogin : Window
    {
        KorisnikService ks = new KorisnikService();
        Korisnik ulogovan;
        UlogaEnum upravnik;
        public upavnikLogin(global::Model.UlogaEnum uloga)
        {
            InitializeComponent();
            this.upravnik = uloga;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ulogovan = ks.Uloguj(this.upravnik, textBoxIme.Text, textBoxSifra.Text);
            if (ulogovan != null)
            {
                this.Close();
                test2 t2 = new test2(ulogovan);
                t2.Show();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
