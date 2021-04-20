// File:    Prescription.cs
// Author:  User
// Created: Tuesday, March 23, 2021 11:45:18 PM
// Purpose: Definition of Class Prescription

using System;

namespace Model
{
    public class Recept
    {
        public int Id { get; set; }
        public String Doziranje{ get; set; }
    public int Trajanje { get; set; }
        public String NazivLeka { get; set; }

        public System.Collections.ArrayList lek;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetLek()
        {
            if (lek == null)
                lek = new System.Collections.ArrayList();
            return lek;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetLek(System.Collections.ArrayList newLek)
        {
            RemoveAllLek();
            foreach (Lek oLek in newLek)
                AddLek(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddLek(Lek newLek)
        {
            if (newLek == null)
                return;
            if (this.lek == null)
                this.lek = new System.Collections.ArrayList();
            if (!this.lek.Contains(newLek))
                this.lek.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveLek(Lek oldLek)
        {
            if (oldLek == null)
                return;
            if (this.lek != null)
                if (this.lek.Contains(oldLek))
                    this.lek.Remove(oldLek);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllLek()
        {
            if (lek != null)
                lek.Clear();
        }
        public Lekar lekar;
        public ZdravstveniKarton zdravstveniKarton;

        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravstveniKarton GetZdravstveniKarton()
        {
            return zdravstveniKarton;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newZdravstveniKarton</param>
        public void SetZdravstveniKarton(ZdravstveniKarton newZdravstveniKarton)
        {
            if (this.zdravstveniKarton != newZdravstveniKarton)
            {
                if (this.zdravstveniKarton != null)
                {
                    ZdravstveniKarton oldZdravstveniKarton = this.zdravstveniKarton;
                    this.zdravstveniKarton = null;
                    oldZdravstveniKarton.RemoveRecept(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddRecept(this);
                }
            }
        }

    }
}