/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;

namespace Model
{
   public class DinamickaOprema : Inventar
   {
        public int Kolicina { get; set; }

        public Prostorija Prostorija { get; set; }
        
        public DinamickaOprema() { }

        public DinamickaOprema(int kolicina, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) :base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            Kolicina = kolicina;
        }

        public DinamickaOprema(Inventar inv,int kolicina) : base(inv.Id, inv.Naziv, inv.UkupnaKolicina, inv.Proizvodjac, inv.DatumNabavke)
        {
            Kolicina = kolicina;
        }
    }
}