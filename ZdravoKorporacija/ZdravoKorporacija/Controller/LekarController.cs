using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Pkcs;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class LekarController
    {
        private LekarService servis;
        private LekarKonverter lekarKonverter;

        public LekarController()
        {
            this.lekarKonverter = new LekarKonverter();
            this.servis = new LekarService();
        }


        public IEnumerable<LekarDTO> dobaviListuDTOLekara()
            => servis.PregledSvihLekara().Select(entitet => lekarKonverter.KonvertujEntitetUDTO(entitet)).ToList();

        //public LekarDTO konvertujEntitetUDTO(Lekar entitet)
        //{
        //    return new LekarDTO(entitet);
        //}
    }


}

