using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        Termin ter;
        Recept r = new Recept();
        IDRepozitorijum datotekaID;

        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        Dictionary<int, int> ids = new Dictionary<int, int>();
        
        public izdajRecept(Pacijent selektovani,ObservableCollection<Recept> recepti)
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
            this.recepti = recepti;
        }

        public izdajRecept(Termin selektovani, ObservableCollection<Recept> recepti)
        {
            InitializeComponent();
            this.DataContext = this;
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            lekovi = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(cdr);
            ter = selektovani;
            lekNaziv.ItemsSource = lekovi;
            foreach(Pacijent p in new List<Pacijent>(pacijentServis.PregledSvihPacijenata()))
            {
                if (p.ZdravstveniKarton != null)
                    if (p.ZdravstveniKarton.Id.Equals(ter.zdravstveniKarton.Id))
                        pac = p;
            }
            recepti = pac.ZdravstveniKarton.GetRecept();
            this.recepti = recepti;
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
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            if (cboItem != null)
            {
                t = cboItem.Content.ToString();
            }

            
            try
            {
                r.Pocetak = DateTime.Parse(Date.Text + " " + t);
            }
            catch(InvalidCastException)
            { }
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
            this.recepti.Add(r);
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
