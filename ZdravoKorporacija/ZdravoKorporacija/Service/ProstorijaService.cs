using Microsoft.VisualBasic.CompilerServices;
using Model;
using Repository;
using System.Collections.Generic;
using System.Net.Http.Headers;
using ZdravoKorporacija.DTO;

namespace Service
{
    public class ProstorijaService
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

        public bool AzurirajProstoriju(Prostorija prostorija, int indeks)
        {
            ProstorijaRepozitorijum datoteka = new ProstorijaRepozitorijum();
            List<Prostorija> prostorije = datoteka.dobaviSve();
            foreach (Prostorija pr in prostorije)
            {
                if (pr.Id.Equals(prostorija.Id))
                {
                    prostorije.Remove(pr);
                    prostorije.Insert(indeks, prostorija);
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

        public List<Prostorija> PregledSvihProstorija2Model(List<ProstorijaDTO> dtos)
        {
            List<Prostorija> modeli = new List<Prostorija>();
            foreach (ProstorijaDTO pdto in dtos)
            {
                modeli.Add(DTO2Model(pdto));
            }
            return modeli;
        }
    
        public List<ProstorijaDTO> PregledSvihProstorijaDTO(List<Prostorija> modeli)
        {
            if (modeli == null) 
             modeli = PregledSvihProstorija();
            List<ProstorijaDTO> dtos = new List<ProstorijaDTO>();
            foreach(Prostorija model in modeli)
            {
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        }

        public Prostorija DTO2Model(ProstorijaDTO dto)
        {
            if(dto != null)
                foreach(Prostorija p in PregledSvihProstorija())
                {
                    if (dto.Id.Equals(p.Id))
                        return p;
                }
            return null;
        }
        public ProstorijaDTO Model2DTO(Prostorija model)
        {
            ProstorijaDTO dto = new ProstorijaDTO(model.Id, model.Naziv, model.Tip, model.Slobodna, model.Sprat);
            return dto;
        }

    }
}
