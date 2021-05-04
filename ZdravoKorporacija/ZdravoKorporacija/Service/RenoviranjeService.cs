using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Service;

namespace Service
{
    class RenoviranjeService
    {
        ZahtevPremestanjaService zahtevP = new ZahtevPremestanjaService();
        public Boolean ZakaziRenoviranje(ZahtevRenoviranjeDTO zahtevRenoviranja)
        {
            RenoviranjeRepozitorijum renoviranjeRepozitorijum = RenoviranjeRepozitorijum.Instance;

            String s = zahtevRenoviranja.PocetakDan.ToString();
            String date = s.Split(" ")[0];

            // Debug.WriteLine(date + " " + sati);
            // Debug.WriteLine("" + s);

            DateTime pocetak = DateTime.Parse(date + " " + zahtevRenoviranja.PocetakSati);
           
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRenoviranje");
            Dictionary<int, int> ids = datotekaID.dobaviSve();

            int zahtevId = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    zahtevId = i;
                    ids[i] = 1;
                    break;
                }
            }



            int minuta = 0;
            try { minuta = int.Parse(zahtevRenoviranja.Trajanje); }
            catch (Exception)
            {
            }
            
            DateTime kraj = pocetak.AddMinutes(minuta);

            ZahtevRenoviranja zahtev = new ZahtevRenoviranja(zahtevId,zahtevRenoviranja.Prostorija,pocetak,kraj,zahtevRenoviranja.Trajanje);
            System.Collections.ArrayList oprema = new System.Collections.ArrayList();
            oprema=  zahtevRenoviranja.Prostorija.statickaOprema;

            if (oprema != null)
            {
                foreach (StatickaOprema st in oprema)
                {
                    Inventar invent = (Inventar)st;
                    ZahtevPremestanja zp = new ZahtevPremestanja();
                    zp.prostorija = zahtevRenoviranja.Prostorija;
                    IDRepozitorijum datotekaIDPremestanja = new IDRepozitorijum("iDMapZahtevPremestanja");
                    Dictionary<int, int> idsP = datotekaID.dobaviSve();

                    zahtevP.ZakaziPremestanje(invent, zp, zahtevRenoviranja.PocetakDan, zahtevRenoviranja.PocetakSati, zahtevRenoviranja.Trajanje, idsP);
                }
            }
            renoviranjeRepozitorijum.zahteviRenoviranja.Add(zahtev);
            renoviranjeRepozitorijum.Sacuvaj();
            datotekaID.sacuvaj(ids);

            return true;
        }
    }
}
