using Model;
using System.Collections.Generic;

namespace ZdravoKorporacija.DTO
{
    public class ZdravstveniKartonDTO
    {
        public ZdravstveniKartonDTO(){}
        public PacijentDTO pacijent { get; set; }
        public long Id { get; set; }

        public List<ReceptDTO> recept;
        private IEnumerable<ReceptDTO> jedegovna1;
        private List<IstorijaBolesti> istorijaBolesti;
        private PacijentDTO pacijentDTO;

        //public List<IstorijaBolesti> istorijaBolesti;

        public ZdravstveniKartonDTO(IEnumerable<ReceptDTO> recept, List<IstorijaBolesti> istorijaBolesti, PacijentDTO pacijent, long id)
        {
            this.recept = new List<ReceptDTO>(recept);
            //this.istorijaBolesti = istorijaBolesti;
            this.pacijent = pacijent;
            Id = id;
        }

    }
}
