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

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for AnketiranjeBolnice.xaml
    /// </summary>
    public partial class AnketiranjeBolnice : Window
    {
        private Anketa anketa;
        private Pacijent pacijent;
        private AnketaRepozitorijum arepo = new AnketaRepozitorijum();
        private List<Anketa> ankete;
        public AnketiranjeBolnice(Pacijent pacijent)
        {
            InitializeComponent();
            IEnumerable<int> ocjene = Enumerable.Range(1, 10);
            ocjenaBolnice.ItemsSource = ocjene;

            anketa = new Anketa();
            this.pacijent = pacijent;

            ankete = arepo.DobaviSve();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void potvrdi(object sender, RoutedEventArgs e)
        {
            anketa.Tip = TipAnkete.Bolnica;
            anketa.Termin = null;
            anketa.Id = arepo.DobaviSve().Count + 1;
            anketa.IdAutora = pacijent.Jmbg;
            anketa.Ocena = (int)ocjenaBolnice.SelectedItem;
            anketa.Komentar = (new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd)).Text;
            anketa.Datum = DateTime.Parse(DateTime.Now.ToString());

            ankete.Add(anketa);
            arepo.Sacuvaj(ankete);

            this.Close();
        }
    }
}
