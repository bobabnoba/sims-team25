﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class LekarDTO:Korisnik
    {
        public LekarDTO() : base() { }
        public LekarDTO(String Ime, String Prezime) : base(Ime, Prezime)
        {

        }

        public LekarDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
        }

        public LekarDTO(Lekar lekar) {
            this.Ime = lekar.Ime;
            this.Prezime = lekar.Prezime;
            this.Jmbg = lekar.Jmbg;
            this.BrojTelefona = lekar.BrojTelefona;
            this.Mejl = lekar.Mejl;
            this.AdresaStanovanja = lekar.AdresaStanovanja;
            this.Pol = lekar.Pol;
            this.Username = lekar.Username;
            this.Password = lekar.Password;
            this.Uloga = lekar.Uloga;

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
            foreach (TerminDTO oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(TerminDTO newTermin)
        {
            if (newTermin == null)
                return;
            if (this.termin == null)
                this.termin = new System.Collections.ArrayList();
            if (!this.termin.Contains(newTermin))
            {
                this.termin.Add(newTermin);
                newTermin.SetLekar(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(TerminDTO oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
                if (this.termin.Contains(oldTermin))
                {
                    this.termin.Remove(oldTermin);
                    oldTermin.SetLekar((LekarDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
            {
                System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
                foreach (TerminDTO oldTermin in termin)
                    tmpTermin.Add(oldTermin);
                termin.Clear();
                foreach (TerminDTO oldTermin in tmpTermin)
                    oldTermin.SetLekar((LekarDTO)null);
                tmpTermin.Clear();
            }
        }

    }
}
