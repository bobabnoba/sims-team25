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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Repository;
using Service;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.SekretarCRUD;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for sekretarNALOZI.xaml
    /// </summary>
    public partial class sekretarNALOZI : Page

    {

        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private TerminController controller = new TerminController();
        public sekretarNALOZI()
        {
            
            InitializeComponent();
            PacijentRepozitorijum dat = new PacijentRepozitorijum();
            pacijenti = controller.PregledSvihPacijenata2DTO();
            foreach (PacijentDTO p in pacijenti.ToList())
            {
                if (p.Ime.Equals("NEREGISTROVANI"))
                {
                    pacijenti.Remove(p);
                }
            }
            
            dgUsers.ItemsSource = pacijenti;


            this.DataContext = this;
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            kreirajNalogSekretar kn = new kreirajNalogSekretar();
            kn.Show();
        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniNalogSekretar izn = new izmeniNalogSekretar((PacijentDTO)dgUsers.SelectedItem);
                izn.Show();
            }
        }
        private void izbrisi(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                obrisiNalogSekretar on = new obrisiNalogSekretar((PacijentDTO)dgUsers.SelectedItem);
                on.Show();
            }
        }
        private void dodajAlergen(object sender, RoutedEventArgs e)
        {
            dodajAlergen da = new dodajAlergen(controller.PacijentDTO2Model((PacijentDTO)dgUsers.SelectedItem));
            da.Show();
        }

        private void pogledaj(object sender, RoutedEventArgs e)
        {
            prikaziKarton pk = new prikaziKarton(controller.PacijentDTO2Model((PacijentDTO)dgUsers.SelectedItem));
            pk.Show();
        }
    }
}
