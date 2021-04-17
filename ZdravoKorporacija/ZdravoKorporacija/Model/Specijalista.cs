/***********************************************************************
 * Module:  Specijalista.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Specijalista
 ***********************************************************************/

using System;
namespace Model
{
    public class Specijalista : Lekar
    {
        public Specijalista(String Ime, String Prezime) : base(Ime, Prezime)
        {

        }

        private SpecijalizacijaEnum Specijalizacija { get; set; }

    }
}