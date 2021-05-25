using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for oktaziPregledLekar.xaml
    /// </summary>
    public partial class oktaziPregledLekar : Window
    {
        private TerminService storage = new TerminService();
        private List<TerminDTO> termini;
        private PacijentService pacijentServis = new PacijentService();
        TerminDTO termin;
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private TerminController controller = new TerminController();

        public oktaziPregledLekar( TerminDTO t, Dictionary<int, int> ids)
        {
            InitializeComponent();
            termini = controller.PregledSvihTermina2DTO(null);
            termin = t;
            this.ids = ids;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.ids[this.termin.Id] = 0;
            controller.ObrisiTerminPacijentu(controller.DTO2ModelNadji(termin));

            controller.OtkaziTermin(controller.DTO2ModelNadji(termin), ids);
            
            termini.Remove(termin);
            
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
