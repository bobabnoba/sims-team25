/***********************************************************************
 * Module:  Inventar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Inventar
 ***********************************************************************/

using System;

public class Inventar
{
    public Inventar(int id, string naziv, int kolicina, string proizvodjac, DateTime datumNabavke)
    {
        Id = id;
        Naziv = naziv;
        Kolicina = kolicina;
        Proizvodjac = proizvodjac;
        DatumNabavke = datumNabavke;
    }

    public int Id { get; set; }
    public String Naziv { get; set; }
    public int Kolicina { get; set; }
    public String Proizvodjac { get; set; }
    public DateTime DatumNabavke { get; set; }

}