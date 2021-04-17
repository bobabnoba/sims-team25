// File:    Dijagnoza.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:52 PM
// Purpose: Definition of Class Dijagnoza

using System;

namespace Model
{
    public class Dijagnoza : Izvestaj
    {
        public System.Collections.ArrayList terapija;

        public Dijagnoza(string oboljenje, Termin termin, int id, string opis, string simptomi) : base(termin, id, opis, simptomi)
        {
            this.terapija = new System.Collections.ArrayList();
            Oboljenje = oboljenje;
        }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetTerapija()
        {
            if (terapija == null)
                terapija = new System.Collections.ArrayList();
            return terapija;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTerapija(System.Collections.ArrayList newTerapija)
        {
            RemoveAllTerapija();
            foreach (Terapija oTerapija in newTerapija)
                AddTerapija(oTerapija);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTerapija(Terapija newTerapija)
        {
            if (newTerapija == null)
                return;
            if (this.terapija == null)
                this.terapija = new System.Collections.ArrayList();
            if (!this.terapija.Contains(newTerapija))
                this.terapija.Add(newTerapija);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTerapija(Terapija oldTerapija)
        {
            if (oldTerapija == null)
                return;
            if (this.terapija != null)
                if (this.terapija.Contains(oldTerapija))
                    this.terapija.Remove(oldTerapija);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTerapija()
        {
            if (terapija != null)
                terapija.Clear();
        }

        public String Oboljenje { get; set; }

    }
}