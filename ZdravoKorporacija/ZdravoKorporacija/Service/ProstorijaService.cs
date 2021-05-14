using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Service
{
    class ProstorijaService
    {
        public bool DodajProstoriju(Prostorija prostorija, Dictionary<int, int> id_map)
        {
            ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;
           

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
            ProstorijaRepozitorijum.Instance.prostorije.Add(prostorija);
            datoteka.sacuvaj();
            datotekaID.sacuvaj(id_map);
           
            return true;

        }

        public bool ObrisiProstoriju(Prostorija prostorija, Dictionary<int, int> id_map)
        {
            ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
          
            foreach (Prostorija pr in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    ProstorijaRepozitorijum.Instance.prostorije.Remove(pr);
                    datoteka.sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajProstoriju(Prostorija prostorija, int indeks)
        {
            ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;
          
            foreach (Prostorija pr in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    ProstorijaRepozitorijum.Instance.prostorije.Remove(pr);
                    ProstorijaRepozitorijum.Instance.prostorije.Insert(indeks, prostorija);
                    datoteka.sacuvaj();
                    return true;
                }
            }
            return false;
        }

        public Prostorija PregledProstorije(string id)
        {
            ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;
          
            foreach (Prostorija pr in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (pr.Id.Equals(id))
                {
                    return pr;
                }
            }
            return null;
        }

        public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;
            ObservableCollection<Prostorija> prostorije = datoteka.dobaviSve();
            return prostorije;
        }


    }
}
