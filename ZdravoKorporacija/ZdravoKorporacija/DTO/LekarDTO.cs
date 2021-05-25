using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
    public class LekarDTO
    {
        public LekarDTO(){}

        public LekarDTO(Lekar lekarEntitet)
        {
            this.Jmbg = lekarEntitet.Jmbg;
            this.Ime = lekarEntitet.Ime;
            this.Prezime = lekarEntitet.Prezime;
            //this.termini = new ArrayList(lekarEntitet.termin);

        }

        public LekarDTO(string ime, string prezime, Int64 jmbg)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
        }

        public System.Collections.ArrayList termini;

        public String Ime { get; set; }
        public String Prezime { get; set; }
        public Int64 Jmbg { get; set; }

        
    }
}
