using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class ZahtevRenoviranja
    {
        public int Id { get; set; }
        public Prostorija Prostorija { get; set; }

        public DateTime Pocetak { get; set; }

        public DateTime Kraj { get; set; }
        public String Trajanje { get; set; }

        public ZahtevRenoviranja(int id, Prostorija prostorija, DateTime pocetak, DateTime kraj, String trajanje)
        {
            Id = id;
            Prostorija = prostorija;
            Pocetak = pocetak;
            Kraj = kraj;
            Trajanje = trajanje;
        }
    }
}
