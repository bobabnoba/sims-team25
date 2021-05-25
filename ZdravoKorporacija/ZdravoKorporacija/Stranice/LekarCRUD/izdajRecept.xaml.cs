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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for izdajRecept.xaml
    /// </summary>
    public partial class izdajRecept : Window
    {
        private PacijentController pacijentController = PacijentController.Instance;
        private LekServis lekServis = new LekServis();
        private ObservableCollection<Lek> lekovi;
        PacijentDTO pac;
        TerminDTO ter;
        ReceptDTO r = new ReceptDTO();

        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        public izdajRecept(PacijentDTO selektovani)
        {
            InitializeComponent();
            this.DataContext = this;
            lekovi = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(cdr);
            pac = selektovani;
            lekNaziv.ItemsSource = lekovi;

        }

        public izdajRecept(TerminDTO selektovani)
        {
            InitializeComponent();
            this.DataContext = this;
      
            lekovi = new ObservableCollection<Lek>(lekServis.PregledSvihLekova());

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            Date.BlackoutDates.Add(cdr);
            ter = selektovani;
            lekNaziv.ItemsSource = lekovi;
            foreach (PacijentDTO p in pacijentController.PregledSvihPacijenata2())
            {
                if (p.ZdravstveniKarton != null)
                    if (p.ZdravstveniKarton.Id.Equals(ter.zdravstveniKarton.Id))
                        pac = p;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LekDTO l = (LekDTO)lekNaziv.SelectedItem;
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
            catch (InvalidCastException)
            { }


            pacijentController.IzdajRecept(pac, r);
            zdravstveniKartonPrikaz.recepti.Add(r);
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
