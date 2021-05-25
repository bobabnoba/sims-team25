using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class IzvestajDTO
    {
        public TerminDTO termin;

        public IzvestajDTO() { }

        public IzvestajDTO(TerminDTO termin, int id, string opis, string simptomi)
        {
            this.termin = termin;
            Id = id;
            Opis = opis;
            Simptomi = simptomi;
        }
        public IzvestajDTO(Izvestaj izvestaj)
        {
            if (izvestaj != null)
            {
                if(izvestaj.termin!=null)
                this.termin = new TerminDTO(izvestaj.termin);
                Id = izvestaj.Id;
                Opis = izvestaj.Opis;
                Simptomi = izvestaj.Simptomi;
            }
        }

        public int Id { get; set; }
        public String Opis { get; set; }
        public String Simptomi { get; set; }

    }
}
