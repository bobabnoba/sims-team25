using Model;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ZdravoKorporacija.DTO;

namespace Service
{
    class ProstorijaService
    {
        ProstorijaRepozitorijum datoteka = ProstorijaRepozitorijum.Instance;
        public bool DodajProstoriju(ProstorijaDTO prostorijaDTO, Dictionary<int, int> id_map)
        {
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");

            Prostorija prostorija = new Prostorija(prostorijaDTO);
            ProstorijaRepozitorijum.Instance.prostorije.Add(prostorija);
            
            datoteka.sacuvaj();
            datotekaID.sacuvaj(id_map);
            return true;

        }

        public bool ObrisiProstoriju(ProstorijaDTO obrisanaProstorijaDTO, Dictionary<int, int> id_map)
        {
            Prostorija obrisanaProstorija = new Prostorija(obrisanaProstorijaDTO);
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapProstorija");
          
            foreach (Prostorija prostorija in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (prostorija.Id == obrisanaProstorija.Id)
                {
                    ProstorijaRepozitorijum.Instance.prostorije.Remove(prostorija);
                    datoteka.sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public bool AzurirajProstoriju(ProstorijaDTO novaProstorijaDTO, int indeks)
        {
            Prostorija novaProstorija = new Prostorija(novaProstorijaDTO);
            foreach (Prostorija prostorija in ProstorijaRepozitorijum.Instance.prostorije)
            {
                if (prostorija.Id == novaProstorija.Id)
                {
                    ProstorijaRepozitorijum.Instance.prostorije.Remove(prostorija);
                    ProstorijaRepozitorijum.Instance.prostorije.Insert(indeks, novaProstorija);
                    datoteka.sacuvaj();
                    return true;
                }
            }
            return false;
        }

        public Prostorija PregledProstorije(string id)
        {
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
            return datoteka.dobaviSve();  
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO()
        {
            ObservableCollection<Prostorija> prostorije = datoteka.dobaviSve();
            ObservableCollection<ProstorijaDTO> prostorijeDTO = new ObservableCollection<ProstorijaDTO>();
            foreach(Prostorija prostorija in prostorije)
            {
                prostorijeDTO.Add(konvertujEntitetUDTO(prostorija));
            }
            return prostorijeDTO;
            
        }

        public ProstorijaDTO konvertujEntitetUDTO(Prostorija prostorija) {
            return new ProstorijaDTO(prostorija);
        }

        
    }
}
