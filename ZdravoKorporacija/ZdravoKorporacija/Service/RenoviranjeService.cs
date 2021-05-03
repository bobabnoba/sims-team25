using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Service
{
    class RenoviranjeService
    {
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

            renoviranjeRepozitorijum.zahteviRenoviranja.Add(zahtev);
            renoviranjeRepozitorijum.Sacuvaj();
            datotekaID.sacuvaj(ids);

            return true;
        }
    }
}
