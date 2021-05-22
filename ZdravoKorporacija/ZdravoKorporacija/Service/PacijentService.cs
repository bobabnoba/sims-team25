using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.Model;
using Repository;
using ZdravoKorporacija.DTO;
using System;
using System.Windows.Navigation;

namespace Service
{
   public class PacijentService
    {
        private ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
        public Pacijent NadjiPacijentaPoJMBG(long jmbg)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach(Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(jmbg))
                {
                    return p;
                }
            }
            return null;
        }
        public bool KreirajNalogPacijentu(Pacijent pacijent)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent))
                {
                    return false;
                }
            }
            pacijenti.Add(pacijent);
            datoteka.sacuvaj(pacijenti);
            return true;
        }

        public bool ObrisiNalogPacijentu(Pacijent pacijent)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    datoteka.sacuvaj(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public bool ObrisiTerminPacijentu(Termin termin)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.ZdravstveniKarton.Id.Equals(termin.zdravstveniKarton.Id))
                {
                    foreach(Termin t in p.termin.ToArray())
                    {
                        if (t.Id.Equals(termin.Id))
                            p.termin.Remove(t);
                    }
                    datoteka.sacuvaj(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public bool ObrisiObavestenjePacijentu(string  not)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                foreach(Notifikacija n in p.notifikacije.ToList())
                {
                    if(n!=null)
                    if (n.Sadrzaj.Equals(not))
                    {
                        p.notifikacije.Remove(n);
                    }
                }
                datoteka.sacuvaj(pacijenti);
                
                
            }
            return true;
        }

        public bool AzurirajPacijenta(Pacijent pacijent)
        {
            System.Diagnostics.Debug.WriteLine("Azuriralo");
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            if(pacijent != null)
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    pacijenti.Add(pacijent);
                    datoteka.sacuvaj(pacijenti);
                    return true;
                }
            }
            return false;
        }

        public Pacijent PregledPacijenta(long jmbg)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Ime.Equals(jmbg))
                {
                    return p;
                }
            }
            return null;
        }

        public List<Pacijent> PregledSvihPacijenata()
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            return pacijenti;
        }
        public List<Pacijent> PregledSvihPacijenata2Model(List<PacijentDTO> dtos)
        {
            List<Pacijent> modeli = new List<Pacijent>();
            foreach (PacijentDTO pdto in dtos)
                modeli.Add(DTO2Model(pdto));
            return modeli;
        }
        public List<PacijentDTO> PregledSvihPacijenata2DTO(List<Pacijent> modeli)
        {
            modeli = PregledSvihPacijenata();
            List<PacijentDTO> dtos = new List<PacijentDTO>();
            foreach(Pacijent model in modeli)
            {
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        } 

        public PacijentDTO Model2DTO(Pacijent model)
        {
            ZdravstveniKartonServis zks = new ZdravstveniKartonServis();
            ZdravstveniKartonDTO kartonDTO = zks.Model2DTO(model.ZdravstveniKarton);
            PacijentDTO dto = new PacijentDTO(kartonDTO, model.Guest, model.Ime, model.Prezime, (int)model.Jmbg, model.BrojTelefona, model.Mejl, model.AdresaStanovanja, model.Pol, model.Username, model.Password, model.Uloga);
            return dto;
        }
     
        public Pacijent DTO2Model(PacijentDTO dto)
        {
            
                foreach(Pacijent p in PregledSvihPacijenata())
                {
                    if (p.Password.Equals(dto.Password))
                        return p;
                }
            return null;
        }
        public void DodajTermin(Pacijent p, Termin t)
        {
            ZdravstveniKarton zk;
            if (p.ZdravstveniKarton.Id != p.Jmbg)
            {
                zk = new ZdravstveniKarton(p, p.Jmbg, StanjePacijentaEnum.None, "", KrvnaGrupaEnum.None, "");
                p.ZdravstveniKarton = zk;
            }
            if (p.termin == null)
                p.termin = new List<Termin>();
            p.termin.Add(t);
        }
        public Pacijent DTO2ModelNapravi(PacijentDTO dto)
        {
            Pacijent model = new Pacijent(dto.Ime, dto.Prezime, dto.Jmbg, dto.BrojTelefona, dto.Mejl, dto.AdresaStanovanja, dto.Pol, dto.Username, dto.Password, dto.Uloga);
            model.ZdravstveniKarton = zks.findById(dto.Jmbg);
            return model;

        }

        public void AddTermin(PacijentDTO pacijentDTO, TerminDTO terminDTO)
        {
            TerminService ts = new TerminService();
            Termin noviTermin = ts.DTO2Model(terminDTO);
            if (terminDTO == null)
                return;
            foreach(Pacijent pacijent in PregledSvihPacijenata())
            {
                if(pacijent.Jmbg.Equals(pacijentDTO.Jmbg))
                if (pacijent.termin == null)
                {
                    pacijent.termin = new List<Termin>();
                    pacijent.termin.Add(noviTermin);
                }
                if (!pacijent.termin.Contains(noviTermin))
                    pacijent.termin.Add(noviTermin);
            }
        }
        

        }
    }

