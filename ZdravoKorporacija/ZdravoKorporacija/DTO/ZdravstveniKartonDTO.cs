using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model;
using Service;
using ZdravoKorporacija.Controller;

namespace ZdravoKorporacija.DTO
{
    public class ZdravstveniKartonDTO
    {
        public System.Collections.ArrayList izvestajOHospitalizaciji;
        private TerminController tc = new TerminController();

        public ZdravstveniKartonDTO(Pacijent patient, long id, StanjePacijentaEnum zdravstvenoStanje, string alergije, KrvnaGrupaEnum krvnaGrupa, string vakcine)
        {
            this.izvestajOHospitalizaciji = new System.Collections.ArrayList();
            this.istorijaBolesti = new List<IstorijaBolesti>();
            this.recept = new ObservableCollection<Recept>();
            this.termin = new List<Termin>();
            this.patient = patient;
            Id = id;
            ZdravstvenoStanje = zdravstvenoStanje;
            Alergije = alergije;
            KrvnaGrupa = krvnaGrupa;
            Vakcine = vakcine;
        }
        public ZdravstveniKartonDTO(long id)
        {
            this.patient = tc.NadjiPacijentaPoJMBG(id);
            this.izvestajOHospitalizaciji = new System.Collections.ArrayList();
            this.istorijaBolesti = new List<IstorijaBolesti>();
            this.recept = new ObservableCollection<Recept>();
            this.termin = new List<Termin>();
            this.Alergije = "";
            this.Vakcine = "";
            this.KrvnaGrupa = KrvnaGrupaEnum.None;
            this.ZdravstvenoStanje = StanjePacijentaEnum.None;
            ZdravstveniKartonServis zs = new ZdravstveniKartonServis();
            ZdravstveniKarton zk = new ZdravstveniKarton();
            zk.Id = id;
            zs.KreirajZdravstveniKartonJMBG(zk);
        }

        public ZdravstveniKartonDTO()
        {
        }
        public Pacijent patient { get; set; }
        public List<Termin> termin;
        public ObservableCollection<Recept> recept;
        public List<IstorijaBolesti> istorijaBolesti;
        public long Id { get; set; }
        public StanjePacijentaEnum ZdravstvenoStanje { get; set; }
        public String Alergije { get; set; }
        public KrvnaGrupaEnum KrvnaGrupa { get; set; }
        public String Vakcine { get; set; }
        public void dodajAlergije(string dodaj)
        {
            this.Alergije = dodaj;
        }
    }
}
