﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class ProstorijaDTO
    {
        public System.Collections.ArrayList inventar;

        public ProstorijaDTO() { }

        public ProstorijaDTO(int id, string naziv, TipProstorijeEnum tip, bool slobodna, int sprat)
        {
            this.inventar = new System.Collections.ArrayList(); ;
            Id = id;
            Naziv = naziv;
            Tip = tip;
            Slobodna = slobodna;
            Sprat = sprat;
        }

        public ProstorijaDTO(Prostorija prostorija)
        {
            this.inventar = new System.Collections.ArrayList();
            Id = prostorija.Id;
            Naziv = prostorija.Naziv;
            Tip = prostorija.Tip;
            Slobodna = prostorija.Slobodna;
            Sprat = prostorija.Sprat;
        }


        public System.Collections.ArrayList statickaOprema;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetStatickaOprema()
        {
            if (statickaOprema == null)
                statickaOprema = new System.Collections.ArrayList();
            return statickaOprema;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetStatickaOprema(System.Collections.ArrayList newStatickaOprema)
        {
            RemoveAllStatickaOprema();
            foreach (StatickaOprema oStatickaOprema in newStatickaOprema)
                AddStatickaOprema(oStatickaOprema);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddStatickaOprema(StatickaOprema newStatickaOprema)
        {
            if (newStatickaOprema == null)
                return;
            if (this.statickaOprema == null)
                this.statickaOprema = new System.Collections.ArrayList();
            if (!this.statickaOprema.Contains(newStatickaOprema))
                this.statickaOprema.Add(newStatickaOprema);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveStatickaOprema(StatickaOprema oldStatickaOprema)
        {
            if (oldStatickaOprema == null)
                return;
            if (this.statickaOprema != null)
                if (this.statickaOprema.Contains(oldStatickaOprema))
                    this.statickaOprema.Remove(oldStatickaOprema);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllStatickaOprema()
        {
            if (statickaOprema != null)
                statickaOprema.Clear();
        }
        public System.Collections.ArrayList dinamickaOprema;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDinamickaOprema()
        {
            if (dinamickaOprema == null)
                dinamickaOprema = new System.Collections.ArrayList();
            return dinamickaOprema;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDinamickaOprema(System.Collections.ArrayList newDinamickaOprema)
        {
            RemoveAllDinamickaOprema();
            foreach (DinamickaOprema oDinamickaOprema in newDinamickaOprema)
                AddDinamickaOprema(oDinamickaOprema);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddDinamickaOprema(DinamickaOprema newDinamickaOprema)
        {
            if (newDinamickaOprema == null)
                return;
            if (this.dinamickaOprema == null)
                this.dinamickaOprema = new System.Collections.ArrayList();
            if (!this.dinamickaOprema.Contains(newDinamickaOprema))
                this.dinamickaOprema.Add(newDinamickaOprema);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveDinamickaOprema(DinamickaOprema oldDinamickaOprema)
        {
            if (oldDinamickaOprema == null)
                return;
            if (this.dinamickaOprema != null)
                if (this.dinamickaOprema.Contains(oldDinamickaOprema))
                    this.dinamickaOprema.Remove(oldDinamickaOprema);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDinamickaOprema()
        {
            if (dinamickaOprema != null)
                dinamickaOprema.Clear();
        }

        public int Id { get; set; }
        public String Naziv { get; set; }
        public TipProstorijeEnum Tip { get; set; }
        public bool Slobodna { get; set; }
        public int Sprat { get; set; }
    }
}
