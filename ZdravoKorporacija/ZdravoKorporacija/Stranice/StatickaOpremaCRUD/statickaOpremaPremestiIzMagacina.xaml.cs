using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;
using System.Linq;
using Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for statickaOpremaPremestiIzMagacina.xaml
    /// </summary>
    public partial class statickaOpremaPremestiIzMagacina : Window
    {
        private UpravnikController uc = new UpravnikController();
        private StatickaOpremaService statickaopremaStorage = new StatickaOpremaService();
        private ZahtevPremestanjaService zahteviStorage = new ZahtevPremestanjaService();
        private ProstorijaController prostorijeController = new ProstorijaController();
        private MagacinController magacineController = new MagacinController();
        private TerminService terminStorage = new TerminService();

        private ObservableCollection<Termin> pregledi;
        private Termin p = new Termin();
        private Boolean selected;

        private List<ZahtevPremestanja> listaZahteva = new List<ZahtevPremestanja>();
        private ZahtevPremestanja z = new ZahtevPremestanja();
        private int indeks;
        private Boolean imaZahtev = true;

        public statickaOpremaPremestiIzMagacina()
        {
            InitializeComponent();
            this.uc.DodajIzMagacina();
            this.listaZahteva = zahteviStorage.PregledSveOpreme();
            cbMagacin.ItemsSource = magacineController.PregledSveOpremeDTO();
            cbProstorija.ItemsSource = prostorijeController.PregledSvihProstorijaDTO();
            pregledi = new ObservableCollection<Termin>(this.uc.PregledSvihTermina());

           
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            InventarDTO inventar = (InventarDTO)cbMagacin.SelectedItem;
            TerminDTO termin = new TerminDTO();
            StatickaOpremaDTO staticka = new StatickaOpremaDTO(termin, inventar);
            ZahtevPremestanjaDTO zahtevPremestanjaDTO = new ZahtevPremestanjaDTO();
            zahtevPremestanjaDTO.StatickaOprema = staticka;
            this.indeks = (int)cbProstorija.SelectedIndex;
           
            zahtevPremestanjaDTO.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
          
            zahteviStorage.ZakaziPremestanje((InventarDTO)cbMagacin.SelectedItem, zahtevPremestanjaDTO, (DateTime)timePicker.SelectedDate, (String)sati.SelectedItem, textBoxTrajanje.Text);

           zahteviStorage.PregledSveOpreme();
        }
       
        public void ProveraZahteva(object sender, EventArgs e)
        {


            if (ZahtevPremestanjaRepozitorijum.Instance.zahtevi != null)
            {
                z = ZahtevPremestanjaRepozitorijum.Instance.zahtevi.FirstOrDefault(s => s.Kraj <= DateTime.Now && s.Kraj >= DateTime.Now.AddMinutes(-5));
                if (z == null)
                {
                    imaZahtev = false;
                }
                else { imaZahtev = true; }

            }
            if (z != null && imaZahtev == true)
            {
                ZahtevPremestanjaRepozitorijum.Instance.zahtevi.Remove(z);
                statickaopremaStorage.DodajOpremu(z.StatickaOprema, z.Pocetak, "10", z.prostorija);
                MessageBox.Show("zavrsen termin");
                ZahtevPremestanjaRepozitorijum.Instance.sacuvaj();

                ProstorijaDTO p = new ProstorijaDTO();
                 //z.prostorija;
                StatickaOprema stat = new StatickaOprema((Inventar)z.StatickaOprema);
                //p.statickaOprema = new List<StatickaOprema>();
                //p.statickaOprema.Add(stat);


                prostorijeController.AzurirajProstoriju(p, this.indeks);
                imaZahtev = false;
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
               ProstorijaDTO prost = (ProstorijaDTO)cbProstorija.SelectedItem;
                p.prostorija = new Prostorija(prost);
                foreach (Termin t in pregledi)
                {
                    if (t.prostorija != null && t.prostorija.Id.Equals(p.prostorija.Id))
                    {
                        if (t.Pocetak.Date.Equals(((DateTime)timePicker.SelectedDate).Date))
                        {
                            sati.Items.Remove(t.Pocetak.ToShortTimeString());
                        }
                    }
                }
                foreach (ZahtevPremestanja za in this.listaZahteva)
                {
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
                sati.IsEnabled = true;
            }
        }
    }
}