using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
    public class LekarDTO : KorisnikDTO
    {
        public LekarDTO() : base() {}

        public LekarDTO(Lekar lekarEntitet)
        {
            this.Jmbg = lekarEntitet.Jmbg;
            this.Ime = lekarEntitet.Ime;
            this.Prezime = lekarEntitet.Prezime;
            //this.termini = new ArrayList(lekarEntitet.termin);
        }

        public LekarDTO(String Ime, String Prezime) : base(Ime, Prezime)
        {
        }

        public LekarDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
        }

        public LekarDTO(string ime, string prezime, Int64 jmbg) : base(ime, prezime, jmbg)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
        }

        public System.Collections.ArrayList termini;

        public SpecijalizacijaEnum Specijalizacija { get; set; }
        public List<RadniDan> radniDani { get; set; }
    }

}

