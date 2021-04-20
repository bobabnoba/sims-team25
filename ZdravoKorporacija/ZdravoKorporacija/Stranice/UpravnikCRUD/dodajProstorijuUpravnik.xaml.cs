using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for dodajProstorijuUpravnik.xaml
    /// </summary>
    public partial class dodajProstorijuUpravnik : Window
    {
        private ProstorijaService storage = new ProstorijaService();
        private ObservableCollection<Prostorija> prostorije;
        Dictionary<int, int> id_map = new Dictionary<int, int>();
        public dodajProstorijuUpravnik(ObservableCollection<Prostorija> pr, Dictionary<int, int> ids)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.id_map = ids;
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBoxSprat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            int id = 0;
            for (int i =0; i< 1000; i++)
            {
                if (id_map[i] == 0) {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            string ime = textboxNaziv.Text;

            if (ime.Trim() == "") {
                MessageBox.Show("Ne možemo da pronadjemo naziv prostorije, molimo vas unesite ponovo naziv", "Greška");
                return;
            }


            TipProstorijeEnum tip;
            int sprat;
            if (comboBoxTip.SelectedIndex == 0)
            {
                tip = TipProstorijeEnum.OperacionaSala;
            }
            else if (comboBoxTip.SelectedIndex == 1)
            {
                tip = TipProstorijeEnum.Soba;
            }
            else if (comboBoxTip.SelectedIndex == 2)
            {
                tip = TipProstorijeEnum.Ordinacija;
            }
            else
            {
                MessageBox.Show("Ne možemo da pronadjemo tip prostorije, molimo vas izaberite tip prostorije","Greška");
                return ;
            }
         
            if (comboBoxSprat.SelectedIndex == -1)
            {
                MessageBox.Show("Ne možemo da pronadjemo sprat, molimo vas izaberite sprat na kom se nalazi prostorija", "Greška");
                return;
            }
            else {
                sprat = comboBoxSprat.SelectedIndex;
            }

         
            Prostorija prostorija = new Prostorija(id, ime, tip, false, sprat);
            if (storage.DodajProstoriju(prostorija,id_map))
            {
                this.prostorije.Add(prostorija);
                this.Close();
            }
           

        }
    }
}
