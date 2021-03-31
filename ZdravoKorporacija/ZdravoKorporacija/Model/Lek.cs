// File:    Medicine.cs
// Author:  User
// Created: Wednesday, March 24, 2021 12:50:18 AM
// Purpose: Definition of Class Medicine

using System;

public class Lek
{
    public Lek(string id, string proiazvodjac, string sastaojci, string nusPaojave)
    {
        Id = id;
        Proiazvodjac = proiazvodjac;
        Sastaojci = sastaojci;
        NusPaojave = nusPaojave;
    }


    public String Id { get; set; }
    public String Proiazvodjac { get; set; }
    public String Sastaojci { get; set; }
    public String NusPaojave { get; set; }
}