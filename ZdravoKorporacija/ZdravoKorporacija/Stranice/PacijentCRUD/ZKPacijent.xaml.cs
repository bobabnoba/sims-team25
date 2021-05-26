using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
