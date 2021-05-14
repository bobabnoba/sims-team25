using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using Repository;
using Service;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for zakaziHitno.xaml
    /// </summary>
    public partial class zakaziHitno : Window
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
        private ObservableCollection<Prostorija> slobodneProstorije;
        private ObservableCollection<Prostorija> prostorije = new ObservableCollection<Prostorija>();
        private ProstorijaRepozitorijum pRep = ProstorijaRepozitorijum.Instance;
        private ObservableCollection<Termin> alternativniTermini;
        private bool kardio ;
        private bool neuro;
        

        public zakaziHitno(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();
            kardio = false;
            neuro = false;
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
                  /*  if (kardio)
                    {
                       foreach(Lekar l1 in slobodniLekari)
                        {
                            foreach(Specijalista s in MainWindow.spec)
                            {
                                if(s.Specijalizacija.Equals(SpecijalizacijaEnum.Kardiohirurg))
                                {
                                    if(!l1.Ime.Equals(s.Ime) && !l1.Prezime.Equals(s.Prezime))
                                    {
                                        slobodniLekari.Remove(l1);
                                    }
                                }
                            }
                        }
                    }
                    else if (neuro)
                    {
                        foreach (Specijalista s in MainWindow.spec)
                        {
                            if (s.Specijalizacija == SpecijalizacijaEnum.Neurolog)
                            {
                                foreach (Lekar l1 in slobodniLekari.ToList())
                                {
                                    if (!l1.Ime.Equals(s.Ime) && !l1.Prezime.Equals(s.Prezime))
                                        slobodniLekari.Remove(l1);
                                }
                            }
                        }
                    }           */
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
                    Termin zaUpis = new Termin();
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
                    Termin zaUpis = new Termin();
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
                    zaUpis.Pocetak = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
                    Pacijent pac = (Pacijent)cbPacijent.SelectedItem;




                    zaUpis.Tip = TipTerminaEnum.Operacija;
                    zaUpis.hitno = true;
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
            foreach(Termin term in alternativniTermini)
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            kardio = true;
            
            
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            neuro = true;
            
        }
    }
}
