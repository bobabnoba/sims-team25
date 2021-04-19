using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{



    public partial class dodajDijagnozu : Window
    {
        private ZdravstveniKartonServis kartonServis = new ZdravstveniKartonServis();
        private ZdravstveniKartonRepozitorijum kartonDat = new ZdravstveniKartonRepozitorijum();
        private List<Lekar> ljekari;
        Dijagnoza d;
        public dodajDijagnozu(ObservableCollection<Dijagnoza> dijagnoze)
        {
            InitializeComponent();
            d = new Dijagnoza();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            d.Oboljenje = oboljenjeText.Text;
            d.Opis = new TextRange(opisText.Document.ContentStart, opisText.Document.ContentEnd).Text;

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
