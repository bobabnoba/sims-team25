using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
   public  class LekarDTO : KorisnikDTO
    {

        public LekarDTO() : base() { }
        public LekarDTO(String Ime, String Prezime) : base(Ime, Prezime)
        {

        }

        public LekarDTO(string ime, string prezime, Int64 jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
        } }

    }

