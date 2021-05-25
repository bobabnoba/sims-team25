using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    public class ZdravstveniKartonDTO
    {
        public System.Collections.ArrayList izvestajOHospitalizaciji;


        public ZdravstveniKartonDTO(Pacijent patient, long id, StanjePacijentaEnum zdravstvenoStanje, string alergije, KrvnaGrupaEnum krvnaGrupa, string vakcine)
        {
            this.izvestajOHospitalizaciji = new System.Collections.ArrayList();
            this.istorijaBolesti = new List<IstorijaBolesti>();
            this.recept = new ObservableCollection<ReceptDTO>();
            this.termin = new List<TerminDTO>();
            this.patient = patient;
            Id = id;
            ZdravstvenoStanje = zdravstvenoStanje;
            Alergije = alergije;
            KrvnaGrupa = krvnaGrupa;
            Vakcine = vakcine;
        }

        public ZdravstveniKartonDTO()
        {
        }

        public ZdravstveniKartonDTO(ZdravstveniKarton zk)
        {
            if (zk != null)
            {
                izvestajOHospitalizaciji = zk.izvestajOHospitalizaciji;
                istorijaBolesti = zk.istorijaBolesti;
                recept = receptToReceptDTO(zk.recept);
                termin = terminToTerminDTO(zk.termin);
                patient = patient;
                Id = zk.Id;
                ZdravstvenoStanje = zk.ZdravstvenoStanje;
                Alergije = zk.Alergije;
                KrvnaGrupa = zk.KrvnaGrupa;
                Vakcine = zk.Vakcine;
            }
        }

        public ObservableCollection<ReceptDTO> receptToReceptDTO(ObservableCollection<Recept> recepti)
        {
            if (recepti != null)
            {
                ObservableCollection<ReceptDTO> receptiDTO = new ObservableCollection<ReceptDTO>();
                foreach (Recept lek in recepti)
                {
                    receptiDTO.Add(new ReceptDTO(lek));
                }

                return receptiDTO;
            }
            else
            {
                return new ObservableCollection<ReceptDTO>();
            }
        }

        public List<TerminDTO> terminToTerminDTO(List<Termin> termini)
        {
            if (termini != null)
            {
                List<TerminDTO> terminiDTO = new List<TerminDTO>();
                foreach (Termin lek in termini)
                {
                    terminiDTO.Add(new TerminDTO(lek));
                }

                return terminiDTO;
            }
            else
            {
                return new List<TerminDTO>();
            }
        }

            /// <pdGenerated>default getter</pdGenerated>
            public System.Collections.ArrayList GetIzvestajOHospitalizaciji()
        {
            if (izvestajOHospitalizaciji == null)
                izvestajOHospitalizaciji = new System.Collections.ArrayList();
            return izvestajOHospitalizaciji;
        }


        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveIzvestajOHospitalizaciji(IzvestajOHospitalizaciji oldIzvestajOHospitalizaciji)
        {
            if (oldIzvestajOHospitalizaciji == null)
                return;
            if (this.izvestajOHospitalizaciji != null)
                if (this.izvestajOHospitalizaciji.Contains(oldIzvestajOHospitalizaciji))
                {
                    this.izvestajOHospitalizaciji.Remove(oldIzvestajOHospitalizaciji);
                    oldIzvestajOHospitalizaciji.SetZdravstveniKarton((ZdravstveniKarton)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllIzvestajOHospitalizaciji()
        {
            if (izvestajOHospitalizaciji != null)
            {
                System.Collections.ArrayList tmpIzvestajOHospitalizaciji = new System.Collections.ArrayList();
                foreach (IzvestajOHospitalizaciji oldIzvestajOHospitalizaciji in izvestajOHospitalizaciji)
                    tmpIzvestajOHospitalizaciji.Add(oldIzvestajOHospitalizaciji);
                izvestajOHospitalizaciji.Clear();
                foreach (IzvestajOHospitalizaciji oldIzvestajOHospitalizaciji in tmpIzvestajOHospitalizaciji)
                    oldIzvestajOHospitalizaciji.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpIzvestajOHospitalizaciji.Clear();
            }
        }
        public List<IstorijaBolesti> istorijaBolesti;

        /// <pdGenerated>default getter</pdGenerated>
        public List<IstorijaBolesti> GetIstorijaBolesti()
        {
            if (istorijaBolesti == null)
                istorijaBolesti = new List<IstorijaBolesti>();
            return istorijaBolesti;
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveIstorijaBolesti(IstorijaBolesti oldIstorijaBolesti)
        {
            if (oldIstorijaBolesti == null)
                return;
            if (this.istorijaBolesti != null)
                if (this.istorijaBolesti.Contains(oldIstorijaBolesti))
                {
                    this.istorijaBolesti.Remove(oldIstorijaBolesti);
                    oldIstorijaBolesti.SetZdravstveniKarton((ZdravstveniKarton)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllIstorijaBolesti()
        {
            if (istorijaBolesti != null)
            {
                System.Collections.ArrayList tmpIstorijaBolesti = new System.Collections.ArrayList();
                foreach (IstorijaBolesti oldIstorijaBolesti in istorijaBolesti)
                    tmpIstorijaBolesti.Add(oldIstorijaBolesti);
                istorijaBolesti.Clear();
                foreach (IstorijaBolesti oldIstorijaBolesti in tmpIstorijaBolesti)
                    oldIstorijaBolesti.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpIstorijaBolesti.Clear();
            }
        }
        public ObservableCollection<ReceptDTO> recept;

        /// <pdGenerated>default getter</pdGenerated>
        public ObservableCollection<ReceptDTO> GetRecept()
        {
            if (recept == null)
                recept = new ObservableCollection<ReceptDTO>();
            return recept;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRecept(ObservableCollection<ReceptDTO> newRecept)
        {
            RemoveAllRecept();
            foreach (ReceptDTO oRecept in newRecept)
                AddRecept(oRecept);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddRecept(ReceptDTO newRecept)
        {
            if (newRecept == null)
                return;
            if (this.recept == null)
                this.recept = new ObservableCollection<ReceptDTO>();
            if (!this.recept.Contains(newRecept))
            {
                this.recept.Add(newRecept);
                newRecept.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveRecept(ReceptDTO oldRecept)
        {
            if (oldRecept == null)
                return;
            if (this.recept != null)
                if (this.recept.Contains(oldRecept))
                {
                    this.recept.Remove(oldRecept);
                    oldRecept.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                }
        }


        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllRecept()
        {
            if (recept != null)
            {
                System.Collections.ArrayList tmpRecept = new System.Collections.ArrayList();
                foreach (ReceptDTO oldRecept in recept)
                    tmpRecept.Add(oldRecept);
                recept.Clear();
                foreach (Recept oldRecept in tmpRecept)
                    oldRecept.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpRecept.Clear();
            }
        }
        public List<TerminDTO> termin;

        /// <pdGenerated>default getter</pdGenerated>
        public List<TerminDTO> GetTermin()
        {
            if (termin == null)
                termin = new List<TerminDTO>();
            return termin;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetTermin(System.Collections.ArrayList newTermin)
        {
            RemoveAllTermin();
            foreach (TerminDTO oTermin in newTermin)
                AddTermin(oTermin);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddTermin(TerminDTO newTermin)
        {
            if (newTermin == null)
                return;
            if (this.termin == null)
                this.termin = new List<TerminDTO>();
            if (!this.termin.Contains(newTermin))
            {
                this.termin.Add(newTermin);
                newTermin.SetZdravstveniKarton(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveTermin(TerminDTO oldTermin)
        {
            if (oldTermin == null)
                return;
            if (this.termin != null)
                if (this.termin.Contains(oldTermin))
                {
                    this.termin.Remove(oldTermin);
                    oldTermin.SetZdravstveniKarton((ZdravstveniKartonDTO)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllTermin()
        {
            if (termin != null)
            {
                System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
                foreach (TerminDTO oldTermin in termin)
                    tmpTermin.Add(oldTermin);
                termin.Clear();
                foreach (Termin oldTermin in tmpTermin)
                    oldTermin.SetZdravstveniKarton((ZdravstveniKarton)null);
                tmpTermin.Clear();
            }
        }
        public Pacijent patient { get; set; }

        public long Id { get; set; }
        public StanjePacijentaEnum ZdravstvenoStanje { get; set; }
        public String Alergije { get; set; }
        public KrvnaGrupaEnum KrvnaGrupa { get; set; }
        public String Vakcine { get; set; }
        public void dodajAlergije(string dodaj)
        {
            this.Alergije = dodaj;
        }
    }
}
