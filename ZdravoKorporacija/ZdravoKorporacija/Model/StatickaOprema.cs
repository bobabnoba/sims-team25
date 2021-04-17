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
        public Termin termin;

        public StatickaOprema(Termin termin, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) : base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            this.termin = termin;
        }
    }
}