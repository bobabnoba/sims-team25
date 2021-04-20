using Model;
using Repository;
using Service;
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

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for izdajRecept.xaml
    /// </summary>
    public partial class izdajRecept : Window
    {
        private PacijentService pacijentServis = new PacijentService();
        private LekServis lekServis = new LekServis();
        private ObservableCollection<Lek> lekovi;
        private ObservableCollection<Recept> recepti;
        Pacijent pac;
        Recept r = new Recept();
        public izdajRecept(Pacijent selektovani)
        {
            InitializeComponent();
            this.DataContext = this;
            lekovi = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());
            pac = selektovani;
            lekNaziv.ItemsSource = lekovi;
            recepti = pac.ZdravstveniKarton.GetRecept();     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lek l= (Lek)lekNaziv.SelectedItem;
            r.NazivLeka = l.NazivLeka;
            r.Doziranje = Doza.Text;
            r.Trajanje = Int32.Parse(Trajanje.Text);
            recepti.Add(r);
            pacijentServis.AzurirajPacijenta(pac);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
