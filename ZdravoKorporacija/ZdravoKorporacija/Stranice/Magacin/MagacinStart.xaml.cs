using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.Model;


namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinStart.xaml
    /// </summary>
    public partial class MagacinStart : Window
    {
        Dictionary<int, int> ids = new Dictionary<int, int>();

        ObservableCollection<Inventar> filtrirana_oprema = new ObservableCollection<Inventar>();

        public MagacinStart()
        {
            InitializeComponent();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapMagacin");
            ids = datotekaID.dobaviSve();
            UpravnikController uc = new UpravnikController();
            uc.DodajIzMagacina();
            dgMagacinOprema.ItemsSource = MagacinRepozitorijum.Instance.magacinOprema;
           


        }

        private void dgMagacinOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgMagacinOprema.ItemsSource = MagacinRepozitorijum.Instance.magacinOprema;
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            MagacinDodavanje mc = new MagacinDodavanje(ids);
            mc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            provera();        
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (filtrirana_oprema != null) {
                dgMagacinOprema.ItemsSource = this.filtrirana_oprema;
            }
        }

        private void slValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.filtrirana_oprema = new ObservableCollection<Inventar>();
            foreach (Inventar inv in MagacinRepozitorijum.Instance.magacinOprema)
            {
               
               if(inv.UkupnaKolicina <= (int)slValue.Value)
                {
                    filtrirana_oprema.Add(inv);
                }
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void provera() {
            List<RadioButton> radioButtons = magacin.Children.OfType<RadioButton>().ToList();
            RadioButton rbTarget = radioButtons
                  .Where(r => r.GroupName == "Group1" && (bool)r.IsChecked)
                  .SingleOrDefault();

            this.filtrirana_oprema = new ObservableCollection<Inventar>();
            foreach (Inventar inv in MagacinRepozitorijum.Instance.magacinOprema)
            {
                if (rbTarget == r2)
                {
                    if (inv.Proizvodjac.Contains(searchBox.Text))
                    {
                        filtrirana_oprema.Add(inv);

                    }
                }
                else if (rbTarget == r1)
                {
                    if (inv.Naziv.Contains(searchBox.Text))
                    {
                        filtrirana_oprema.Add(inv);
                    }
                }
                else
                {
                    filtrirana_oprema.Add(inv);
                }
            }

        }

        private void r1_Checked(object sender, RoutedEventArgs e)
        {
            provera();
        }

        private void r2_Checked(object sender, RoutedEventArgs e)
        {
            provera();
        }

        private void ponisti_Click(object sender, RoutedEventArgs e)
        {
            this.filtrirana_oprema = new ObservableCollection<Inventar>();
            dgMagacinOprema.ItemsSource = MagacinRepozitorijum.Instance.magacinOprema;
            r1.IsChecked = false;
            r2.IsChecked = false;



        }
    }
}
