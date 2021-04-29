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

        public zakaziHitno(ObservableCollection<Termin> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();
            pacijenti = pacijentiDat.dobaviSve();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;
            this.ids = ids;
            lekari = lekariDat.dobaviSve();
            slobodniLekari = lekari;
        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            if(cbTip.SelectedIndex == 0)
            {
               
                provera =  ts.FindPrByPocetak(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)));
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
                if (slobodniLekari.Count() == 0)
                {
                    MessageBox.Show("Nema slobodnih termina ATM!!!");
                    
                }
                else if ( slobodniLekari.Count() != 0)
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


                    zaUpis.Lekar = slobodniLekari.ElementAt<Lekar>(slobodniLekari.Count()-1);
                   
                    zaUpis.Id = id;
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

                    Termin tZaLjekara = new Termin();
                    tZaLjekara.Id = zaUpis.Id;
                    zaUpis.Lekar.AddTermin(tZaLjekara);

                    if (ts.ZakaziTermin(zaUpis, ids))
                    {
                        this.pregledi.Add(zaUpis);
                        lekariDat.sacuvaj(lekari);

                    }
                    pac.AddTermin(zaUpis);
                    ps.AzurirajPacijenta(pac);
                
                    this.Close();

                }
                
            }
            else if (cbTip.SelectedIndex == 1)
            {

            }
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
