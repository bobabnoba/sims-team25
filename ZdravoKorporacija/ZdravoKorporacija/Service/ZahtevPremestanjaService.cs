using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.Service
{
    class ZahtevPremestanjaService
    {

        public bool ZakaziPremestanje(Inventar inventar, ZahtevPremestanja zahtevPremestanja, DateTime dt, string sati, string trajanje, Dictionary<int, int> ids)
        {
            ZahtevPremestanjaRepozitorijum datoteka = ZahtevPremestanjaRepozitorijum.Instance;
            List<ZahtevPremestanja> zahtevi = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevPremestanja");


            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }

            zahtevPremestanja.Id = id;


            zahtevPremestanja.StatickaOprema = new StatickaOprema(inventar);
            StatickaOprema stat = new StatickaOprema(inventar);
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

            zahtevi.Add(zahtevPremestanja);
            datoteka.sacuvaj(zahtevi);
            datotekaID.sacuvaj(ids);

            return true;
        }

        public List<ZahtevPremestanja> PregledSveOpreme()
        {
            ZahtevPremestanjaRepozitorijum zpr = ZahtevPremestanjaRepozitorijum.Instance;
            return zpr.dobaviSve();
        }
    }
}
