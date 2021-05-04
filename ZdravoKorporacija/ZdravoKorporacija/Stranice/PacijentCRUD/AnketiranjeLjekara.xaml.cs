using Model;
using Repository;
using System;
using System.Collections.Generic;
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
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for AnketiranjeLjekara.xaml
    /// </summary>
    public partial class AnketiranjeLjekara : Window
    {
        private Anketa anketa;
        private Pacijent pacijent;
        private AnketaRepozitorijum arepo = new AnketaRepozitorijum();
        private List<Anketa> ankete;
        private Termin termin;
        private LekarRepozitorijum ljekariDat = new LekarRepozitorijum();
        private List<Lekar> ljekari;

        public AnketiranjeLjekara(Termin termin, Pacijent pacijent)
        {
            InitializeComponent();
            ljekari = ljekariDat.dobaviSve();
            ljekar.ItemsSource = ljekari;
            foreach (Lekar l in ljekari)
            {
                if (l.Jmbg == termin.Lekar.Jmbg)
                {
                    ljekar.SelectedItem = l;
                }
            }
            this.pacijent = pacijent;
            this.termin = termin;

            IEnumerable<int> ocjene = Enumerable.Range(1, 10);
            ocjenaLjekara.ItemsSource = ocjene;

            anketa = new Anketa();
            ankete = arepo.DobaviSve();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void potvrdi(object sender, RoutedEventArgs e)
        {
            anketa.Id = ankete.Count + 1;
            anketa.IdAutora = pacijent.Jmbg;
            anketa.Datum = DateTime.Parse(DateTime.Now.ToString());
            anketa.Tip = TipAnkete.Ljekar;
            anketa.Ocena = (int)ocjenaLjekara.SelectedItem;
            anketa.Komentar = (new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text;
            anketa.Termin = termin;

            ankete.Add(anketa);
            arepo.Sacuvaj(ankete);

            this.Close();
        }
    }
}
