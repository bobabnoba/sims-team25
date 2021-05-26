using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
    public class ReceptDTO
    {
        public ReceptDTO(int id, string doziranje, int trajanje, string nazivLeka, DateTime pocetak, LekarDTO lekar, ZdravstveniKartonDTO zdravstveniKarton)
        {
            Id = id;
            Doziranje = doziranje;
            Trajanje = trajanje;
            NazivLeka = nazivLeka;
            Pocetak = pocetak;
            Lekar = lekar;
            ZdravstveniKarton = zdravstveniKarton;
        }

        public int Id { get; set; }
            public String Doziranje { get; set; }
            public int Trajanje { get; set; }
            public String NazivLeka { get; set; }
            public DateTime Pocetak { get; set; }
            public LekarDTO Lekar { get; set; }
        public ZdravstveniKartonDTO ZdravstveniKarton { get; set; }

        //public System.Collections.ArrayList lek;

        ///// <pdGenerated>default getter</pdGenerated>
        //public System.Collections.ArrayList GetLek()
        //{
        //    if (lek == null)
        //        lek = new System.Collections.ArrayList();
        //    return lek;
        //}

        ///// <pdGenerated>default setter</pdGenerated>
        //public void SetLek(System.Collections.ArrayList newLek)
        //{
        //    RemoveAllLek();
        //    foreach (Lek oLek in newLek)
        //        AddLek(oLek);
        //}

        ///// <pdGenerated>default Add</pdGenerated>
        //public void AddLek(Lek newLek)
        //{
        //    if (newLek == null)
        //        return;
        //    if (this.lek == null)
        //        this.lek = new System.Collections.ArrayList();
        //    if (!this.lek.Contains(newLek))
        //        this.lek.Add(newLek);
        //}

        ///// <pdGenerated>default Remove</pdGenerated>
        //public void RemoveLek(Lek oldLek)
        //{
        //    if (oldLek == null)
        //        return;
        //    if (this.lek != null)
        //        if (this.lek.Contains(oldLek))
        //            this.lek.Remove(oldLek);
        //}

        ///// <pdGenerated>default removeAll</pdGenerated>
        //public void RemoveAllLek()
        //{
        //    if (lek != null)
        //        lek.Clear();
    }
    

}
