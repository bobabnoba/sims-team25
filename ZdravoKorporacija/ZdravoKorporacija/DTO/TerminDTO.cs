using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
   public class TerminDTO
    {
        public TerminDTO() { }

        public TerminDTO(int id, Lekar lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje)
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


        public TerminDTO(ZdravstveniKartonDTO zdravstveniKarton, ProstorijaDTO prostorija, Lekar Lekar, TipTerminaEnum tip, DateTime pocetak, double trajanje, IzvestajDTO izvestaj)
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
            Lekar = termin.Lekar;
            Id = termin.Id;
            Tip = termin.Tip;
            Pocetak = termin.Pocetak;
            Trajanje = termin.Trajanje;
            this.hitno = termin.hitno;
        }

        public IzvestajDTO izvestaj;
        public ZdravstveniKartonDTO zdravstveniKarton;

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
        public Lekar Lekar { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Lekar GetLekar()
        {
            return Lekar;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newLekar</param>
        //public void SetLekar(Lekar newLekar)
        //{
        //    if (this.Lekar != newLekar)
        //    {
        //        if (this.Lekar != null)
        //        {
        //            Lekar oldLekar = this.Lekar;
        //            this.Lekar = null;
        //            oldLekar.RemoveTermin(this);
        //        }
        //        if (newLekar != null)
        //        {
        //            this.Lekar = newLekar;
        //            this.Lekar.AddTermin(this);
        //        }
        //    }
        //}
        public int Id { get; set; }
        public TipTerminaEnum Tip { get; set; }
        public DateTime Pocetak { get; set; }
        public double Trajanje { get; set; }
        public bool hitno { get; set; }

    }
}
