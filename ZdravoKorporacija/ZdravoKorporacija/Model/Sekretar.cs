/***********************************************************************
 * Module:  Sekretar.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Sekretar
 ***********************************************************************/

using System;
using System.Collections;

public class Sekretar : Korisnik
{

    public Sekretar(String Ime, String Prezime) : base(Ime, Prezime)
    {

    }

    public Sekretar(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
    {
    }

    public Pacijent KreirajNalogPacijentu()
   {
      // TODO: implement
      return null;
   }
   
   public void ObrisiNalogPacijentu(Pacijent pacijent)
   {
      // TODO: implement
   }
   
   public void AzurirajPacijenta(Pacijent pacijent)
   {
      // TODO: implement
   }
   
   public ArrayList PregledajPacijente()
   {
      // TODO: implement
      return null;
   }

}