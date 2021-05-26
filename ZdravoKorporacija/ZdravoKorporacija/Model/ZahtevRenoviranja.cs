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


        public List<Prostorija> prostorije;

        public List<Prostorija> Getprostorije()
        {
            if (prostorije == null)
                prostorije = new List<Prostorija>();
            return prostorije;
        }

        public void Setprostorije(List<Prostorija> newProstorije)
        {
            RemoveAllprostorije();
            foreach (Prostorija oProstorija in newProstorije)
                Addprostorije(oProstorija);
        }

        public void Addprostorije(Prostorija newProstorija)
        {
            if (newProstorija == null)
                return;
            if (this.prostorije == null)
                this.prostorije = new List<Prostorija>();
            if (!this.prostorije.Contains(newProstorija))
                this.prostorije.Add(newProstorija);
        }

        public void Removeprostorije(Prostorija oldProstorija)
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



        public ZahtevRenoviranja(int id, Prostorija prostorija, DateTime pocetak, DateTime kraj, String trajanje)
        {
            Id = id;
            Prostorija = prostorija;
            Pocetak = pocetak;
            Kraj = kraj;
            Trajanje = trajanje;
            prostorije = new List<Prostorija>();
        }
    }
}
