using System.Collections.Generic;

namespace ZdravoKorporacija.Model
{
    class ProstorijaFileStorage
    {
        public bool DodajProstoriju(Prostorija prostorija)
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    return false;
                }
            }
            prostorije.Add(prostorija);
            datoteka.UpisivanjeUFajl(prostorije);
            return true;

        }

        public bool ObrisiProstoriju(Prostorija prostorija)
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    prostorije.Remove(pr);
                    datoteka.UpisivanjeUFajl(prostorije);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajProstoriju(Prostorija prostorija)
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    prostorije.Remove(pr);
                    prostorije.Add(prostorija);
                    datoteka.UpisivanjeUFajl(prostorije);
                    return true;
                }
            }
            return false;
        }

        public Prostorija PregledProstorije(string id)
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(id))
                {
                    return pr;
                }
            }
            return null;
        }

        public List<Prostorija> PregledSvihProstorija()
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();
            return prostorije;
        }


    }
}
