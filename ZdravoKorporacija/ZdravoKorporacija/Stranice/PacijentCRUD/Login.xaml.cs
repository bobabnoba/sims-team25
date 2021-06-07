using Model;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private KorisnikController korisnikController = new KorisnikController();
        private UlogaEnum uloga;

        public Login(UlogaEnum uloga)
        {
            InitializeComponent();
            this.uloga = uloga;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PacijentDTO ulogovani =
                korisnikController.ulogovaniPacijent(uloga, imeText.Text, lozinkaText.Password);
            if (ulogovani != null)
            {
                pocetna2 pocetna = new pocetna2(ulogovani);
                pocetna.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Neispravan unos. Molimo pokušajte ponovo.", "Neuspešno logovanje");
            }


        }
    }
}
