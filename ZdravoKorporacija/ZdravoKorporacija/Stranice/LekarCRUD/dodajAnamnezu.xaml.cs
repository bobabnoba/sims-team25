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
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for dodajAnamnezu.xaml
    /// </summary>
    public partial class dodajAnamnezu : Window
    {
        private TerminService terminServis = new TerminService();
        private PacijentService pacijentServis = new PacijentService();
        private List<Termin> termini = new List<Termin>();
        private ObservableCollection<Izvestaj> izvestaji = new ObservableCollection<Izvestaj>();
        private Izvestaj izvestaj= new Izvestaj();
        IDRepozitorijum datotekaID;
        Pacijent pac;
        Termin termin = new Termin();

        Dictionary<int, int> ids = new Dictionary<int, int>();
        public dodajAnamnezu(Pacijent selektovani)
        {
            InitializeComponent();
            datotekaID = new IDRepozitorijum("iDMapIzvestaj");
            pac = selektovani;
            ids = datotekaID.dobaviSve();
            termini = terminServis.PregledSvihTermina();
            foreach (Termin t in termini)
            {
                if (t.zdravstveniKarton != null)
                {
                    if (t.zdravstveniKarton.Id.Equals(selektovani.ZdravstveniKarton.Id))
                    {
                        if (t.izvestaj == null)
                        {
                           /* Trace.WriteLine(t.izvestaj.Simptomi);
                            izvestaji.Add(t.izvestaj);*/
                            termin = t;
                        }


                     
                    }
                }
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            izvestaj.Simptomi = simptomiText.Text;
            TextRange textRange = new TextRange(opisText.Document.ContentStart, opisText.Document.ContentEnd );
            izvestaj.Opis = textRange.Text;
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
            izvestaj.Id = id;
            izvestaji.Add(izvestaj);
            Trace.WriteLine(izvestaji[izvestaji.Count-1].Opis);
            Trace.WriteLine(termin.zdravstveniKarton.Id);
            Trace.WriteLine(pac.ZdravstveniKarton.Id);
            termin.izvestaj = izvestaj;
            terminServis.AzurirajTermin(termin);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
