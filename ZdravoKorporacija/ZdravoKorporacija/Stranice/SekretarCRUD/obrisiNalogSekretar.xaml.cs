using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for obrisiNalogSekretar.xaml
    /// </summary>
    public partial class obrisiNalogSekretar : Window
    {
        private PacijentFileStorage storage = new PacijentFileStorage();
        private DatotekaPacijentJSON dat = new DatotekaPacijentJSON();
        private ObservableCollection<Pacijent> pacijenti;
        private Pacijent p1;
        public obrisiNalogSekretar(Pacijent selected, ObservableCollection<Pacijent> nalozi)
        {
            InitializeComponent();
            p1 = selected;
            pacijenti = nalozi;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            storage.ObrisiNalogPacijentu(p1);

            this.pacijenti.Remove(p1);
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
