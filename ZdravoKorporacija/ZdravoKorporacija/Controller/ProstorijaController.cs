using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Controller
{
    public class ProstorijaController
    {
        ProstorijaService prostorijaService = new ProstorijaService();

        public bool DodajProstoriju(ProstorijaDTO prostorijaDTO)
        {
            return prostorijaService.DodajProstoriju(prostorijaDTO);
        }

        public bool AzurirajProstoriju(ProstorijaDTO novaProstorijaDTO, int indeks)
        {
            return prostorijaService.AzurirajProstoriju(novaProstorijaDTO,indeks);
        }

            public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            return prostorijaService.PregledSvihProstorija();    
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO()
        {
            return prostorijaService.PregledSvihProstorijaDTO();
        }

       public bool ObrisiProstoriju(ProstorijaDTO prostorijaZaBrisanje)
        {
            return prostorijaService.ObrisiProstoriju(prostorijaZaBrisanje);
        }
    }
}
