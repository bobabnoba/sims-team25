using Model;
using Repository;
using System.Collections.Generic;

namespace Service
{
    class ProstorijaService
    {
        public bool DodajProstoriju(Prostorija prostorija, Dictionary<int, int> id_map)
        {
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            List<Prostorija> prostorije = datoteka.dobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
       

            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    return false;
                }
            }
            prostorije.Add(prostorija);
            datoteka.sacuvaj(prostorije);
            datotekaID.sacuvaj(id_map);
            return true;

        }

        public bool ObrisiProstoriju(Prostorija prostorija, Dictionary<int, int> id_map)
        {
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
            List<Prostorija> prostorije = datoteka.dobaviSve();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    prostorije.Remove(pr);
                    datoteka.sacuvaj(prostorije);
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajProstoriju(Prostorija prostorija)
        {
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            List<Prostorija> prostorije = datoteka.dobaviSve();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    prostorije.Remove(pr);
                    prostorije.Add(prostorija);
                    datoteka.sacuvaj(prostorije);
                    return true;
                }
            }
            return false;
        }

        public Prostorija PregledProstorije(string id)
        {
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            List<Prostorija> prostorije = datoteka.dobaviSve();
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
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            List<Prostorija> prostorije = datoteka.dobaviSve();
            return prostorije;
        }


    }
}
