﻿using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Service
{

    class ObavestenjaService
    {
        private TerminRepozitorijum datotekaTer = new TerminRepozitorijum();
        private List<Termin> termini;
        private PacijentRepozitorijum datotekaPac = new PacijentRepozitorijum();
        private List<Pacijent> pacijenti;
        private ObservableCollection<Notifikacija> not = new ObservableCollection<Notifikacija>();

        public List<Notifikacija> PregledSvihObavestenja()
        {
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> obavestenja = datoteka.dobaviSve();
            return obavestenja;
        }
        public List<Notifikacija> PregledSvihObavestenja2Model(List<NotifikacijaDTO> dtos)
        {
            List<Notifikacija> modeli = new List<Notifikacija>();
            foreach (NotifikacijaDTO ndto in dtos)
            {
                modeli.Add(DTO2Model(ndto));
            }
            return modeli;
        }
        public List<NotifikacijaDTO> PregledSvihObavestenja2DTO(List<Notifikacija> modeli)
        {
            List<NotifikacijaDTO> dtos = new List<NotifikacijaDTO>();
            foreach (Notifikacija model in modeli)
            {
                if (model != null)
                    dtos.Add(model2DTO(model));
            }
            return dtos;
        }

        public void generisiObavestenja()
        {

            termini = datotekaTer.dobaviSve();
            pacijenti = datotekaPac.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                not = p.GetNotifikacije();
                if (p.notifikacije != null)
                {
                    foreach (Notifikacija n in not.ToList())
                    {
                        if (n != null)
                            if (n.Tip == TipNotifikacije.Obavestenje)
                                p.notifikacije.Remove(n);
                    }
                }
                foreach (Termin t in termini)
                {
                    if (t != null)
                        if (p.Jmbg.Equals(t.zdravstveniKarton.Id))
                        {

                            Notifikacija obavestenje = new Notifikacija();
                            if (p.notifikacije == null)
                            {
                                p.notifikacije = new ObservableCollection<Notifikacija>();
                                obavestenje.Id = 1;
                            }
                            else
                                obavestenje.Id = (p.notifikacije.Count) + 1;

                            obavestenje.Datum = DateTime.Now;
                            obavestenje.Status = "Neprocitano";
                            obavestenje.Tip = TipNotifikacije.Obavestenje;
                            obavestenje.Sadrzaj = "Zakazan termin: " + t.Tip.ToString() + ", vreme: " + t.Pocetak.ToString();


                            p.notifikacije.Add(obavestenje);

                            datotekaPac.sacuvaj(pacijenti);
                        }
                }
            }
        }
        public bool dodajObavestenje(Notifikacija not)
        {
            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = pr.dobaviSve();
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();

            foreach (Notifikacija n in notifikacije)
            {
                if (n != null)
                    if (not.Id.Equals(n.Id))
                        return false;
            }
            notifikacije.Add(not);
            datoteka.sacuvaj(notifikacije);
            foreach (Pacijent p in pacijenti)
            {
                p.notifikacije.Add(not);
                pr.sacuvaj(pacijenti);
            }
            return true;

        }

        public bool azurirajObavestenje(Notifikacija not)
        {
            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = pr.dobaviSve();
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                foreach (Notifikacija n in notifikacije)
                {
                    if (n.Id.Equals(not.Id))
                    {
                        notifikacije.Remove(n);
                        p.notifikacije.Remove(n);
                        notifikacije.Add(not);
                        p.notifikacije.Add(not);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool obrisiObavestenje(String not)
        {
            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = pr.dobaviSve();
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();
            PacijentService pc = new PacijentService();
            foreach (Notifikacija n in notifikacije)
            {
                if (n != null)
                    if (not.Equals(n.Sadrzaj))
                    {
                        pc.ObrisiObavestenjePacijentu(not);
                        notifikacije.Remove(n);
                        datoteka.sacuvaj(notifikacije);

                        return true;
                    }
            }

            return false;
        }

        public List<Notifikacija> pregled()
        {
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();
            return notifikacije;
        }

        public Notifikacija DTO2ModelNapravi(NotifikacijaDTO dto)
        {
            Notifikacija model = new Notifikacija();
            model.Id = dto.Id;
            model.Datum = dto.Datum;
            model.Tip = dto.Tip;
            model.Sadrzaj = dto.Sadrzaj;
            model.Status = dto.Status;

            return model;
        }
        public NotifikacijaDTO model2DTO(Notifikacija model)
        {
            NotifikacijaDTO dto = new NotifikacijaDTO();
            dto.Id = model.Id;
            dto.Datum = model.Datum;
            dto.Tip = model.Tip;
            dto.Sadrzaj = model.Sadrzaj;
            dto.Status = model.Status;

            return dto;
        }
        public Notifikacija DTO2Model(NotifikacijaDTO dto)
        {
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> obavestenja = datoteka.dobaviSve();
            foreach (Notifikacija n in obavestenja)
            {
                if (n != null)
                    if (n.Sadrzaj.Equals(dto.Sadrzaj)) ;
                return n;
            }
            return null;
        }
    }
}




