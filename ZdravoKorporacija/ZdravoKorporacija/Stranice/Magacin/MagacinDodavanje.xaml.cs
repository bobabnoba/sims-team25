using Model;
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
using System.Windows.Shapes;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinDodavanje.xaml
    /// </summary>
    public partial class MagacinDodavanje : Window
    {

        Dictionary<int, int> id_map = new Dictionary<int, int>();
        public MagacinDodavanje(Dictionary<int, int> ids)
        {
            InitializeComponent();
            this.id_map = ids;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            string naziv = textboxNaziv.Text;
            int kolicina = 0;
            try
            {
               kolicina = int.Parse(textboxKolicina.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ne mozemo da pronadjemo uneti broj, molimo vas unesite ponovo", "Greska");
                return;
            }
            string proizvodjac = textboxProizvodjac.Text;
            UpravnikController uc = new UpravnikController();

            uc.DodajUMagacin(id, naziv, kolicina, proizvodjac, new DateTime(), this.id_map);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
