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



        public List<ProstorijaDTO> prostorije;

        public List<ProstorijaDTO> Getprostorije()
        {
            if (prostorije == null)
                prostorije = new List<ProstorijaDTO> ();
            return prostorije;
        }

        public void Setprostorije(List<ProstorijaDTO> newProstorije)
        {
            RemoveAllprostorije();
            foreach (ProstorijaDTO oProstorija in newProstorije)
                Addprostorije(oProstorija);
        }

        public void Addprostorije(ProstorijaDTO newProstorija)
        {
            if (newProstorija == null)
                return;
            if (this.prostorije == null)
                this.prostorije = new List<ProstorijaDTO>();
            if (!this.prostorije.Contains(newProstorija))
                this.prostorije.Add(newProstorija);
        }

        public void Removeprostorije(ProstorijaDTO oldProstorija)
        {
            if (oldProstorija == null)
                return;
            if (this.prostorije != null)
                if (this.prostorije.Contains(oldProstorija))
                    this.prostorije.Remove(oldProstorija);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllprostorije()
        {
            if (prostorije != null)
               prostorije.Clear();
        }



        public ZahtevRenoviranjeDTO() { }
        public ZahtevRenoviranjeDTO(int id, ProstorijaDTO prostorija, DateTime pocetakD,String pocetakS, String trajanje)
        {
            Id = id;
            Prostorija = prostorija;
            PocetakDan = pocetakD;
            PocetakSati = pocetakS;
            Trajanje = trajanje;
            prostorije = new List<ProstorijaDTO>();
        }
    }
}
