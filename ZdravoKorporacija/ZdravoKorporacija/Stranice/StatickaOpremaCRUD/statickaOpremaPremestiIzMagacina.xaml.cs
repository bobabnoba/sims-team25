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
        private UpravnikController upravnikKontroler = new UpravnikController();
        private StatickaOpremaService statickaopremaStorage = new StatickaOpremaService();
        private ZahtevPremestanjaService zahteviStorage = new ZahtevPremestanjaService();
        private ProstorijaController prostorijeController = new ProstorijaController();
        private MagacinController magacineController = new MagacinController();

        private ObservableCollection<Termin> pregledi;
        private Termin p = new Termin();
        private Boolean selected;

        private ObservableCollection<ZahtevPremestanjaDTO> listaZahteva = new ObservableCollection<ZahtevPremestanjaDTO>();
        private ZahtevPremestanjaDTO z = new ZahtevPremestanjaDTO();
        private int indeks;
        private Boolean imaZahtev = true;


        DatePicker izborDatuma;
        ComboBox comboBoxSati;

        public statickaOpremaPremestiIzMagacina()
        {
            InitializeComponent();
            upravnikKontroler.DodajIzMagacinaDTO();
            listaZahteva = zahteviStorage.PregledSveOpremeDTO();
            cbMagacin.ItemsSource = magacineController.PregledSveOpremeDTO();
            cbProstorija.ItemsSource = prostorijeController.PregledSvihProstorijaDTO();
            pregledi = new ObservableCollection<Termin>(upravnikKontroler.PregledSvihTermina());


            comboBoxSati = sati;
            izborDatuma = timePicker;

            kalendarInicijalizacija();
            timer();
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
                foreach (ZahtevPremestanjaDTO za in this.listaZahteva)
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

        public void timer() {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += ProveraZahteva;
            timer.Start();
        }

        public void ProveraZahteva(object sender, EventArgs e)
        {


            if (zahteviStorage.PregledSveOpremeDTO() != null)
            {
                z = zahteviStorage.PregledSveOpremeDTO().FirstOrDefault(s => s.Kraj <= DateTime.Now && s.Kraj >= DateTime.Now.AddMinutes(-5));
                if (z == null)
                {
                    imaZahtev = false;
                }
                else { imaZahtev = true; }

            }
            if (z != null && imaZahtev == true)
            {

                zahteviStorage.ObrisiZahtevPremestanja(z);
                statickaopremaStorage.DodajOpremu(z.StatickaOprema, z.Pocetak, "10", z.prostorija);
                MessageBox.Show("zavrsen termin");
                ProstorijaDTO p = z.prostorija;
                StatickaOpremaDTO stat = new StatickaOpremaDTO((InventarDTO)z.StatickaOprema);
                p.statickaOprema = new System.Collections.ArrayList();
                p.statickaOprema.Add(stat);
                prostorijeController.AzurirajProstoriju(p, this.indeks);
                imaZahtev = false;
            }


        }




        public void kalendarInicijalizacija()
        {
            DateTime danas = DateTime.Today;

            for (DateTime tm = danas.AddHours(8); tm < danas.AddHours(22); tm = tm.AddMinutes(30))
            {
               comboBoxSati.Items.Add(tm.ToShortTimeString());

            }

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            izborDatuma.BlackoutDates.Add(kalendar);
        }



    }
}