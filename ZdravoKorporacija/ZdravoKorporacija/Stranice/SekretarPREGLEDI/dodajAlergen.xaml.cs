using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using Repository;
using Service;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for dodajAlergen.xaml
    /// </summary>
    public partial class dodajAlergen : Window
    {
        private ZdravstveniKartonServis ks = new ZdravstveniKartonServis();
        private Pacijent p1;
        ZdravstveniKarton k1 = new ZdravstveniKarton();
        ZdravstveniKarton k2 = new ZdravstveniKarton();
        private List<ZdravstveniKarton> kartoni = new List<ZdravstveniKarton>();


        public dodajAlergen(Pacijent izabrani)
        {
            InitializeComponent();
            p1 = izabrani;
           
            k1 = ks.findById(izabrani.GetJmbg());
            k2 = ks.findById(izabrani.GetJmbg());
            kartoni = ks.PregledZdravstvenogKartona();

    }

     
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            {
                k2.dodajAlergije(dodaj.Text);
                if (ks.AzurirajZdravstveniKarton2(k2))
                {
                    kartoni.Remove(k1);
                    kartoni.Add(k2);
                }
                this.Close();

            }
            
        }
    }
}
