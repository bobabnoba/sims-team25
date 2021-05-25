using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model;

namespace ZdravoKorporacija.DTO
{
    public class PacijentDTO
    {
        public String korisnickoIme { get; set; }
        public String lozinka { get; set; }
        public ZdravstveniKartonDTO ZdravstveniKarton { get; set; }
        public Int64 Jmbg { get; set; }


        public ObservableCollection<NotifikacijaDTO> notifikacije;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<NotifikacijaDTO> GetNotifikacije()
        {
            if (notifikacije == null)
                notifikacije = new ObservableCollection<NotifikacijaDTO>();
            return notifikacije;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetNotifikacije(ObservableCollection<NotifikacijaDTO> newNotifikacije)
        {
            RemoveAllNotifikacije();
            foreach (NotifikacijaDTO oNotifikacije in newNotifikacije)
                AddNotifikacije(oNotifikacije);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddNotifikacije(NotifikacijaDTO newNotifikacije)
        {
            if (newNotifikacije == null)
                return;
            if (this.notifikacije == null)
                this.notifikacije = new ObservableCollection<NotifikacijaDTO>();
            if (!this.notifikacije.Contains(newNotifikacije))
                this.notifikacije.Add(newNotifikacije);
        }

        public void RemoveAllNotifikacije()
        {
            if (notifikacije != null)
                notifikacije.Clear();
        }

        public PacijentDTO(){}

        public PacijentDTO(String korisnickoIme, String lozinka, ZdravstveniKartonDTO zdravstveniKarton, Int64 jmbg)
        {
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.ZdravstveniKarton = zdravstveniKarton;
            this.notifikacije = new ObservableCollection<NotifikacijaDTO>();
            this.Jmbg = jmbg;
        }
        

    }
}
