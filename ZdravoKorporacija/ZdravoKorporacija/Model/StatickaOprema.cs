/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;

namespace Model
{
    public class StatickaOprema : Inventar
    {
        public Termin termin { get; set; }

        public Prostorija Prostorija { get; set; }

        public StatickaOprema() { }

        public StatickaOprema(Termin termin, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) : base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            this.termin = termin;
        }

        public StatickaOprema(Termin termin, Inventar inv) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            this.termin = termin;
        }
    }
}