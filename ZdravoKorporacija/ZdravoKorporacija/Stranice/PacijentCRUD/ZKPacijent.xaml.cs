using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for ZKPacijent.xaml
    /// </summary>
    public partial class ZKPacijent : Page
    {
        private PacijentController pacijentController = new PacijentController();
        public ZKPacijent(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            PacijentPodaciDTO pacijentZaPrikaz = pacijentController.konvertujUPodaciDTO(pacijentDTO);
            tbIme.DataContext = pacijentZaPrikaz;
            tbPrezime.DataContext = pacijentZaPrikaz;
            tbJmbg.DataContext = pacijentZaPrikaz;
            tbAdresa.DataContext = pacijentZaPrikaz;
            tbKontakt.DataContext = pacijentZaPrikaz;
            tbMejl.DataContext = pacijentZaPrikaz;

        }
    }
}
