using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class PacijentController
    {
        private static PacijentController _instance;
        PacijentService pacijentServis = PacijentService.Instance;
        public static PacijentController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PacijentController();
                }
                return _instance;
            }
        }
        public bool IzdajRecept(PacijentDTO pacijent, ReceptDTO recept)
        {
            return pacijentServis.IzdajRecept(pacijent, recept);
        }
        public bool ObrisiRecept(PacijentDTO pacijent, ReceptDTO recept)
        {
           return pacijentServis.ObrisiRecept(pacijent, recept);
        }
        public List<PacijentDTO> PregledSvihPacijenata2()
        {
            return pacijentServis.PregledSvihPacijenata2();
        }
    }
}
