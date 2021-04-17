using System.Collections.Generic;

namespace ZdravoKorporacija.Model
{
    class ProstorijaFileStorage
    {
        public bool DodajProstoriju(Prostorija prostorija, Dictionary<int, int> id_map)
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();

            IDSerializer datotekaID = new IDSerializer("iDMapProstorija");
       

            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    return false;
                }
            }
            prostorije.Add(prostorija);
            datoteka.UpisivanjeUFajl(prostorije);
            datotekaID.UpisivanjeUFajl(id_map);
            return true;

        }

        public bool ObrisiProstoriju(Prostorija prostorija, Dictionary<int, int> id_map)
        {
            DatotekaProstorijaJSON datoteka = new DatotekaProstorijaJSON();
            IDSerializer datotekaID = new IDSerializer("iDMapProstorija");
            List<Prostorija> prostorije = datoteka.CitanjeIzFajla();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    prostorije.Remove(pr);
                    datoteka.UpisivanjeUFajl(prostorije);
                    datotekaID.UpisivanjeUFajl(id_map);
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
