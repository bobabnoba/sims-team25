// File:    Report.cs
// Author:  User
// Created: Wednesday, March 24, 2021 8:38:47 AM
// Purpose: Definition of Class Report

using System;

namespace Model
{
    public class Izvestaj
    {
        public Termin termin;

        public Izvestaj() { }

        public Izvestaj(Termin termin, int id, string opis, string simptomi)
        {
            this.termin = termin;
            Id = id;
            Opis = opis;
            Simptomi = simptomi;
        }

     

        public int Id { get; set; }
        public String Opis { get; set; }
        public String Simptomi { get; set; }

    }
}