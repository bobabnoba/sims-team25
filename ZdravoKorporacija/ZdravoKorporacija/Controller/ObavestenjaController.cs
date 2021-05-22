using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Controller
{
    class ObavestenjaController
    {
        private ObavestenjaService obavestenjaServis = new ObavestenjaService();

        public void generisiObavestenja()
        {
            obavestenjaServis.generisiObavestenja();
        }
        public List<Notifikacija> pregled()
        {
           return obavestenjaServis.pregled();
        }
        public bool dodajObavestenje(Notifikacija not)
        {
            return obavestenjaServis.dodajObavestenje(not);
        }
        public bool obrisiObavestenje(String not)
        {
            return obavestenjaServis.obrisiObavestenje(not);
        }
        public Notifikacija DTO2ModelNapravi(NotifikacijaDTO dto)
        {
            return obavestenjaServis.DTO2ModelNapravi(dto);
        }
        public NotifikacijaDTO model2DTO(Notifikacija model)
        {
            return obavestenjaServis.model2DTO(model);
        }
        public Notifikacija DTO2Model(NotifikacijaDTO dto)
        {
            return obavestenjaServis.DTO2Model(dto);
        }
        public List<Notifikacija> PregledSvihObavestenja()
        {
            return obavestenjaServis.PregledSvihObavestenja();
        }
        public List<Notifikacija> PregledSvihObavestenja2Model(List<NotifikacijaDTO> dtos)
        {
            return obavestenjaServis.PregledSvihObavestenja2Model(dtos);
        }
        public List<NotifikacijaDTO> PregledSvihObavestenja2DTO(List<Notifikacija> modeli)
        {
            return obavestenjaServis.PregledSvihObavestenja2DTO(modeli);
        }

    }
}
