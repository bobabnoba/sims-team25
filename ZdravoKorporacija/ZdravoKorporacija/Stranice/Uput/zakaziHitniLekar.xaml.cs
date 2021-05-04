
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for zakaziHitno.xaml
    /// </summary>
    public partial class zakaziHitniLekar : Window
    {
        private TerminService ts = new TerminService();
        private PacijentRepozitorijum pacijentiDat = new PacijentRepozitorijum();
        private Termin termin;
        private List<Termin> provera = new List<Termin>();
        private List<Pacijent> pacijenti = new List<Pacijent>();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private ObservableCollection<Termin> pregledi;
        private PacijentService ps = new PacijentService();
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private List<Lekar> lekari = new List<Lekar>();
        List<Lekar> slobodniLekari = new List<Lekar>();
        private List<Prostorija> slobodneProstorije;
        private List<Prostorija> prostorije = new List<Prostorija>();
        private ProstorijaRepozitorijum pRep = new ProstorijaRepozitorijum();
        private ObservableCollection<Termin> alternativniTermini;
        Boolean slobodan = false;
        DateTime slobodanPocetak;

        public zakaziHitniLekar(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;
            this.ids = ids;
            lekari = lekariDat.dobaviSve();
            slobodniLekari = lekari;

            alternativniTermini = new ObservableCollection<Termin>();

            prostorije = pRep.dobaviSve();

            slobodneProstorije = prostorije;
            alternative.ItemsSource = alternativniTermini;

        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {

            Termin zaUpis = new Termin();
            for (int i = 30; i < 300; i += 30)
            {
                foreach (Termin t in pregledi)
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
                foreach (Termin t in pregledi)
                {
                    if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Pregled && t.hitno == false)
                    {
                        alternativniTermini.Add(t);
                    }
                }
               
                provera = ts.FindPrByPocetak(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                foreach (Termin t in pregledi)
                {
                    if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                    {
                        foreach (Lekar l in lekari.ToArray())
                        {
                            if (l.Jmbg.Equals(t.Lekar.Jmbg))
                            {
                                slobodniLekari.Remove(l);
                            }
                        }
                    }
                }
                foreach (Termin t in pregledi)
                {
                    provera = ts.FindPrByPocetak(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                    {
                        foreach (Prostorija p in prostorije.ToArray())
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


                    zaUpis.Lekar = slobodniLekari.ElementAt<Lekar>(slobodniLekari.Count() - 1);
                    zaUpis.prostorija = slobodneProstorije.ElementAt<Prostorija>(slobodneProstorije.Count() - 1);

                    zaUpis.Id = id;
                    zaUpis.hitno = true;
                    
                    zaUpis.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
                    Pacijent pac = (Pacijent)cbPacijent.SelectedItem;




                    zaUpis.Tip = TipTerminaEnum.Pregled;
                    if (pac.ZdravstveniKarton != null)
                        zaUpis.zdravstveniKarton = pac.ZdravstveniKarton;
                    else
                    {
                        pac.ZdravstveniKarton = new ZdravstveniKarton(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                        pac.ZdravstveniKarton = new ZdravstveniKarton(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                    }

                    Termin tZaLekara = new Termin();
                    tZaLekara.Id = zaUpis.Id;
                    zaUpis.Lekar.AddTermin(tZaLekara);

                    if (ts.ZakaziTermin(zaUpis, ids))
                    {
                        this.pregledi.Add(zaUpis);
                        lekari = lekariDat.dobaviSve();
                        lekariDat.sacuvaj(lekari);

                    }
                    pac.AddTermin(zaUpis);
                    ps.AzurirajPacijenta(pac);

                    this.Close();

                }

            }
            else if (cbTip.SelectedIndex == 1)
            {
                foreach (Termin t in pregledi)
                {
                    if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Operacija && t.hitno == false)
                    {
                        alternativniTermini.Add(t);
                    }
                }
                provera = ts.FindPrByPocetak(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                foreach (Termin t in pregledi)
                {
                    if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                    {
                        foreach (Lekar l in lekari.ToArray())
                        {
                            if (l.Jmbg.Equals(t.Lekar.Jmbg))
                            {
                                slobodniLekari.Remove(l);
                            }
                        }
                    }
                }
                foreach (Termin t in pregledi)
                {
                    provera = ts.FindPrByPocetak(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
                    {
                        foreach (Prostorija p in prostorije.ToArray())
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


                    zaUpis.Lekar = slobodniLekari.ElementAt<Lekar>(slobodniLekari.Count() - 1);
                    zaUpis.prostorija = slobodneProstorije.ElementAt<Prostorija>(slobodneProstorije.Count() - 1);

                    zaUpis.Id = id;
                    zaUpis.hitno = true;

                    zaUpis.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
                    Pacijent pac = (Pacijent)cbPacijent.SelectedItem;




                    zaUpis.Tip = TipTerminaEnum.Operacija;
                    if (pac.ZdravstveniKarton != null)
                        zaUpis.zdravstveniKarton = pac.ZdravstveniKarton;
                    else
                    {
                        pac.ZdravstveniKarton = new ZdravstveniKarton(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                        pac.ZdravstveniKarton = new ZdravstveniKarton(null, pac.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                    }

                    Termin tZaLekara = new Termin();
                    tZaLekara.Id = zaUpis.Id;
                    zaUpis.Lekar.AddTermin(tZaLekara);

                    if (ts.ZakaziTermin(zaUpis, ids))
                    {
                        this.pregledi.Add(zaUpis);
                        lekari = lekariDat.dobaviSve();
                        lekariDat.sacuvaj(lekari);

                    }
                    pac.AddTermin(zaUpis);
                    ps.AzurirajPacijenta(pac);

                    this.Close();
                }
            }
            foreach (Termin term in pregledi)
            {
                if (term.Pocetak.Equals(zaUpis.Pocetak) && !term.Id.Equals(zaUpis.Id))
                {
                    
                    term.Pocetak = slobodanPocetak;
                    if (ts.AzurirajTermin(term))
                    {
                       // this.pregledi = (ObservableCollection<Termin>)(ts.PregledSvihTermina()) ;
                    }
                }
            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void zameni(object sender, RoutedEventArgs e)
        {
            Termin t = new Termin();
            t = (Termin)alternative.SelectedItem;
            foreach (Termin term in alternativniTermini)
            {
                if (term.Id.Equals(t.Id))
                {

                    Pacijent pac = (Pacijent)cbPacijent.SelectedItem;
                    term.zdravstveniKarton = pac.ZdravstveniKarton;
                    if (ts.AzurirajTermin(term))
                    {
                        this.pregledi.Remove(t);
                        this.pregledi.Add(term);
                    }
                    this.Close();
                }
            }
        }
    }
}
