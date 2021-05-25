﻿using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class ZahtevPremestanjaController
    {
        ZahtevPremestanjaService zahteviPremestanjaService = new ZahtevPremestanjaService();
       public ObservableCollection<ZahtevPremestanjaDTO> PregledSveOpremeDTO()
        {
            return zahteviPremestanjaService.PregledSveOpremeDTO();
        }

        public bool ObrisiZahtevPremestanja(ZahtevPremestanjaDTO zahtevPremestanjaDTO)
        {
            return zahteviPremestanjaService.ObrisiZahtevPremestanja(zahtevPremestanjaDTO);
        }

        public bool ZakaziPremestanje(InventarDTO selectedItem1, ZahtevPremestanjaDTO zahtevPremestanjaDTO, DateTime selectedDate, string selectedItem2, string text)
        {
            return zahteviPremestanjaService.ZakaziPremestanje(selectedItem1,zahtevPremestanjaDTO,selectedDate,selectedItem2,text);
        }
    }
}
