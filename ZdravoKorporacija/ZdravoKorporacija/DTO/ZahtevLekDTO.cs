using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class ZahtevLekDTO
    {
        public int Id { get; set; }
        public LekDTO Lek { get; set; }

        public List<Lekar> lekari;
        public List<Lekar> Getlekari()
        {
            if (lekari == null)
                lekari = new List<Lekar>();
            return lekari;
        }

        public void Setlekari(List<Lekar> newlekari)
        {
            RemoveAlllekari();
            foreach (Lekar oLekar in newlekari)
                Addlekari(oLekar);
        }

        public void Addlekari(Lekar newLekar)
        {
            if (newLekar == null)
                return;
            if (this.lekari == null)
                this.lekari = new List<Lekar>();
            if (!this.lekari.Contains(newLekar))
                this.lekari.Add(newLekar);
        }

        public void Removelekari(Lekar oldLekar)
        {
            if (oldLekar == null)
                return;
            if (this.lekari != null)
                if (this.lekari.Contains(oldLekar))
                    this.lekari.Remove(oldLekar);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAlllekari()
        {
            if (lekari != null)
                lekari.Clear();
        }

        public int NeophodnihPotvrda { get; set; }

        public int BrojPotvrda { get; set; }

        public ZahtevLekDTO(LekDTO lek, int neophodnihPotvrda, int brojTrenutnihPotvrda)
        {
            this.Lek = lek;
            this.NeophodnihPotvrda = neophodnihPotvrda;
            this.BrojPotvrda = brojTrenutnihPotvrda;
            this.lekari = new List<Lekar>();
        }
    }
}
