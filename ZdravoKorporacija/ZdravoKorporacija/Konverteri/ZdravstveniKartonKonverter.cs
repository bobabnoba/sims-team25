﻿using System.Collections.Generic;
using System.Linq;
using Model;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class ZdravstveniKartonKonverter : IKonverter<ZdravstveniKarton, ZdravstveniKartonDTO>
    {

        public List<ZdravstveniKarton> KonvertujDTOSuEntitete(IEnumerable<ZdravstveniKartonDTO> dtos)
            => dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();

        public ZdravstveniKarton KonvertujDTOuEntitet(ZdravstveniKartonDTO dto)
        {
            PacijentKonverter pacijentKonverter = new PacijentKonverter();
            ReceptKonverter receptKonverter = new ReceptKonverter();
            return new ZdravstveniKarton(receptKonverter.KonvertujDTOSuEntitete(dto.recept), pacijentKonverter.KonvertujDTOuEntitet(dto.pacijent), dto.Id);

        }

        public IEnumerable<ZdravstveniKartonDTO> KonvertujEntiteteUDTOS(List<ZdravstveniKarton> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public ZdravstveniKartonDTO KonvertujEntitetUDTO(ZdravstveniKarton entitet)
        {
            PacijentKonverter pacijentKonverter = new PacijentKonverter();
            ReceptKonverter receptKonverter = new ReceptKonverter();
            if (entitet != null)
            {
               return new ZdravstveniKartonDTO(receptKonverter.KonvertujEntiteteUDTOS(entitet.recept), entitet.istorijaBolesti, pacijentKonverter.KonvertujEntitetUDTO((entitet.patient)), entitet.Id);

            }
            else
            {
                return new ZdravstveniKartonDTO();
            }
        }
    }
}