using Model;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for izmeniNalogSekretar.xaml
    /// </summary>
    /// 


    public partial class izmeniNalogSekretar : Window
    {
        private PacijentService storage = new PacijentService();
        private PacijentRepozitorijum dat = new PacijentRepozitorijum();
        private ObservableCollection<Pacijent> pacijenti;
        private Pacijent p1;

        public izmeniNalogSekretar(Pacijent izabrani, ObservableCollection<Pacijent> nalozi)
        {
            InitializeComponent();
            p1 = izabrani;

            pacijenti = nalozi;
            tbime.Text = izabrani.Ime;
            tbprezime.Text = izabrani.Prezime;
            tbjmbg.Text = izabrani.Jmbg.ToString();
            tbbr.Text = izabrani.BrojTelefona.ToString();
            tbmejl.Text = izabrani.Mejl;
            if (p1.Pol == PolEnum.Muski)
            {
                combo.SelectedIndex = 0;
            }
            else
            {
                combo.SelectedIndex = 1;
            }
            tbuser.Text = izabrani.Username;
            tbpass.Text = izabrani.Password;


        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            this.pacijenti.Remove(p1);
            string ime = tbime.Text;
            string prezime = tbprezime.Text;
            long jmbg = long.Parse(tbjmbg.Text);
            int br = int.Parse(tbbr.Text);
            string mejl = tbmejl.Text;
            string username = tbuser.Text;
            string password = tbpass.Text;
            PolEnum pol;
            if (combo.SelectedIndex == 0)
            {
                pol = PolEnum.Muski;
            }
            else
            {
                pol = PolEnum.Zenski;
            }
            
            Pacijent novi = new Pacijent(ime, prezime, jmbg, br, mejl, "", pol, username, password, UlogaEnum.Pacijent);
            novi.ZdravstveniKarton = p1.ZdravstveniKarton;
            if (storage.AzurirajPacijenta(novi))
            {
                this.pacijenti.Add(novi);
                this.Close();

            }


        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
