using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Model;

namespace Service
{
    class LekarService
    {
        public List<Lekar> PregledSvihLekara()
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekovi = datoteka.dobaviSve();
            return lekovi;
        }

        public void izdajRecept()
        {

        }

    }
}
