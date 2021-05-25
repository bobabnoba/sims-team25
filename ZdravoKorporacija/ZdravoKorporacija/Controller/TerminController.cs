using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model;
using Service;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class TerminController
    {
        private TerminService terminServis = new TerminService();
        private ProstorijaService prostorijaServis = new ProstorijaService();
        private LekarService lekarServis = new LekarService();
        private PacijentService pacijentServis = new PacijentService();
        private ZdravstveniKartonServis kartonServis = new ZdravstveniKartonServis();

        public ZdravstveniKarton NadjiKartonID(long id)
        {
            return kartonServis.findById(id);
        }
        public Pacijent NadjiPacijentaPoJMBG(long jmbg)
        {
            return pacijentServis.NadjiPacijentaPoJMBG(jmbg);
        }
        public bool AzurirajPacijenta(Pacijent pacijent)
        {
            return pacijentServis.AzurirajPacijenta(pacijent);
        }

        public List<Lekar> PregledSvihLekara()
        {
            return lekarServis.PregledSvihLekara();
        }
        public List<Lekar> PregledSvihLekaraModel(List<LekarDTO> dtos)
        {
            return lekarServis.PregledSvihLekaraModel(dtos);
        }
        public List<LekarDTO> PregledSvihLekaraDTO(List<Lekar> modeli)
        {
            return lekarServis.PregledSvihLekaraDTO(modeli);
        }
        public ProstorijaDTO Model2DTO(Prostorija model)
        {
            return prostorijaServis.Model2DTO(model);
        }
        public LekarDTO Model2DTO(Lekar model)
        {
            return lekarServis.Model2DTO(model);
        }
        public TerminDTO Model2DTO(Termin model)
        {
            return terminServis.Model2DTO(model);
        }
        public bool AzurirajTerminPacijent(Termin termin, Pacijent pacijent)
        {
            return terminServis.AzurirajTerminPacijent(termin, pacijent);
        }

        internal bool AzurirajLekara(Lekar lekar)
        {
            return lekarServis.AzurirajLekara( lekar);
        }

        public bool ObrisiNalogPacijentu(Pacijent pacijent)
        {
            return pacijentServis.ObrisiNalogPacijentu(pacijent);
        }
        public Lekar LekarDTO2Model(LekarDTO dto)
        {
            return lekarServis.DTO2Model(dto);
        }

        public List<ProstorijaDTO> PregledSvihProstorijaDTO(List<Prostorija> modeli)
        {
            return prostorijaServis.PregledSvihProstorijaDTO(modeli);
        }
        public List<Prostorija> PregledSvihProstorija()
        {
            return prostorijaServis.PregledSvihProstorija();
        }
        public List<Prostorija> PregledSvihProstorija2Model(List<ProstorijaDTO> dtos)
        {
            return prostorijaServis.PregledSvihProstorija2Model(dtos);
        }
        public List<Prostorija> DobaviSlobodneProstorije(List<Prostorija> prostorije, ObservableCollection<Termin> pregledi, Termin termin)
        {
           return terminServis.DobaviSlobodneProstorije(prostorije, pregledi, termin);
        }
        public List<Lekar> DobaviSlobodneLekare(List<Lekar> lekari, ObservableCollection<Termin> pregledi, DateTime pocetakTermina)
        {
            return terminServis.DobaviSlobodneLekare(lekari, pregledi, pocetakTermina);
        }
        public int MapaTermina(Dictionary<int, int> ids)
        {
            return terminServis.MapaTermina(ids);
        }
        public bool ZakaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            return terminServis.ZakaziTermin(termin, ids);
        }
        public Termin TerminDTO2Model(TerminDTO dto)
        {
            return terminServis.DTO2Model(dto);
        }
        public void AzurirajLekare()
        {
            lekarServis.AzurirajLekare();
        }
        public List<TerminDTO> PregledSvihTermina2DTO(List<Termin> modeli)
        {
            return terminServis.PregledSvihTermina2DTO(modeli);
        }
        public List<Termin> PregledSvihTermina2Model(List<TerminDTO> dtos)
        {
            return terminServis.PregledSvihTermina2Model(dtos);
        }
        public List<PacijentDTO> PregledSvihPacijenata2DTO()
        {
            return pacijentServis.PregledSvihPacijenata2DTO();
        }
        public List<Pacijent> PregledSvihPacijenata2Model(List<PacijentDTO> dtos)
        {
            return pacijentServis.PregledSvihPacijenata2Model(dtos);
        }
        public List<Pacijent> PregledSvihPacijenata()
        {
            return pacijentServis.PregledSvihPacijenata();
        }
        public Pacijent PacijentDTO2Model(PacijentDTO dto)
        {
            return pacijentServis.DTO2Model(dto);
        }
        public void DodajTermin(Pacijent p, Termin t)
        {
            pacijentServis.DodajTermin(p, t);
        }
        public Pacijent PregledPacijenta(long jmbg)
        {
            return pacijentServis.PregledPacijenta(jmbg);
        }
        public void DodajTermin(Termin t)
        {
            terminServis.DodajTermin(t);
        }
        public Pacijent DTO2ModelNapravi(PacijentDTO dto)
        {
            return pacijentServis.DTO2ModelNapravi(dto);
        }
        public List<Termin> PregledSvihTermina()
        {
            return terminServis.PregledSvihTermina();
        }
        public bool ZakaziTerminPacijent(Termin termin, Dictionary<int, int> ids, Pacijent pacijent)
        {
            return terminServis.ZakaziTerminPacijent(termin, ids, pacijent);
        }
        public List<Lekar> DobaviSlobodneLekareHITNO()
        {
            return terminServis.DobaviSlobodneLekareHITNO();
        }
        public List<Prostorija> DobaviSlobodneProstorijeHITNO()
        {
            return terminServis.DobaviSlobodneProstorijeHITNO();
        }
        public List<Termin> NadjiAlternativneOperacije()
        {
            return terminServis.NadjiAlternativneOperacije();
        }
        public List<Termin> NadjiAlternativnePreglede()
        {
            return terminServis.NadjiAlternativnePreglede();
        }
        public Lekar DTO2ModelNapravi(LekarDTO dto)
        {
            return lekarServis.DTO2ModelNapravi(dto);
        }
    }

}
