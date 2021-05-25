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
            List<Lekar> lekari = datoteka.dobaviSve();
            return lekari;
        }

    }
}
