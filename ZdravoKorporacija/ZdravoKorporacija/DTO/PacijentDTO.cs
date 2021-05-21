using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
   public class PacijentDTO : KorisnikDTO
    {
        public PacijentDTO() : base() { }

        public PacijentDTO(ZdravstveniKartonDTO zdravstveniKarton, bool guest, string ime, string prezime, long jmbg, int brojTelefona, string mejl, string adresaStanovanja, PolEnum pol, string username, string password, UlogaEnum uloga) : base(ime, prezime, jmbg, brojTelefona, mejl, adresaStanovanja, pol, username, password, uloga)
        {
            this.termin = new List<TerminDTO>();
            ZdravstveniKarton = zdravstveniKarton;
            Guest = guest;
        }



        public List<TerminDTO> termin;
        public bool Guest { get; set; }
        public ZdravstveniKartonDTO ZdravstveniKarton { get; set; }
    }
}
