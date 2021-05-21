using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Service;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    class NaloziController
    {
        private PacijentService pacijentServis = new PacijentService();
        private TerminService terminServis = new TerminService();
        private ZdravstveniKartonServis kartonSerivs = new ZdravstveniKartonServis();

        public bool KreirajNalogPacijentu(Pacijent pacijent)
        {
            return pacijentServis.KreirajNalogPacijentu(pacijent);
        }
        public Pacijent DTO2Model(PacijentDTO dto)
        {
            return pacijentServis.DTO2Model(dto);
        }
        public Pacijent DTO2ModelNapravi(PacijentDTO dto)
        {
            return pacijentServis.DTO2ModelNapravi(dto);
        }
    }
}
