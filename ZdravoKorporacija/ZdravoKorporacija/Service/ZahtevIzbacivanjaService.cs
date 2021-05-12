using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Repository;

namespace Service
{
    class ZahtevIzbacivanjaService
    {
        public bool ZakaziIzbacivanje(Inventar inventar, ZahtevIzbacivanja zahtevIzabacivanja, DateTime dt, string sati, string trajanje, Dictionary<int, int> ids)
        {
            ZahtevIzbacivanjaRepozitorijum datoteka = ZahtevIzbacivanjaRepozitorijum.Instance;
            List<ZahtevIzbacivanja> zahtevi = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevIzbacivanja");


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

            zahtevIzabacivanja.Id = id;


            zahtevIzabacivanja.StatickaOprema = new StatickaOprema(inventar);
            StatickaOprema stat = new StatickaOprema(inventar);
            zahtevIzabacivanja.prostorija.statickaOprema = new List<StatickaOprema>();
            zahtevIzabacivanja.prostorija.statickaOprema.Add(stat);

            String s = dt.ToString();
            String date = s.Split(" ")[0];

            DateTime datum = DateTime.Parse(date + " " + sati);
            zahtevIzabacivanja.Pocetak = datum;
            int minuta = 0;
            try { minuta = int.Parse(trajanje); }
            catch (Exception)
            {
            }
            zahtevIzabacivanja.Kraj = zahtevIzabacivanja.Pocetak.AddMinutes(minuta);

            zahtevi.Add(zahtevIzabacivanja);
            datoteka.sacuvaj(zahtevi);
            datotekaID.sacuvaj(ids);

            return true;
        }



        public List<ZahtevIzbacivanja> PregledSvihZahtevaIzbacivanja()
        {
          ZahtevIzbacivanjaRepozitorijum zpr = ZahtevIzbacivanjaRepozitorijum.Instance;
            return zpr.dobaviSve();
        }
    }
}
