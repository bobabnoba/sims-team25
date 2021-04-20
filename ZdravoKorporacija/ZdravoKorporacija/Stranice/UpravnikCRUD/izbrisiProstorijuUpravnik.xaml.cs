using Model;
using Service;
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
        private ProstorijaService storage = new ProstorijaService();
        private ObservableCollection<Prostorija> prostorije;
        private Prostorija prostorijaZaBrisanje;
        Dictionary<int, int> id_map = new Dictionary<int, int>();
        public izbrisiProstorijuUpravnik(ObservableCollection<Prostorija> pr, Prostorija p, Dictionary<int, int> ids)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.prostorijaZaBrisanje = p;
            this.id_map = ids;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.id_map[this.prostorijaZaBrisanje.Id] = 0;
            storage.ObrisiProstoriju(this.prostorijaZaBrisanje, this.id_map);
            prostorije.Remove(this.prostorijaZaBrisanje);
            this.Close();
        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
