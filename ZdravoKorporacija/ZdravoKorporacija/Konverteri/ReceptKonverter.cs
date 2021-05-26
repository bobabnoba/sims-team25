﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Konverteri
{
    public class ReceptKonverter : IKonverter<Recept, ReceptDTO>
    {
        public ReceptKonverter()
        {

        //lekarKonverter = new LekarKonverter();
        //zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();
    }

        public List<Recept> KonvertujDTOSuEntitete(IEnumerable<ReceptDTO> dtos)
        {
            if (dtos != null) return dtos.Select(dto => KonvertujDTOuEntitet(dto)).ToList();
            else return null;
        }

        public Recept KonvertujDTOuEntitet(ReceptDTO dto)
        {
            LekarKonverter lekarKonverter = new LekarKonverter();
            ZdravstveniKartonKonverter zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();
            return new Recept(lekarKonverter.KonvertujDTOuEntitet(dto.Lekar), zdravstveniKartonKonverter.KonvertujDTOuEntitet(dto.ZdravstveniKarton), dto.Id, dto.Doziranje, dto.Trajanje, dto.NazivLeka, dto.Pocetak);
            
        }

        public IEnumerable<ReceptDTO> KonvertujEntiteteUDTOS(IEnumerable<Recept> entiteti)
            => entiteti.Select(entitet => KonvertujEntitetUDTO(entitet)).ToList();

        public IEnumerable<ReceptDTO> KonvertujEntiteteUDTOS(List<Recept> entiteti)
        {
            throw new NotImplementedException();
        }

        public ReceptDTO KonvertujEntitetUDTO(Recept entitet)
        {
            LekarKonverter lekarKonverter = new LekarKonverter();
            ZdravstveniKartonKonverter zdravstveniKartonKonverter = new ZdravstveniKartonKonverter();
            return new ReceptDTO(entitet.Id, entitet.Doziranje, entitet.Trajanje, entitet.NazivLeka, entitet.Pocetak, lekarKonverter.KonvertujEntitetUDTO(entitet.lekar), zdravstveniKartonKonverter.KonvertujEntitetUDTO(entitet.zdravstveniKarton));

        }
    }
}