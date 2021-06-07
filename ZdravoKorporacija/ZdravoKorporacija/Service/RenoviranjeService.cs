using Model;
using Repository;
using System;
using System.Collections.Generic;
using ZdravoKorporacija.DTO;

namespace Service
{
    class RenoviranjeService
    {
        ZahtevPremestanjaService zahtevP = new ZahtevPremestanjaService();
        ZahtevIzbacivanjaService zahtevI = new ZahtevIzbacivanjaService();
        public Boolean ZakaziRenoviranje(ZahtevRenoviranjeDTO zahtevRenoviranjaDTO)
        {
            RenoviranjeRepozitorijum renoviranjeRepozitorijum = RenoviranjeRepozitorijum.Instance;

            String s = zahtevRenoviranjaDTO.PocetakDan.ToString();
            String date = s.Split(" ")[0];

            DateTime pocetak = DateTime.Parse(date + " " + zahtevRenoviranjaDTO.PocetakSati);

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRenoviranje");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            int zahtevId = nadjiSlobodanID(ids);
            ids[zahtevId] = 1;


            int minuta = 0;
            try { minuta = int.Parse(zahtevRenoviranjaDTO.Trajanje); }
            catch (Exception)
            {
            }

            DateTime kraj = pocetak.AddMinutes(minuta);

            ZahtevRenoviranja zahtev = new ZahtevRenoviranja(zahtevId, new Prostorija(zahtevRenoviranjaDTO.Prostorija), pocetak, kraj, zahtevRenoviranjaDTO.Trajanje);

            List<StatickaOprema> oprema = zahtev.Prostorija.statickaOprema;

            if (oprema != null)
            {
                foreach (StatickaOprema st in oprema)
                {
                    InventarDTO inventar = (InventarDTO)st;
                    ZahtevPremestanjaDTO zp = new ZahtevPremestanjaDTO();
                    zp.prostorija = new ProstorijaDTO(zahtev.Prostorija);
                    ZahtevIzbacivanja zi = new ZahtevIzbacivanja();
                    zi.prostorija = zahtev.Prostorija;
                    zp.Pocetak = zahtevRenoviranjaDTO.PocetakDan;

                    zahtevI.ZakaziIzbacivanje(inventar, zi, zahtevRenoviranjaDTO.PocetakDan, zahtevRenoviranjaDTO.PocetakSati, zahtevRenoviranjaDTO.Trajanje);
                    zahtevP.ZakaziPremestanje(inventar, zp, zahtevRenoviranjaDTO.PocetakSati, zahtevRenoviranjaDTO.Trajanje);
                }
            }

            renoviranjeRepozitorijum.zahteviRenoviranja.Add(zahtev);
            renoviranjeRepozitorijum.Sacuvaj();
            datotekaID.sacuvaj(ids);

            return true;
        }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
        }

    }
}
