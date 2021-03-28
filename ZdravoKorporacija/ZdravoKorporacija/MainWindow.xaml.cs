using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Model;
using System.Collections.Generic;
using System.Collections;

namespace ZdravoKorporacija
{

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

        private void AutoColumns_Click(object sender, RoutedEventArgs e)
        {
            DatotekaUpravnikJSON upravnikJSON = new DatotekaUpravnikJSON();
            List<Upravnik> upravnici = new List<Upravnik>();
            upravnici.Add(new Upravnik());
            upravnikJSON.UpisivanjeUFajl(upravnici);
        }

            private void ManualColumns_Click(object sender, RoutedEventArgs e)
            {
           DatotekaPacijentJSON pacijentJSON = new DatotekaPacijentJSON();
            List<Pacijent> pacijenti = new List<Pacijent>();
            Termin tr = new Termin();
            Pacijent p1 = new Pacijent();
            p1.AddTermin(tr);
            pacijenti.Add(p1);
            pacijentJSON.UpisivanjeUFajl(pacijenti);
        }

            private void Binding_Click(object sender, RoutedEventArgs e)
            {
            }
        }
    }
