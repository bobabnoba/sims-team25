using System;
using AutoMapper;
using Model;
using ZdravoKorporacija.Controller;
﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class TerminDTO
    {
        private TerminController tc = new TerminController();
        private ZdravstveniKarton zdravstveniKarton1;
        private ProstorijaDTO prostorijaDTO;
        private LekarDTO lekarDTO;
        private double v;
     

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
            if (izvestaj != null) this.izvestaj = izvestaj;
            else this.izvestaj = new IzvestajDTO();
        }
        public TerminDTO(int id, LekarDTO lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje, ProstorijaDTO prostorija) { }
        

        public TerminDTO(int id, LekarDTO lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje)
        {
            this.Id = id;
            this.Lekar = lekar;
            this.Tip = tip;
            this.Pocetak = pocetak;
            this.Trajanje = 0.5;
            this.zdravstveniKarton = null;
            this.prostorija = null;
            this.izvestaj = null;
        }


        public TerminDTO(ZdravstveniKartonDTO zdravstveniKarton, ProstorijaDTO prostorija, LekarDTO Lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje, IzvestajDTO izvestaj)
        {
            this.izvestaj = izvestaj;
            this.zdravstveniKarton = zdravstveniKarton;
            this.prostorija = prostorija;
            this.Lekar = Lekar;
            Tip = tip;
            Pocetak = pocetak;
            Trajanje = trajanje;
        }

        public TerminDTO(Termin termin)
        {
            this.izvestaj = new IzvestajDTO(termin.izvestaj);
            this.zdravstveniKarton = new ZdravstveniKartonDTO(termin.zdravstveniKarton);
            this.prostorija = new ProstorijaDTO(termin.prostorija);
            Lekar = new LekarDTO(termin.Lekar);
            Id = termin.Id;
            Tip = termin.Tip;
            Pocetak = termin.Pocetak;
            Trajanje = termin.Trajanje;
            this.hitno = termin.hitno;
        }

        public TerminDTO(ProstorijaDTO prostorija, DateTime pocetak)
        {
            this.prostorija = prostorija;
            Pocetak = pocetak;
        }

        public IzvestajDTO izvestaj { get; set; }
        public ZdravstveniKartonDTO zdravstveniKarton { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravstveniKartonDTO GetZdravstveniKarton()
        {
            return zdravstveniKarton;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newZdravstveniKarton</param>
        public void SetZdravstveniKarton(ZdravstveniKartonDTO newZdravstveniKarton)
        {
            if (this.zdravstveniKarton != newZdravstveniKarton)
            {
                if (this.zdravstveniKarton != null)
                {
                    ZdravstveniKartonDTO oldZdravstveniKarton = this.zdravstveniKarton;
                    this.zdravstveniKarton = null;
                    oldZdravstveniKarton.RemoveTermin(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddTermin(this);
                }
            }
        }
        public ProstorijaDTO prostorija { get; set; }
        public LekarDTO Lekar { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public LekarDTO GetLekar()
        {
            return Lekar;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newLekar</param>
        public void SetLekar(LekarDTO newLekar)
        {
            if (this.Lekar != newLekar)
            {
                if (this.Lekar != null)
                {
                    LekarDTO oldLekar = this.Lekar;
                    this.Lekar = null;
                    oldLekar.RemoveTermin(this);
                }
                if (newLekar != null)
                {
                    this.Lekar = newLekar;
                    this.Lekar.AddTermin(this);
                }
            }
        }
        public int Id { get; set; }
        public TipTerminaEnum Tip { get; set; }
        public DateTime Pocetak { get; set; }
        public double Trajanje { get; set; }
        public bool hitno { get; set; }

    }
}
