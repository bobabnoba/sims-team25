// File:    Patient.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:17 PM
// Purpose: Definition of Class Patient

using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Model
{

    public class Pacijent : Korisnik
    {
        public Pacijent() : base() { }

        public Pacijent(ZdravstveniKarton zdravstveniKarton, bool guest, string ime, string prezime, int jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
            this.termin = new System.Collections.ArrayList();
            ZdravstveniKarton = zdravstveniKarton;
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
        public ZdravstveniKarton ZdravstveniKarton { get; set; }

        public bool Guest { get; set; }
       

        public long GetJmbg()
        {
            return this.Jmbg;
        }

        //  public ObservableCollection<Notifikacija> Notifikacije { get => notifikacije; set => notifikacije = value; }

        public ObservableCollection<Notifikacija> notifikacije;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<Notifikacija> GetNotifikacije()
        {
            if (notifikacije == null)
                notifikacije = new ObservableCollection<Notifikacija>();
            return notifikacije;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetNotifikacije(ObservableCollection<Notifikacija> newNotifikacije)
        {
            RemoveAllNotifikacije();
            foreach (Notifikacija oNotifikacije in newNotifikacije)
                AddNotifikacije(oNotifikacije);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddNotifikacije(Notifikacija newNotifikacije)
        {
            if (newNotifikacije == null)
                return;
            if (this.notifikacije == null)
                this.notifikacije = new ObservableCollection<Notifikacija>();
            if (!this.notifikacije.Contains(newNotifikacije))
                this.notifikacije.Add(newNotifikacije);
        }

        public void RemoveAllNotifikacije()
        {
            if (notifikacije != null)
                notifikacije.Clear();
        }

    }
}