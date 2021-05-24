using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class MagacinController
    {
        MagacinService magacinService = new MagacinService();
        public ObservableCollection<InventarDTO> PregledSveOpremeDTO()
        {
            return magacinService.PregledSveOpremeDTO();
        }
    }
}
