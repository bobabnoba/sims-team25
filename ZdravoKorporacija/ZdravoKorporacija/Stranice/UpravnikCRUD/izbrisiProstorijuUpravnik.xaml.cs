using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for izbrisiProstorijuUpravnik.xaml
    /// </summary>
    public partial class izbrisiProstorijuUpravnik : Window
    {
        private ProstorijaFileStorage storage = new ProstorijaFileStorage();
        private ObservableCollection<Prostorija> prostorije;
        private Prostorija prostorijaZaBrsianje;
        Dictionary<int, int> id_map = new Dictionary<int, int>();
        public izbrisiProstorijuUpravnik(ObservableCollection<Prostorija> pr, Prostorija p, Dictionary<int, int> ids)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.prostorijaZaBrsianje = p;
            this.id_map = ids;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            storage.ObrisiProstoriju(this.prostorijaZaBrsianje, this.id_map);
            this.id_map[this.prostorijaZaBrsianje.Id] = 0;
            prostorije.Remove(this.prostorijaZaBrsianje);
            this.Close();
        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
