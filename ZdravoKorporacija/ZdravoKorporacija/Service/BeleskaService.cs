using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using Model;
using Repository;

namespace ZdravoKorporacija.Service
{
    public class BeleskaService
    {
        private BeleskaRepozitorijum beleskaRepozitorijum = new BeleskaRepozitorijum();

        public void sacuvajBelesku(Beleska beleska)
        {
            List<Beleska> beleske = beleskaRepozitorijum.DobaviSve();
            beleska.Id = beleske.Count + 1;
            beleske.Add(beleska);
            beleskaRepozitorijum.Sacuvaj(beleske);
        }

        public List<Beleska> dobaviSveBeleske()
        {
            return beleskaRepozitorijum.DobaviSve();
        }

    }
}
