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
        IDRepozitorijum datotekaID;

        Dictionary<int, int> ids = new Dictionary<int, int>();
        
        public izdajRecept(Pacijent selektovani)
        {
            InitializeComponent();
            this.DataContext = this;
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            lekovi = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(cdr);
            pac = selektovani;
            lekNaziv.ItemsSource = lekovi;
            recepti = pac.ZdravstveniKarton.GetRecept();     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lek l= (Lek)lekNaziv.SelectedItem;
            if (string.IsNullOrEmpty(NoviLek.Text))
            {
                r.NazivLeka = l.NazivLeka;
                
            }
            else
            {
                r.NazivLeka = NoviLek.Text;
            }
            r.Doziranje = Doza.Text;
            r.Trajanje = Int32.Parse(Trajanje.Text);
            r.Pocetak = Date.SelectedDate.Value.Date;
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }
            r.Id = id;
            recepti.Add(r);
            datotekaID.sacuvaj(ids);
            pacijentServis.AzurirajPacijenta(pac);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NoviLek_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NoviLek.Text))
            {
                lekNaziv.IsEnabled = false;
            }
        }
    }
}
