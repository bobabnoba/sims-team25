using Model;
using System;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;


namespace ZdravoKorporacija.Stranice.sekretarObavestenja
{
    /// <summary>
    /// Interaction logic for kreirajObavestenje.xaml
    /// </summary>
    public partial class kreirajObavestenje : Window
    {
        public static int oid = 10000;

        private ObavestenjaController controller = new ObavestenjaController();
        private NotifikacijaDTO obavestenje = new NotifikacijaDTO();
        public kreirajObavestenje()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            obavestenje.Id = oid;
            oid--;
            obavestenje.Sadrzaj = obv.Text;
            obavestenje.Datum = DateTime.Now;
            obavestenje.Tip = TipNotifikacije.Globalno;

            controller.dodajObavestenje(controller.DTO2ModelNapravi(obavestenje));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
