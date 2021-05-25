using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class ZahtevRenoviranjeDTO
    {
        public int Id { get; set; }
        public ProstorijaDTO Prostorija { get; set; }
        
        public DateTime PocetakDan { get; set; }

        public String PocetakSati { get; set; }
        public String Trajanje { get; set; }

        public ZahtevRenoviranjeDTO(int id, ProstorijaDTO prostorija, DateTime pocetakD,String pocetakS, String trajanje)
        {
            Id = id;
            Prostorija = prostorija;
            PocetakDan = pocetakD;
            PocetakSati = pocetakS;
            Trajanje = trajanje;
        }
    }
}
