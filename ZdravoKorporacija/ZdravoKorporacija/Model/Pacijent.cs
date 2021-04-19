// File:    Patient.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:17 PM
// Purpose: Definition of Class Patient

using System;
using System.Collections;

namespace Model
{

    public class Pacijent : Korisnik
    {
       
        public Pacijent() : base() { }

        public ZdravstveniKarton zdravstveniKarton = new ZdravstveniKarton();

        public Pacijent(ZdravstveniKarton zk, bool guest, string ime, string prezime, int jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
            this.termin = new System.Collections.ArrayList();
            
            zdravstveniKarton =  zk;
            Guest = guest;
        }

        public Pacijent( bool guest, string ime, string prezime, int jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
            this.termin = new System.Collections.ArrayList();

            
            Guest = guest;
        }

        public Pregled ZakaziPregled()
        {
            // TODO: implement
            return null;
        }

        public void AzurirajPregled(Termin pregled)
        {
            // TODO: implement
        }

        public bool OtkaziPregled(Termin pregled)
        {
            // TODO: implement
            return false;
        }

        public ArrayList UvidUPreglede()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList termin;


        public Pacijent(String Ime, String Prezime) : base(Ime, Prezime)
        {

        }

        public Pacijent(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
        }



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
                this.termin.Add(newTermin);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(Termin oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
            {
                this.termin.Remove(oldTermin);
                System.Diagnostics.Debug.WriteLine("Izbrisalo");
            }
        }
        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
                termin.Clear();
        }
       
        public long GetJmbg()
        {
            return this.Jmbg;
        }

        public bool Guest { get; set; }

    }
}