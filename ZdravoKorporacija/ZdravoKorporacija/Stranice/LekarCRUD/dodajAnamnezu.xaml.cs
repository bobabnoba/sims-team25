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
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for dodajAnamnezu.xaml
    /// </summary>
    public partial class dodajAnamnezu : Window
    {
        private TerminService terminServis = new TerminService();
        private PacijentService pacijentServis = PacijentService.Instance;
        private List<TerminDTO> termini = new List<TerminDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private IzvestajDTO izvestaj = new IzvestajDTO();

        TerminDTO termin = new TerminDTO();

        Dictionary<int, int> ids = new Dictionary<int, int>();
       
        public dodajAnamnezu(TerminDTO selektovani, Dictionary<int, int> ids)
        {
            InitializeComponent();
            this.ids = ids;
            termin = selektovani;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            izvestaj.Simptomi = simptomiText.Text;
            TextRange textRange = new TextRange(opisText.Document.ContentStart, opisText.Document.ContentEnd);
            pacijenti = new List<PacijentDTO>(pacijentServis.PregledSvihPacijenata2());
            izvestaj.Opis = textRange.Text;
            int id = 0;
            Trace.WriteLine(ids[0]);
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

            terminServis.IzdajAnamnezu(izvestaj, termin, ids);
           
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
