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
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;
using System.Linq;
using Controller;

namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaPremestiIzMagacina.xaml
    /// </summary>
    public partial class statickaOpremaPremestiIzMagacina : Window
    {

        private ProstorijaController prostorijeStorage = new ProstorijaController();
        private StatickaOpremaService statickaopremaStorage = new StatickaOpremaService();
        private MagacinService magacineStorage = new MagacinService();
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();
        private List<Inventar> magacin = new List<Inventar>();
        private List<StatickaOprema> statickaMagacin = new List<StatickaOprema>();

        private ObservableCollection<Termin> pregledi;
        private TerminService terminStorage = new TerminService();
        private Boolean selected;
        private Termin p = new Termin();


        private ZahtevPremestanjaService zahteviStorage = new ZahtevPremestanjaService();
        private List<ZahtevPremestanja> listaZahteva = new List<ZahtevPremestanja>();
        private ZahtevPremestanja z = new ZahtevPremestanja();
        private int indeks;

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
            List<Termin> lista = new List<Termin>();
            lista = terminStorage.PregledSvihTermina();
            pregledi = new ObservableCollection<Termin>(terminStorage.PregledSvihTermina());
            Debug.WriteLine(lista[0].ToString());
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
                sati.Items.Add(tm.ToShortTimeString());

            }

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            timePicker.BlackoutDates.Add(kalendar);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += ProveraZahteva;
            timer.Start();

            listaZahteva = zahteviStorage.PregledSveOpreme();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Inventar inv = (Inventar)cbMagacin.SelectedItem;
            Termin t = new Termin();
            StatickaOprema st = new StatickaOprema(t, inv);

            this.indeks = (int)cbProstorija.SelectedIndex;
            ZahtevPremestanja zp = new ZahtevPremestanja();
            zp.prostorija = (Prostorija)cbProstorija.SelectedItem;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevPremestanja");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            zahteviStorage.ZakaziPremestanje((Inventar)cbMagacin.SelectedItem, zp, (DateTime)timePicker.SelectedDate, (String)sati.SelectedItem, textBoxTrajanje.Text, ids);

            listaZahteva = zahteviStorage.PregledSveOpreme();
        }
        private Boolean x = true;
        public void ProveraZahteva(object sender, EventArgs e)
        {


            if (listaZahteva != null)
            {
                z = listaZahteva.FirstOrDefault(s => s.Kraj <= DateTime.Now && s.Kraj >= DateTime.Now.AddMinutes(-5));
                if (z == null)
                {
                    x = false;
                }
                else { x = true; }

            }
            if (z != null && x == true)
            {
                listaZahteva.Remove(z);
                statickaopremaStorage.DodajOpremu(z.StatickaOprema, z.Pocetak, "10", z.prostorija);
                MessageBox.Show("zavrsen termin");
                ZahtevPremestanjaRepozitorijum.Instance.sacuvaj(listaZahteva);

                Prostorija p = z.prostorija;
                StatickaOprema stat = new StatickaOprema((Inventar)z.StatickaOprema);
                p.statickaOprema = new List<StatickaOprema>();
                p.statickaOprema.Add(stat);


                prostorijeStorage.AzurirajProstoriju(p, this.indeks);
                x = false;
            }


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
            ProveraTermina();
        }



        private void sati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProveraTermina();
        }


        public void ProveraTermina() {
            if (cbProstorija.SelectedIndex != -1)
            {
                selected = true;
            }

            if (selected)
            {
                p.prostorija = (Prostorija)cbProstorija.SelectedItem;
                foreach (ZahtevPremestanja za in this.listaZahteva)
                {
                    foreach (Termin t in pregledi)
                    {
                        if (t.prostorija != null && t.prostorija.Id.Equals(p.prostorija.Id))
                        {
                            if (t.Pocetak.Date.Equals(((DateTime)timePicker.SelectedDate).Date))
                            {
                                sati.Items.Remove(t.Pocetak.ToShortTimeString());
                            }
                        }
                        if (za.prostorija.Id.Equals(p.prostorija.Id))
                        {
                            Debug.WriteLine("Postoji prostorija u zahtevima");
                            DateTime pocetak = za.Pocetak;

                            for (; pocetak < za.Kraj;)
                            {

                                Debug.WriteLine(pocetak.ToShortTimeString());
                                sati.Items.Remove(pocetak.ToShortTimeString());
                                pocetak = pocetak.AddMinutes(30);
                            }
                        }
                    }
                }
                sati.IsEnabled = true;
            }
        }
    }
}