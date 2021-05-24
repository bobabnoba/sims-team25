using Service;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Controller
{
    class MagacinController
    {
        MagacinService magacinService = new MagacinService();
        public List<InventarDTO> PregledSveOpremeDTO()
        {
            return magacinService.PregledSveOpremeDTO();
        }
    }
}
