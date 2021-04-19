using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for otkaziPregled.xaml
    /// </summary>
    public partial class otkaziPregled : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini;
        Termin termin;
        private Dictionary<int, int> ids = new Dictionary<int, int>();

        public otkaziPregled(ObservableCollection<Termin> ts, Termin t, Dictionary<int, int> ids)
        {
            InitializeComponent();
            termini = ts;
            termin = t;
            this.ids = ids;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.ids[this.termin.Id] = 0;
            storage.OtkaziTermin(termin, ids);
            termini.Remove(termin);
            //termin.Lekar.RemoveTermin(termin); // provjeri je l ovo radi okej
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
