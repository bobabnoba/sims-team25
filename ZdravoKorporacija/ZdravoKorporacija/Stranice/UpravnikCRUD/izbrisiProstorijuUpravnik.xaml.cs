using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        public izbrisiProstorijuUpravnik(ObservableCollection<Prostorija> pr, Prostorija p)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.prostorijaZaBrsianje = p;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            storage.ObrisiProstoriju(this.prostorijaZaBrsianje);
            prostorije.Remove(this.prostorijaZaBrsianje);
            this.Close();
        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
