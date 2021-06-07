using Service;
using System;
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
