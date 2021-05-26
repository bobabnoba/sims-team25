﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using Model;
using Service;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Controller
{
    public class BeleskaController
    {
        private BeleskaKonverter beleskaKonverter = new BeleskaKonverter();
        private BeleskaService beleskaServis = new BeleskaService();
        private ObavestenjaService obavestenjaServis = new ObavestenjaService();

        public void sacuvajBelesku(BeleskaDTO beleskaDto)
        {
            Beleska beleska = beleskaKonverter.KonvertujDTOuEntitet(beleskaDto);
            beleskaServis.sacuvajBelesku(beleska);
        }

        public List<BeleskaDTO> dobaviBeleskaDTOs()
        {
            return (List<BeleskaDTO>)beleskaKonverter.KonvertujEntiteteUDTOS(beleskaServis.dobaviSveBeleske());
        }

    }
}
