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

        public KartonService()
        {
            kartonRep = new KartonRepozitorijum();
            ps = new PacijentService();
            pacijentRep = new PacijentRepozitorijum();
        }
        
       
    }
}
