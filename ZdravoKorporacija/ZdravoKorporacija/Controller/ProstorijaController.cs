using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Controller
{
    class ProstorijaController
    {
        ProstorijaService prostorijaService = new ProstorijaService();
        public ObservableCollection<Prostorija> PregledSvihProstorija()
        {
            return prostorijaService.PregledSvihProstorija();    
        }

       public void AzurirajProstoriju(Prostorija p, int indeks)
        {
            prostorijaService.AzurirajProstoriju(p, indeks);
        }
    }
}
