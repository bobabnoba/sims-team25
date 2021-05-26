using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class LekDTO
    {
        public int Id { get; set; }
        public String Proizvodjac { get; set; }
        public String Sastojci { get; set; }
        public String NusPojave { get; set; }
        public String NazivLeka { get; set; }

        public String Alergeni { get; set; }

        public List<LekDTO> alternativniLekovi;

        /// <pdGenerated>default getter</pdGenerated>
        public List<LekDTO> GetalternativniLekovi()
        {
            if (alternativniLekovi == null)
                alternativniLekovi = new List<LekDTO>();
            return alternativniLekovi;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetalternativniLekovi(List<LekDTO> newalternativniLekovi)
        {
            RemoveAllalternativniLekovi();
            foreach (LekDTO oLek in newalternativniLekovi)
                AddalternativniLekovi(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddalternativniLekovi(LekDTO newLek)
        {
            if (newLek == null)
                return;
            if (this.alternativniLekovi == null)
                this.alternativniLekovi = new List<LekDTO>();
            if (!this.alternativniLekovi.Contains(newLek))
                this.alternativniLekovi.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovealternativniLekovi(LekDTO oldLek)
        {
            if (oldLek == null)
                return;
            if (this.alternativniLekovi != null)
                if (this.alternativniLekovi.Contains(oldLek))
                    this.alternativniLekovi.Remove(oldLek);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllalternativniLekovi()
        {
            if (alternativniLekovi != null)
                alternativniLekovi.Clear();
        }
        public LekDTO()
        { }
        public LekDTO(int ID, String pr, String sas, String np, String nl)
        {
            Id = ID;
            Proizvodjac = pr;
            Sastojci = sas;
            NusPojave = np;
            NazivLeka = nl;
            this.alternativniLekovi = new List<LekDTO>();
        }

        public LekDTO(Lek lek)
        {
            Id = lek.Id;
            Proizvodjac = lek.Proizvodjac;
            Sastojci = lek.Sastojci;
            NusPojave = lek.NusPojave;
            NazivLeka = lek.NazivLeka;
            Alergeni = lek.Alergeni;
            this.alternativniLekovi = LekToLekDTO(lek.alternativniLekovi);
        }
        public List<LekDTO> LekToLekDTO(List<Lek> Lekovi)
        {
            if (Lekovi != null)
            {
                List<LekDTO> LekoviDTO = new List<LekDTO>();
                foreach (Lek Lek in Lekovi)
                {
                    LekoviDTO.Add(new LekDTO(Lek));
                }

                return LekoviDTO;
            }
            else
            {
                return new List<LekDTO>();
            }
        }
    }
}
