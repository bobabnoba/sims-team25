using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Service
{
    public class KartonService
    {
        private KartonRepozitorijum kartonRep;
        private PacijentService ps;
        private PacijentRepozitorijum pacijentRep;
        List<ZdravstveniKarton> kartoni = new List<ZdravstveniKarton>();

        public KartonService()
        {
            kartonRep = new KartonRepozitorijum();
            ps = new PacijentService();
            pacijentRep = new PacijentRepozitorijum();
            kartoni = kartonRep.dobaviSve();
            
        }
        
        public bool KreirajKarton(Pacijent pacijent)
        {
            ZdravstveniKarton novi = new ZdravstveniKarton();
            foreach(ZdravstveniKarton zk in kartoni)
            {
                if (zk.Id.Equals(pacijent.Jmbg))
                {
                    return false;
                }
            }
            novi.Id = (int)(pacijent.GetJmbg());
            kartoni.Add(novi);
            kartonRep.sacuvaj(kartoni);
            return true;
            
        }
       
    }
}
