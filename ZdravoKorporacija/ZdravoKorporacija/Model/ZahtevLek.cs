using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.Model
{
    class ZahtevLek
    {
        public int Id { get; set; }
        public Lek Lek { get; set; }

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

        public List<Lek> alternativniLekovi;
        public List<Lek> GetalternativniLekovi()
        {
            if (alternativniLekovi == null)
                alternativniLekovi = new List<Lek>();
            return alternativniLekovi;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetalternativniLekovi(List<Lek> newalternativniLekovi)
        {
            RemoveAllalternativniLekovi();
            foreach (Lek oLek in newalternativniLekovi)
                AddalternativniLekovi(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddalternativniLekovi(Lek newLek)
        {
            if (newLek == null)
                return;
            if (this.alternativniLekovi == null)
                this.alternativniLekovi = new List<Lek>();
            if (!this.alternativniLekovi.Contains(newLek))
                this.alternativniLekovi.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovealternativniLekovi(Lek oldLek)
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
        public ZahtevLek(Lek lek,int neophodnihPotvrda,int brojTrenutnihPotvrda) {
            this.Lek = lek;
            this.NeophodnihPotvrda = neophodnihPotvrda;
            this.BrojPotvrda = brojTrenutnihPotvrda;
            this.lekari = new List<Lekar>();
            this.alternativniLekovi = new List<Lek>();
        }
    }
}
