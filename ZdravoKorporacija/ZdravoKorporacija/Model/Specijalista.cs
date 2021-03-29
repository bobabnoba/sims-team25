/***********************************************************************
 * Module:  Specijalista.cs
 * Author:  tukitaki
 * Purpose: Definition of the Class Specijalista
 ***********************************************************************/

using System;

public class Specijalista : Doktor
{
    public Specijalista(String Ime, String Prezime) : base(Ime, Prezime)
    {

    }

    private SpecijalizacijaEnum Specijalizacija { get; set; }

}