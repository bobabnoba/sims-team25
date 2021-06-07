
using Controller;
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for zakaziHitno.xaml
    /// </summary>
    public partial class zakaziHitniLekar : Page
    {
        private TerminService ts = new TerminService();
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private Termin termin;
        private List<TerminDTO> provera = new List<TerminDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private ObservableCollection<TerminDTO> pregledi;
        private PacijentService ps = new PacijentService();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<LekarDTO> lekari = new List<LekarDTO>();
        List<LekarDTO> slobodniLekari = new List<LekarDTO>();
        private ObservableCollection<ProstorijaDTO> slobodneProstorije;
        private ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
        private ProstorijaRepozitorijum pRep = ProstorijaRepozitorijum.Instance;
        private ObservableCollection<TerminDTO> alternativniTermini;
        PacijentController pacijentController = new PacijentController();
        TerminController terminController = TerminController.Instance;
        LekarController lekarController = new LekarController();
        ProstorijaController prostorijaController = new ProstorijaController();
        Boolean slobodan = false;
        DateTime slobodanPocetak;

        public zakaziHitniLekar(ObservableCollection<TerminDTO> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();
            pacijenti = pacijentController.PregledSvihPacijenata2();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;
            this.ids = ids;
            lekari = (List<LekarDTO>)lekarController.dobaviListuDTOLekara();
            slobodniLekari = lekari;

            alternativniTermini = new ObservableCollection<TerminDTO>();

            prostorije = prostorijaController.PregledSvihProstorijaDTO();

            slobodneProstorije = prostorije;
            alternative.ItemsSource = alternativniTermini;

        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {

            TerminDTO zaUpis = new TerminDTO();
            for (int i = 30; i < 300; i += 30)
            {
                foreach (TerminDTO t in pregledi)
                {
                    if (t.hitno == false)
                    {
                        if (t.Pocetak != RoundUp(DateTime.Now, TimeSpan.FromMinutes(i)))
                        {
                            slobodan = true;
                        }
                        else
                        {
                            slobodan = false;
                            break;
                        }
                    }
                }
                if (slobodan)
                {
                    slobodanPocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(i));
                    break;
                }
            }
            if (cbTip.SelectedIndex == 0)
            {
                foreach (TerminDTO t in pregledi)
                {
                    if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Pregled && t.hitno == false)
                    {
                        alternativniTermini.Add(t);
                    }
                }

                provera = ts.FindPrByPocetak2(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                foreach (TerminDTO t in pregledi)
                {
                    if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                    {
                        foreach (LekarDTO l in lekari.ToArray())
                        {
                            if (l.Jmbg.Equals(t.Lekar.Jmbg))
                            {
                                slobodniLekari.Remove(l);
                            }
                        }
                    }
                }
                foreach (TerminDTO t in pregledi)
                {
                    provera = ts.FindPrByPocetak2(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                    {
                        foreach (ProstorijaDTO p in prostorije.ToArray())
                        {
                            if (t.prostorija.Id.Equals(p.Id))
                            {
                                slobodneProstorije.Remove(p);
                            }
                        }
                    }
                }
                if (slobodniLekari.Count() == 0 || slobodneProstorije.Count() == 0)
                {
                    MessageBox.Show("Nema slobodnih termina ATM!!!");
                    alternative.Visibility = Visibility.Visible;



                }
                else if (slobodniLekari.Count() != 0 && slobodneProstorije.Count() != 0)
                {
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


                    //zaUpis.Lekar = slobodniLekari.ElementAt<Lekar>(slobodniLekari.Count() - 1);
                    //zaUpis.prostorija = slobodneProstorije.ElementAt<Prostorija>(slobodneProstorije.Count() - 1);

                    zaUpis.Id = id;
                    zaUpis.hitno = true;

                    zaUpis.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
                    PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;




                    zaUpis.Tip = TipTerminaEnum.Pregled;
                    if (pac.ZdravstveniKarton != null)
                        zaUpis.zdravstveniKarton = pac.ZdravstveniKarton;
                    else
                    {
                        pac.ZdravstveniKarton = new ZdravstveniKartonDTO(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                        pac.ZdravstveniKarton = new ZdravstveniKartonDTO(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                    }

                    TerminDTO tZaLekara = new TerminDTO();
                    tZaLekara.Id = zaUpis.Id;
                    zaUpis.Lekar.AddTermin(tZaLekara);

                    if (ts.ZakaziTermin(zaUpis, pac))
                    {
                        this.pregledi.Add(zaUpis);
                        lekari = (List<LekarDTO>)lekarController.dobaviListuDTOLekara();
                        //lekariDat.sacuvaj(lekari);

                    }
                }

            }
            else if (cbTip.SelectedIndex == 1)
            {
                foreach (TerminDTO t in pregledi)
                {
                    if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Operacija && t.hitno == false)
                    {
                        alternativniTermini.Add(t);
                    }
                }
                provera = ts.FindPrByPocetak2(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                foreach (TerminDTO t in pregledi)
                {
                    if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                    {
                        foreach (LekarDTO l in lekari.ToArray())
                        {
                            if (l.Jmbg.Equals(t.Lekar.Jmbg))
                            {
                                slobodniLekari.Remove(l);
                            }
                        }
                    }
                }
                foreach (TerminDTO t in pregledi)
                {
                    provera = ts.FindPrByPocetak2(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                    {
                        foreach (ProstorijaDTO p in prostorije.ToArray())
                        {
                            if (t.prostorija.Id.Equals(p.Id))
                            {
                                slobodneProstorije.Remove(p);
                            }
                        }
                    }
                }
                if (slobodniLekari.Count() == 0 || slobodneProstorije.Count() == 0)
                {
                    MessageBox.Show("Nema slobodnih termina ATM!!!");
                    alternative.Visibility = Visibility.Visible;



                }
                else if (slobodniLekari.Count() != 0 && slobodneProstorije.Count() != 0)
                {
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


                    //zaUpis.Lekar = slobodniLekari.ElementAt<Lekar>(slobodniLekari.Count() - 1);
                    //zaUpis.prostorija = slobodneProstorije.ElementAt<Prostorija>(slobodneProstorije.Count() - 1);

                    zaUpis.Id = id;
                    zaUpis.hitno = true;

                    zaUpis.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
                    PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;




                    zaUpis.Tip = TipTerminaEnum.Operacija;
                    if (pac.ZdravstveniKarton != null)
                        zaUpis.zdravstveniKarton = pac.ZdravstveniKarton;
                    else
                    {
                        pac.ZdravstveniKarton = new ZdravstveniKartonDTO(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                        pac.ZdravstveniKarton = new ZdravstveniKartonDTO(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                    }

                    TerminDTO tZaLekara = new TerminDTO();
                    tZaLekara.Id = zaUpis.Id;
                    zaUpis.Lekar.AddTermin(tZaLekara);

                    if (ts.ZakaziTermin(zaUpis, pac))
                    {
                        this.pregledi.Add(zaUpis);
                        lekari = (List<LekarDTO>)lekarController.dobaviListuDTOLekara();
                        //lekariDat.sacuvaj(lekari);

                    }

                    test.prozor.Content = new Uputi();
                }
            }
            foreach (TerminDTO term in pregledi)
            {
                if (term.Pocetak.Equals(zaUpis.Pocetak) && !term.Id.Equals(zaUpis.Id))
                {
                    pregledi.Remove(term);
                    term.Pocetak = slobodanPocetak;
                    if (ts.AzurirajTermin(term))
                    {
                        Trace.WriteLine("uso");
                        pregledi.Add(term);
                        break;
                        // this.pregledi = (ObservableCollection<Termin>)(ts.PregledSvihTermina()) ;
                    }
                }
            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new Uputi();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void zameni(object sender, RoutedEventArgs e)
        {
            TerminDTO t = new TerminDTO();
            t = (TerminDTO)alternative.SelectedItem;
            foreach (TerminDTO term in alternativniTermini)
            {
                if (term.Id.Equals(t.Id))
                {

                    PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;
                    term.zdravstveniKarton = pac.ZdravstveniKarton;
                    if (ts.AzurirajTermin(term))
                    {
                        this.pregledi.Remove(t);
                        this.pregledi.Add(term);
                    }
                    test.prozor.Content = new Uputi();
                }
            }
        }
    }
}
