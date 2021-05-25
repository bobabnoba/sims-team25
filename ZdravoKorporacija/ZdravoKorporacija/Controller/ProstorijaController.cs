using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class ProstorijaController
    {
        private ProstorijaService ps = new ProstorijaService();
        public List<ProstorijaDTO> PregledSvihProstorija2()
        {
            return ps.PregledSvihProstorija2();
        }
    }
}
