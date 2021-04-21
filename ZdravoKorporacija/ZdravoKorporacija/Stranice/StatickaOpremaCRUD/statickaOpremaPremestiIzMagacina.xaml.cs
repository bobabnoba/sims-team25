using Model;
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
using ZdravoKorporacija.Model;



namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaPremestiIzMagacina.xaml
    /// </summary>
    public partial class statickaOpremaPremestiIzMagacina : Window
    {

        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private StatickaOpremaService statickaopremaStorage = new StatickaOpremaService();
        private MagacinService magacineStorage = new MagacinService();
        private List<Prostorija> prostorije = new List<Prostorija>();
        private List<Inventar> magacin = new List<Inventar>();
        private List<StatickaOprema> statickaMagacin = new List<StatickaOprema>();

        private ObservableCollection<Termin> pregledi;
        private TerminService terminStorage = new TerminService();
        private Boolean selected;
        private Termin p = new Termin();

        public statickaOpremaPremestiIzMagacina()
        {
            InitializeComponent();
            UpravnikController uc = new UpravnikController();
            uc.DodajIzMagacina();

            magacin = magacineStorage.PregledSveOpreme();
            cbMagacin.ItemsSource = magacin;
            prostorije = prostorijeStorage.PregledSvihProstorija();
            cbProstorija.ItemsSource = prostorije;

            pregledi = new ObservableCollection<Termin>(uc.PregledSvihTermina());
            //cbTermini.ItemsSource = uc.PregledSvihTermina();
            List<Termin> lista = new List<Termin>();
            lista = terminStorage.PregledSvihTermina();
            pregledi = new ObservableCollection<Termin>(terminStorage.PregledSvihTermina());
            Debug.WriteLine(lista[0].ToString());
            //cbTermini.ItemsSource = pregledi;
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                sati.Items.Add(tm.ToShortTimeString());

            }

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            timePicker.BlackoutDates.Add(kalendar);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            
            Inventar inv = (Inventar)cbMagacin.SelectedItem;
            Termin t = new Termin();
            StatickaOprema st = new StatickaOprema(t, inv);
            statickaopremaStorage.DodajOpremu(st, (DateTime)timePicker.SelectedDate,(String)sati.SelectedItem,(Prostorija)cbProstorija.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void cbProstorija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbMagacin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void date_changed(object sender, SelectionChangedEventArgs e)
        {
            if (cbProstorija.SelectedIndex != -1)
            {
                selected = true;
            }

            if (selected)
            {
                p.prostorija = (Prostorija)cbProstorija.SelectedItem;
                foreach (Termin t in pregledi)
                {
                    if (t.prostorija.Id.Equals(p.prostorija.Id))
                    {
                        if (t.Pocetak.Date.Equals(((DateTime)timePicker.SelectedDate).Date))
                        {
                            sati.Items.Remove(t.Pocetak.ToShortTimeString());
                        }
                    }
                }
                sati.IsEnabled = true;
            }

        }

       

        private void sati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProstorija.SelectedIndex != -1)
            {
                selected = true;
            }

            if (selected)
            {
                p.prostorija = (Prostorija)cbProstorija.SelectedItem;
                foreach (Termin t in pregledi)
                {
                    if (t.prostorija.Id.Equals(p.prostorija.Id))
                    {
                        if (t.Pocetak.Date.Equals(((DateTime)timePicker.SelectedDate).Date))
                        {
                            sati.Items.Remove(t.Pocetak.ToShortTimeString());
                        }
                    }
                }
                sati.IsEnabled = true;
            }

        }
    }
}
