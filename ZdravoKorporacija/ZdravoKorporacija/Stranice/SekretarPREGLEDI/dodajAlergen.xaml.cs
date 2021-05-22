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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;


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
        ZdravstveniKartonDTO k1DTO = new ZdravstveniKartonDTO();
        ZdravstveniKartonDTO k2DTO = new ZdravstveniKartonDTO();
        private AlergeniController controller = new AlergeniController();
        private List<ZdravstveniKarton> kartoni = new List<ZdravstveniKarton>();


        public dodajAlergen(Pacijent izabrani)
        {
            InitializeComponent();
            p1 = izabrani;


            k1DTO = controller.Model2DTO(controller.findById(izabrani.Jmbg));
            k2DTO = controller.Model2DTO(controller.findById(izabrani.Jmbg));

            k1.Id = p1.Jmbg;
            k2.Id = p1.Jmbg;
            if (k2DTO != null)
            {
                dodaj.Text = controller.DTO2Model(k1DTO).Alergije;

            }
            else
            {
                dodaj.Text = "PACIJENT NEMA KARTON";
            }

        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            {
                if (k2DTO == null)
                {
                    MessageBox.Show("IZABRANI PACIJENT NEMA KARTON!");

                }
                else
                {

                    controller.DodajAlergen(k1DTO, k2DTO, dodaj.Text, p1);

                    this.Close();

                }

            }
        }
    }
}
