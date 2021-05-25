using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class TerminController
    {
        private TerminService servis;
        private PacijentService pacijentService; 
        private PacijentController pacijentKontroler;
        private TerminKonverter terminKonverter;
        private PacijentKonverter pacijentKonverter;

        public TerminController()
        {
            this.pacijentKonverter = new PacijentKonverter();
            this.terminKonverter = new TerminKonverter();
            this.servis = new TerminService();
            this.pacijentService = new PacijentService();
            this.pacijentKontroler = new PacijentController();
        }
        
        public IEnumerable<TerminDTO> dobaviListuDTOtermina(PacijentDTO pacijentDTO)
            => servis.PregledSvihTerminaPacijenta(pacijentKontroler.konvertujDTOuEntitet(pacijentDTO)).Select(entitet 
                                                                            => terminKonverter.KonvertujEntitetUDTO(entitet)).ToList();
        public IEnumerable<TerminDTO> dobaviListuDTOProslihtermina(PacijentDTO pacijentDTO)
            => servis.PregledIstorijeTerminaPacijenta(pacijentKontroler.konvertujDTOuEntitet(pacijentDTO)).Select(entitet 
                                                                            => terminKonverter.KonvertujEntitetUDTO(entitet)).ToList();

        public Boolean zakaziPregled(TerminDTO terminDTO, PacijentDTO pacijentDTO)
        {
            Termin t = terminKonverter.KonvertujDTOuEntitet(terminDTO);
            Pacijent p = pacijentService.pronadjiEntitetZaDTO(pacijentDTO);

            return servis.zakaziPregled(t, p);
        }

        public void otkaziPregled(TerminDTO terminDTO, PacijentDTO pacijentDTO)
        {
            Termin t = terminKonverter.KonvertujDTOuEntitet(terminDTO);
            Pacijent p = pacijentService.pronadjiEntitetZaDTO(pacijentDTO);

            servis.OtkaziTerminPacijent(t, p);
        }

        public bool pomeriPregled(TerminDTO noviTermindDTO, PacijentDTO pacijentDTO)
        {
            Termin t = terminKonverter.KonvertujDTOuEntitet(noviTermindDTO);
            Pacijent p = pacijentService.pronadjiEntitetZaDTO(pacijentDTO);
            return servis.AzurirajTerminPacijent(t, p);
        }

        //public TerminDTO konvertujEntitetUDTO(Termin entitet)
        //{
        //    return new TerminDTO(entitet);
        //}

        //public Termin konvertujDTOuEntitet(TerminDTO tDTO)
        //{
        //    return new Termin(tDTO.Id, new Lekar(tDTO.Lekar), tDTO.Tip, tDTO.Pocetak, tDTO.Trajanje);
        //}

    }


}

