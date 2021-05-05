// File:    Medicine.cs
// Author:  User
// Created: Wednesday, March 24, 2021 12:50:18 AM
// Purpose: Definition of Class Medicine

using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class Lek
    {
        public int Id { get; set; }
        public String Proizvodjac { get; set; }
        public String Sastojci { get; set; }
        public String NusPojave { get; set; }
        public String NazivLeka { get; set; }

        public List<Lek> alternativniLekovi;

        /// <pdGenerated>default getter</pdGenerated>
        public List<Lek> GetalternativniLekovi()
        {
            if (alternativniLekovi == null)
                alternativniLekovi = new List<Lek>();
            return alternativniLekovi;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetalternativniLekovi(List<Lek> newalternativniLekovi)
        {
            RemoveAllalternativniLekovi();
            foreach (Lek oLek in newalternativniLekovi)
                AddalternativniLekovi(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddalternativniLekovi(Lek newLek)
        {
            if (newLek == null)
                return;
            if (this.alternativniLekovi == null)
                this.alternativniLekovi = new List<Lek>();
            if (!this.alternativniLekovi.Contains(newLek))
                this.alternativniLekovi.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovealternativniLekovi(Lek oldLek)
        {
            if (oldLek == null)
                return;
            if (this.alternativniLekovi != null)
                if (this.alternativniLekovi.Contains(oldLek))
                    this.alternativniLekovi.Remove(oldLek);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllalternativniLekovi()
        {
            if (alternativniLekovi != null)
                alternativniLekovi.Clear();
        }

        public Lek(int  ID, String pr, String sas, String np, String nl)
        {
            Id = ID;
            Proizvodjac = pr;
            Sastojci = sas;
            NusPojave = np;
            NazivLeka = nl;
            this.alternativniLekovi = new List<Lek>();
        }

    }
}