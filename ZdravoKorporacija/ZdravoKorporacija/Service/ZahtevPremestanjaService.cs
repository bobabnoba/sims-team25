using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Service
{
    class ZahtevPremestanjaService
    {

        public bool ZakaziPremestanje(InventarDTO inventar, ZahtevPremestanjaDTO zahtevPremestanja, DateTime dt, string sati, string trajanje)
        {
            ZahtevPremestanjaRepozitorijum datoteka = ZahtevPremestanjaRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevPremestanja");
            Dictionary<int, int> ids = datotekaID.dobaviSve();

            int id = nadjiSlobodanID(ids);
            ids[id] = 1;

            zahtevPremestanja.Id = id;
            zahtevPremestanja.StatickaOprema = new StatickaOpremaDTO(inventar);
            StatickaOpremaDTO stat = new StatickaOpremaDTO(inventar);
            zahtevPremestanja.prostorija.statickaOprema = new System.Collections.ArrayList();
            zahtevPremestanja.prostorija.statickaOprema.Add(stat);

            String s = dt.ToString();
            String date = s.Split(" ")[0];

            DateTime datum = DateTime.Parse(date + " " + sati);
            zahtevPremestanja.Pocetak = datum;
            int minuta = 0;
            try { minuta = int.Parse(trajanje); }
            catch (Exception)
            {
            }
            zahtevPremestanja.Kraj = zahtevPremestanja.Pocetak.AddMinutes(minuta);

            ZahtevPremestanja zahtev = new ZahtevPremestanja(zahtevPremestanja);

            ZahtevPremestanjaRepozitorijum.Instance.zahtevi.Add(zahtev);
            datoteka.sacuvaj();
            datotekaID.sacuvaj(ids);

            return true;
        }

        public List<ZahtevPremestanja> PregledSveOpreme()
        {
            ZahtevPremestanjaRepozitorijum zpr = ZahtevPremestanjaRepozitorijum.Instance;
            return zpr.dobaviSve();
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
