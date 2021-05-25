using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class ReceptDTO
    {
        public int Id { get; set; }
        public String Doziranje { get; set; }
        public int Trajanje { get; set; }
        public String NazivLeka { get; set; }
        public DateTime Pocetak { get; set; }

        public System.Collections.ArrayList lek;


        public ReceptDTO() { }
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetLek()
        {
            if (lek == null)
                lek = new System.Collections.ArrayList();
            return lek;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetLek(System.Collections.ArrayList newLek)
        {
            RemoveAllLek();
            foreach (LekDTO oLek in newLek)
                AddLek(oLek);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddLek(LekDTO newLek)
        {
            if (newLek == null)
                return;
            if (this.lek == null)
                this.lek = new System.Collections.ArrayList();
            if (!this.lek.Contains(newLek))
                this.lek.Add(newLek);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveLek(LekDTO oldLek)
        {
            if (oldLek == null)
                return;
            if (this.lek != null)
                if (this.lek.Contains(oldLek))
                    this.lek.Remove(oldLek);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllLek()
        {
            if (lek != null)
                lek.Clear();
        }
        public LekarDTO lekar;
        public ZdravstveniKartonDTO zdravstveniKarton;

        /// <pdGenerated>default parent getter</pdGenerated>
        public ZdravstveniKartonDTO GetZdravstveniKarton()
        {
            return zdravstveniKarton;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newZdravstveniKarton</param>
        public void SetZdravstveniKarton(ZdravstveniKartonDTO newZdravstveniKarton)
        {
            if (this.zdravstveniKarton != newZdravstveniKarton)
            {
                if (this.zdravstveniKarton != null)
                {
                    ZdravstveniKartonDTO oldZdravstveniKarton = this.zdravstveniKarton;
                    this.zdravstveniKarton = null;
                    oldZdravstveniKarton.RemoveRecept(this);
                }
                if (newZdravstveniKarton != null)
                {
                    this.zdravstveniKarton = newZdravstveniKarton;
                    this.zdravstveniKarton.AddRecept(this);
                }
            }
        }
    }
}
