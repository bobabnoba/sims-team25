using System;
using AutoMapper;
using Model;
using ZdravoKorporacija.Controller;

namespace ZdravoKorporacija.DTO
{
    public class TerminDTO
    {
        private TerminController tc = new TerminController();
        private ZdravstveniKarton zdravstveniKarton1;
        private ProstorijaDTO prostorijaDTO;
        private LekarDTO lekarDTO;
        private double v;
        private Izvestaj izvestaj;

        public TerminDTO()
        {
        }

        public TerminDTO(int id, TipTerminaEnum tip, DateTime pocetak, double trajanje, ProstorijaDTO prostorija, LekarDTO lekar, ZdravstveniKartonDTO zdravstveniKarton, IzvestajDTO izvestaj)
        {
            this.Id = id;
            this.Tip = tip;
            this.Pocetak = pocetak;
            this.Trajanje = trajanje;
            this.prostorija = prostorija;
            this.Lekar = lekar;
            this.zdravstveniKarton = zdravstveniKarton;
            if (izvestaj != null) this.Izvestaj = izvestaj;
            else this.Izvestaj = new IzvestajDTO();
        }
        public TerminDTO(int id, LekarDTO lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje, ProstorijaDTO prostorija)
        {
            this.Id = id;
            this.Lekar = lekar;
            this.Tip = tip;
            this.Pocetak = pocetak;
            this.Trajanje = 0.5;
            this.zdravstveniKarton = null;
            this.prostorija = prostorija;
            this.Izvestaj = null;
        }

        public TerminDTO(ZdravstveniKarton zdravstveniKarton1, ProstorijaDTO prostorijaDTO, LekarDTO lekarDTO, TipTerminaEnum tip, DateTime pocetak, double v, Izvestaj izvestaj)
        {
            this.zdravstveniKarton1 = zdravstveniKarton1;
            this.prostorijaDTO = prostorijaDTO;
            this.lekarDTO = lekarDTO;
            Tip = tip;
            Pocetak = pocetak;
            this.v = v;
            this.izvestaj = izvestaj;
        }

        public int Id { get; set; }
    public TipTerminaEnum Tip { get; set; }
    public DateTime Pocetak { get; set; }
    public double Trajanje { get; set; }
    public ProstorijaDTO prostorija { get; set; }
    public LekarDTO Lekar { get; set; }
    public ZdravstveniKartonDTO zdravstveniKarton { get; set; }

    public IzvestajDTO Izvestaj { get; set; }

        public bool hitno { get; set; }
    }
    


}
