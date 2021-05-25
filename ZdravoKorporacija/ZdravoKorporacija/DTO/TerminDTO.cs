using System;
using AutoMapper;
using Model;
using ZdravoKorporacija.Controller;

namespace ZdravoKorporacija.DTO
{
    public class TerminDTO
    {
        private TerminController tc = new TerminController();
        public TerminDTO()
        {
        }

        public TerminDTO(int id, TipTerminaEnum tip, DateTime pocetak, double trajanje, ProstorijaDTO prostorija, LekarDTO lekar, ZdravstveniKartonDTO zdravstveniKarton)
        {
            this.Id = id;
            this.Tip = tip;
            this.Pocetak = pocetak;
            this.Trajanje = trajanje;
            this.prostorija = prostorija;
            this.Lekar = lekar;
            this.zdravstveniKarton = zdravstveniKarton;
        }


    public int Id { get; set; }
    public TipTerminaEnum Tip { get; set; }
    public DateTime Pocetak { get; set; }
    public double Trajanje { get; set; }
    public ProstorijaDTO prostorija { get; set; }
    public LekarDTO Lekar { get; set; }
    public ZdravstveniKartonDTO zdravstveniKarton { get; set; }
    }

}