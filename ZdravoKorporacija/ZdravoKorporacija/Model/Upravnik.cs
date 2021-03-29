/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Upravnik
 ***********************************************************************/

using System;

public class Upravnik : Korisnik
{
    public Upravnik(String Ime, String Prezime) : base(Ime, Prezime)
    {

    }

    public Prostorija DodajProstoriju()
   {
      // TODO: implement
      return null;
   }
   
   public void ObrisiProstoriju(Prostorija prostorija)
   {
      // TODO: implement
   }
   
   public bool AzurirajProstoriju(Prostorija prostorija)
   {
      // TODO: implement
      return false;
   }
   
   public Array PregledajProstorije()
   {
      // TODO: implement
      return null;
   }

}