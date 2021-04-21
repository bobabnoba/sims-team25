/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;

namespace Model
{
    public class Inventar
    {

        public Inventar() { }


        public Inventar(int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke)
        {
            Id = id;
            Naziv = naziv;
            UkupnaKolicina = ukupnaKolicina;
            Proizvodjac = proizvodjac;
            DatumNabavke = datumNabavke;
        }

       

        public int Id { get; set; }
        public String Naziv { get; set; }
        public int UkupnaKolicina { get; set; }
        public String Proizvodjac { get; set; }
        public DateTime DatumNabavke { get; set; }

    }

}