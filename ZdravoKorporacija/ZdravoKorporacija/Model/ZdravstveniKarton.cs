// File:    MedicalRecord.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:51 PM
// Purpose: Definition of Class MedicalRecord

using System;
namespace Model
{
    public class ZdravstveniKarton
    {
        public System.Collections.ArrayList izvestajOHospitalizaciji;

  
        public ZdravstveniKarton(Pacijent patient, long id, StanjePacijentaEnum zdravstvenoStanje, string alergije, KrvnaGrupaEnum krvnaGrupa, string vakcine)
        {
            this.izvestajOHospitalizaciji = new System.Collections.ArrayList();
            this.istorijaBolesti = new System.Collections.ArrayList();
            this.recept = new System.Collections.ArrayList();
            this.termin = new System.Collections.ArrayList();
            this.patient = patient;
            Id = id;
            ZdravstvenoStanje = zdravstvenoStanje;
            Alergije = alergije;
            KrvnaGrupa = krvnaGrupa;
            Vakcine = vakcine;
        }

        public ZdravstveniKarton()
        {
        }


        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetIzvestajOHospitalizaciji()
        {
            if (izvestajOHospitalizaciji == null)
                izvestajOHospitalizaciji = new System.Collections.ArrayList();
            return izvestajOHospitalizaciji;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetIzvestajOHospitalizaciji(System.Collections.ArrayList newIzvestajOHospitalizaciji)
        {
            RemoveAllIzvestajOHospitalizaciji();
            foreach (IzvestajOHospitalizaciji oIzvestajOHospitalizaciji in newIzvestajOHospitalizaciji)
                AddIzvestajOHospitalizaciji(oIzvestajOHospitalizaciji);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddIzvestajOHospitalizaciji(IzvestajOHospitalizaciji newIzvestajOHospitalizaciji)
        {
            if (newIzvestajOHospitalizaciji == null)
                return;
            if (this.izvestajOHospitalizaciji == null)
                this.izvestajOHospitalizaciji = new System.Collections.ArrayList();
            if (!this.izvestajOHospitalizaciji.Contains(newIzvestajOHospitalizaciji))
            {
                this.izvestajOHospitalizaciji.Add(newIzvestajOHospitalizaciji);
                newIzvestajOHospitalizaciji.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveIzvestajOHospitalizaciji(IzvestajOHospitalizaciji oldIzvestajOHospitalizaciji)
        {
            if (oldIzvestajOHospitalizaciji == null)
                return;
            if (this.izvestajOHospitalizaciji != null)
                if (this.izvestajOHospitalizaciji.Contains(oldIzvestajOHospitalizaciji))
                {
                    this.izvestajOHospitalizaciji.Remove(oldIzvestajOHospitalizaciji);
                    oldIzvestajOHospitalizaciji.SetZdravstveniKarton((ZdravstveniKarton)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllIzvestajOHospitalizaciji()
        {
            if (izvestajOHospitalizaciji != null)
            {
                System.Collections.ArrayList tmpIzvestajOHospitalizaciji = new System.Collections.ArrayList();
                foreach (IzvestajOHospitalizaciji oldIzvestajOHospitalizaciji in izvestajOHospitalizaciji)
                    tmpIzvestajOHospitalizaciji.Add(oldIzvestajOHospitalizaciji);
                izvestajOHospitalizaciji.Clear();
                foreach (IzvestajOHospitalizaciji oldIzvestajOHospitalizaciji in tmpIzvestajOHospitalizaciji)
                    oldIzvestajOHospitalizaciji.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpIzvestajOHospitalizaciji.Clear();
            }
        }
        public System.Collections.ArrayList istorijaBolesti;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetIstorijaBolesti()
        {
            if (istorijaBolesti == null)
                istorijaBolesti = new System.Collections.ArrayList();
            return istorijaBolesti;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetIstorijaBolesti(System.Collections.ArrayList newIstorijaBolesti)
        {
            RemoveAllIstorijaBolesti();
            foreach (IstorijaBolesti oIstorijaBolesti in newIstorijaBolesti)
                AddIstorijaBolesti(oIstorijaBolesti);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddIstorijaBolesti(IstorijaBolesti newIstorijaBolesti)
        {
            if (newIstorijaBolesti == null)
                return;
            if (this.istorijaBolesti == null)
                this.istorijaBolesti = new System.Collections.ArrayList();
            if (!this.istorijaBolesti.Contains(newIstorijaBolesti))
            {
                this.istorijaBolesti.Add(newIstorijaBolesti);
                newIstorijaBolesti.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveIstorijaBolesti(IstorijaBolesti oldIstorijaBolesti)
        {
            if (oldIstorijaBolesti == null)
                return;
            if (this.istorijaBolesti != null)
                if (this.istorijaBolesti.Contains(oldIstorijaBolesti))
                {
                    this.istorijaBolesti.Remove(oldIstorijaBolesti);
                    oldIstorijaBolesti.SetZdravstveniKarton((ZdravstveniKarton)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllIstorijaBolesti()
        {
            if (istorijaBolesti != null)
            {
                System.Collections.ArrayList tmpIstorijaBolesti = new System.Collections.ArrayList();
                foreach (IstorijaBolesti oldIstorijaBolesti in istorijaBolesti)
                    tmpIstorijaBolesti.Add(oldIstorijaBolesti);
                istorijaBolesti.Clear();
                foreach (IstorijaBolesti oldIstorijaBolesti in tmpIstorijaBolesti)
                    oldIstorijaBolesti.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpIstorijaBolesti.Clear();
            }
        }
        public System.Collections.ArrayList recept;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetRecept()
        {
            if (recept == null)
                recept = new System.Collections.ArrayList();
            return recept;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRecept(System.Collections.ArrayList newRecept)
        {
            RemoveAllRecept();
            foreach (Recept oRecept in newRecept)
                AddRecept(oRecept);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddRecept(Recept newRecept)
        {
            if (newRecept == null)
                return;
            if (this.recept == null)
                this.recept = new System.Collections.ArrayList();
            if (!this.recept.Contains(newRecept))
            {
                this.recept.Add(newRecept);
                newRecept.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveRecept(Recept oldRecept)
        {
            if (oldRecept == null)
                return;
            if (this.recept != null)
                if (this.recept.Contains(oldRecept))
                {
                    this.recept.Remove(oldRecept);
                    oldRecept.SetZdravstveniKarton((ZdravstveniKarton)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllRecept()
        {
            if (recept != null)
            {
                System.Collections.ArrayList tmpRecept = new System.Collections.ArrayList();
                foreach (Recept oldRecept in recept)
                    tmpRecept.Add(oldRecept);
                recept.Clear();
                foreach (Recept oldRecept in tmpRecept)
                    oldRecept.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpRecept.Clear();
            }
        }
        public System.Collections.ArrayList termin;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetTermin()
        {
            if (termin == null)
                termin = new System.Collections.ArrayList();
            return termin;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTermin(System.Collections.ArrayList newTermin)
        {
            RemoveAllTermin();
            foreach (Termin oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(Termin newTermin)
        {
            if (newTermin == null)
                return;
            if (this.termin == null)
                this.termin = new System.Collections.ArrayList();
            if (!this.termin.Contains(newTermin))
            {
                this.termin.Add(newTermin);
                newTermin.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(Termin oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
                if (this.termin.Contains(oldTermin))
                {
                    this.termin.Remove(oldTermin);
                    oldTermin.SetZdravstveniKarton((ZdravstveniKarton)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
            {
                System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
                foreach (Termin oldTermin in termin)
                    tmpTermin.Add(oldTermin);
                termin.Clear();
                foreach (Termin oldTermin in tmpTermin)
                    oldTermin.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpTermin.Clear();
            }
        }
        public Pacijent patient { get; set; }

        public long Id { get; set; }
        public StanjePacijentaEnum ZdravstvenoStanje { get; set; }
        public String Alergije { get; set; }
        public KrvnaGrupaEnum KrvnaGrupa { get; set; }
        public String Vakcine { get; set; }
        public void dodajAlergije(string dodaj)
        {
            this.Alergije = dodaj;
        }

    }
}