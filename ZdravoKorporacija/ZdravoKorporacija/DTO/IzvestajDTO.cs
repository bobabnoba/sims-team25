using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class IzvestajDTO
    {
        public IzvestajDTO() {}
        public IzvestajDTO(int id, string opis, string simptomi, TerminDTO termin)
        {
            Id = id;
            Opis = opis;
            Simptomi = simptomi;
            Termin = termin;
        }

        public IzvestajDTO(Izvestaj izvestaj)
        {
            Id = izvestaj.Id;
            Opis = izvestaj.Opis;
            Simptomi = izvestaj.Simptomi;
            Termin = new TerminDTO(izvestaj.termin);
        }

        public int Id { get; set; }
        public String Opis { get; set; }
        public String Simptomi { get; set; }

        public TerminDTO Termin { get; set; }

    }
}
