using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Controller
{
    public class RenoviranjeController
    {
        RenoviranjeService renoviranjeServis = new RenoviranjeService();
        public Boolean ZakaziRenoviranje(ZahtevRenoviranjeDTO zahtevRenoviranja)
        {
            return renoviranjeServis.ZakaziRenoviranje(zahtevRenoviranja);
        }
    }
}
