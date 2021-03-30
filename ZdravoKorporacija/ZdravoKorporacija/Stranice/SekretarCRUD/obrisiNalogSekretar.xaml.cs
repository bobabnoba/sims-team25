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
            this.pacijenti.Remove(p1);
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
