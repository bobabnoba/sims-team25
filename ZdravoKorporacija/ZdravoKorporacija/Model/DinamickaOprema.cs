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
      public int Kolicina;

        public DinamickaOprema(int kolicina, int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke) :base(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke)
        {
            Kolicina = kolicina;
        }
    }
}