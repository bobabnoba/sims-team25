using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class ProstorijaController
    {
        ProstorijaService prostorijaService = new ProstorijaService();
        public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            return prostorijaService.PregledSvihProstorija();    
        }

        public ObservableCollection<ProstorijaDTO> PregledSvihProstorijaDTO()
        {
            return prostorijaService.PregledSvihProstorijaDTO();
        }


        public void AzurirajProstoriju(ProstorijaDTO p, int indeks)
        {
            prostorijaService.AzurirajProstoriju(p, indeks);
        }
    }
}
