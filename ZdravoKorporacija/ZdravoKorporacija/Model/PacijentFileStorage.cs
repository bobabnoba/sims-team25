using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ZdravoKorporacija.Model
{
    class PacijentFileStorage
    {

        public bool KreirajNalogPacijentu(Pacijent pacijent)
        {
            DatotekaPacijentJSON datoteka = new DatotekaPacijentJSON();
            List<Pacijent> pacijenti = datoteka.CitanjeIzFajla();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent))
                {
                    return false;
                }
            }
            pacijenti.Add(pacijent);
            datoteka.UpisivanjeUFajl(pacijenti);
            return true;
        }

        public bool ObrisiNalogPacijentu(Pacijent pacijent)
        {
            DatotekaPacijentJSON datoteka = new DatotekaPacijentJSON();
            List<Pacijent> pacijenti = datoteka.CitanjeIzFajla();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    datoteka.UpisivanjeUFajl(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajPacijenta(Pacijent pacijent)
        {
            DatotekaPacijentJSON datoteka = new DatotekaPacijentJSON();
            List<Pacijent> pacijenti = datoteka.CitanjeIzFajla();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    pacijenti.Add(pacijent);
                    datoteka.UpisivanjeUFajl(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public Pacijent PregledPacijenta(string jmbg)
        {
            DatotekaPacijentJSON datoteka = new DatotekaPacijentJSON();
            List<Pacijent> pacijenti = datoteka.CitanjeIzFajla();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(jmbg))
                {
                    return p;
                }
            }
            return null;
        }

        public List<Pacijent> PregledSvihPacijenata()
        {
            DatotekaPacijentJSON datoteka = new DatotekaPacijentJSON();
            List<Pacijent> pacijenti = datoteka.CitanjeIzFajla();
            return pacijenti;
        }


    }
}
