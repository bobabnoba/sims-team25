using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace ZdravoKorporacija.DTO
{
        public class PacijentDTO : Korisnik
        {
            public PacijentDTO() : base() { }

            public PacijentDTO(ZdravstveniKartonDTO zdravstveniKarton, bool guest, string ime, string prezime, int jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
            {
                this.termin = new List<TerminDTO>();
                ZdravstveniKarton = zdravstveniKarton;
                Guest = guest;
            }

            public Pregled ZakaziPregled()
            {
                // TODO: implement
                return null;
            }

            public void AzurirajPregled(TerminDTO pregled)
            {
                // TODO: implement
            }

            public bool OtkaziPregled(TerminDTO pregled)
            {
                // TODO: implement
                return false;
            }

            public ArrayList UvidUPreglede()
            {
                // TODO: implement
                return null;
            }

            public List<TerminDTO> termin;


            public PacijentDTO(String Ime, String Prezime) : base(Ime, Prezime)
            {

            }

            public PacijentDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
            {
            }

        public PacijentDTO(Pacijent pacijent) 
        {
            this.Ime = pacijent.Ime;
            this.Prezime = pacijent.Prezime;
            Jmbg = pacijent.Jmbg;
            BrojTelefona = pacijent.BrojTelefona;
            Mejl = pacijent.Mejl;
            AdresaStanovanja = pacijent.AdresaStanovanja;
            Pol = pacijent.Pol;
            Username = pacijent.Username;
            Password = pacijent.Password;
            Uloga = pacijent.Uloga; 
            this.termin = terminToTerminDTO(pacijent.termin);
            ZdravstveniKarton = new ZdravstveniKartonDTO(pacijent.ZdravstveniKarton);
            Guest = pacijent.Guest;
            this.notifikacije = pacijent.notifikacije;
            this.banovan = pacijent.banovan;
        }

        public List<TerminDTO> terminToTerminDTO(List<Termin> termini)
        {
            if (termini != null)
            {
                List<TerminDTO> terminiDTO = new List<TerminDTO>();
                foreach (Termin termin in termini)
                {
                    terminiDTO.Add(new TerminDTO(termin));
                }

                return terminiDTO;
            }
            else
            {
                return new List<TerminDTO>();
            }
        }


        /// <pdGenerated>default getter</pdGenerated>
        public List<TerminDTO> GetTermin()
            {
                if (termin == null)
                    termin = new List<TerminDTO>();
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
                    this.termin = new List<TerminDTO>();
                if (!this.termin.Contains(newTermin))
                    this.termin.Add(newTermin);
            }

            /// <pdGenerated>default Remove</pdGenerated>
            public void RemoveTermin(TerminDTO oldTermin)
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
            public ZdravstveniKartonDTO ZdravstveniKarton { get; set; }

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

            public Boolean banovan { get; set; }


        }
}
