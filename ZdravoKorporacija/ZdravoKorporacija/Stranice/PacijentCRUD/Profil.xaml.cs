using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        private PacijentController pacijentController = new PacijentController();
        private PacijentDTO pacijentDTO;
        public Profil(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;


            PacijentPodaciDTO pacijentZaPrikaz = pacijentController.konvertujUPodaciDTO(pacijentDTO);
            tbIme.DataContext = pacijentZaPrikaz;
            tbPrezime.DataContext = pacijentZaPrikaz;
            tbJmbg.DataContext = pacijentZaPrikaz;
            tbAdresa.DataContext = pacijentZaPrikaz;
            tbKontakt.DataContext = pacijentZaPrikaz;
            tbMejl.DataContext = pacijentZaPrikaz;
            tbKorIme.DataContext = pacijentZaPrikaz;
        }
    }
}
