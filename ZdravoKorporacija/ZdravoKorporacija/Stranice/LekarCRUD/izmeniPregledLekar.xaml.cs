using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for izmeniPregledLekar.xaml
    /// </summary>
    public partial class izmeniPregledLekar : Page
    {

        private List<LekarDTO> lekari= new List<LekarDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private TerminDTO t1;
        private TerminDTO t2;
        private ZdravstveniKartonKonverter zkk = new ZdravstveniKartonKonverter();


        private TerminService terminServis = new TerminService();
        private ProstorijaService prostorijeStorage = new ProstorijaService();
        private PacijentService pacijentiServis = new PacijentService();

        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();

        private Termin p;
        private Termin s; // selektovani, za ukloniti
        private ObservableCollection<Termin> pregledi;
        private List<Termin> termini;

        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;
        private TerminController controller = new TerminController();
        public izmeniPregledLekar(TerminDTO selektovani)
        {
            InitializeComponent();
            pacijenti = controller.PregledSvihPacijenata2DTO();
            prostorije = controller.PregledSvihProstorijaDTO(null);
            lekari = controller.PregledSvihLekaraDTO(null);


            t1 = selektovani;
            t2 = selektovani;
            cbPacijent.ItemsSource = pacijenti;

            foreach (PacijentDTO p in pacijenti)
            {
                if (selektovani.zdravstveniKarton == null)
                    break;
                if (p.Jmbg == selektovani.zdravstveniKarton.Id)
                {
                    cbPacijent.SelectedItem = p;
                }
            }
            cbProstorija.ItemsSource = prostorije;
            foreach (ProstorijaDTO p in prostorije)
            {
                if (selektovani.prostorija == null)
                {
                    break;
                }
                if (p.Id == selektovani.prostorija.Id)
                {
                    cbProstorija.SelectedItem = p;
                }
            }
            date.SelectedDate = selektovani.Pocetak;
            time.SelectedValue = selektovani.Pocetak.ToString("HH:mm");

            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);


            if (t1.Tip == TipTerminaEnum.Pregled)
            {
                cbTip.SelectedIndex = 0;
            }
            else if (t1.Tip == TipTerminaEnum.Operacija)
            {
                cbTip.SelectedIndex = 1;
            }

            t1.Trajanje = 0.5;
            t1.Id = t2.Id;

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new lekarStart();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            String t = null;
            String d = date.Text;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            PacijentDTO pacijent = (PacijentDTO)cbPacijent.SelectedItem;

            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1 || cbTip.SelectedIndex == -1
               || cbProstorija.SelectedIndex == -1 || cbPacijent.SelectedIndex == -1 )
            {
                MessageBox.Show("Niste popunili sva polja", "Greska");
                return;
            }

            if (cboItem != null)
            {
                t = cboItem.Content.ToString();
                             
                if (d.Equals(today.ToString("dd.M.yyyy.")))
                {
                    if (Int32.Parse(t.Substring(0, 2)) < (now.Substring(9, 8).Equals("po podne") ? popodne: prepodne))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        
                        return;
                    }
                    else if ((Int32.Parse(t.Substring(0, 2))==prepodne || Int32.Parse(t.Substring(0, 2))==popodne) && Int32.Parse(t.Substring(3, 2)) < Int32.Parse(now.Substring(3, 2)))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        return;
                    }
                }

            }
            t1.Pocetak = DateTime.Parse(d + " " + t);
            if (cbTip.SelectedIndex == 0)
            {
                t1.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                t1.Tip = TipTerminaEnum.Operacija;
            }

            t1.Lekar = controller.NadjiLekaraPoJMBG(lekarLogin.jmbg);
            t1.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
            t1.zdravstveniKarton = zkk.KonvertujEntitetUDTO(controller.NadjiKartonID(pacijent.Jmbg));
            if (controller.AzurirajTermin(controller.TerminDTO2Model(t1)))
            {
                controller.PregledSvihTermina().Remove(controller.DTO2ModelNadji(t2));
                controller.PregledSvihTermina().Add(controller.DTO2ModelNadji(t1));
            }
            test.prozor.Content = new lekarStart();

        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}