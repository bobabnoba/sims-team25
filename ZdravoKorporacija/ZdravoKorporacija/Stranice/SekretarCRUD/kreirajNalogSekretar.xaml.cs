using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for kreirajNalogSekretar.xaml
    /// </summary>
    public partial class kreirajNalogSekretar : Window
    {

        private PacijentFileStorage storage = new PacijentFileStorage();
        private DatotekaPacijentJSON pacijentiDat = new DatotekaPacijentJSON();
        private Pacijent nalog = new Pacijent();
        private ObservableCollection<Pacijent> pacijenti;

        public kreirajNalogSekretar(ObservableCollection<Pacijent> nalozi)
        {
            InitializeComponent();
            pacijenti = nalozi;


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {

            string ime = tbime.Text;
            string prezime = tbprezime.Text;
            int jmbg = int.Parse(tbjmbg.Text);
            int br = int.Parse(tbbroj.Text);
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

            Pacijent nalog = new Pacijent(ime, prezime, jmbg, br, mejl, "", pol, username, password, UlogaEnum.Pacijent);

            if (storage.KreirajNalogPacijentu(nalog))
            {
                this.pacijenti.Add(nalog);
                this.Close();
            }

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
