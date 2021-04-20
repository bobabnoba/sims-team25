// File:    Medicine.cs
// Author:  User
// Created: Wednesday, March 24, 2021 12:50:18 AM
// Purpose: Definition of Class Medicine

using System;

namespace Model
{
    public class Lek
    {
        public String Id { get; set; }
        public String Proizvodjac { get; set; }
        public String Sastojci { get; set; }
        public String NusPojave { get; set; }
        public String NazivLeka { get; set; }

        public Lek(String ID, String pr, String sas, String np, String nl)
        {
            Id = ID;
            Proizvodjac = pr;
            Sastojci = sas;
            NusPojave = np;
            NazivLeka = nl;
        }

    }
}