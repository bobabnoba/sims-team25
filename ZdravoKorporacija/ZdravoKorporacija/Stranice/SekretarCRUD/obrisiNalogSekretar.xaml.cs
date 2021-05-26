using Model;
using Repository;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for obrisiNalogSekretar.xaml
    /// </summary>
    public partial class obrisiNalogSekretar : Window
    {
        
        private PacijentDTO p1;
        private TerminController pacijentController = new TerminController();
        public obrisiNalogSekretar(PacijentDTO selected)
        {
            InitializeComponent();
            p1 = selected;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            pacijentController.ObrisiNalogPacijentu(pacijentController.PacijentDTO2Model(p1));
            pacijentController.PregledSvihPacijenata().Remove(pacijentController.PacijentDTO2Model(p1));
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
