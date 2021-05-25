using Microsoft.VisualBasic.CompilerServices;
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Model
{

    public class TerminService
    {

        private LekarService lekarServis = new LekarService();
        private ProstorijaService prostorijaServis = new ProstorijaService();
        private RadniDanService daniServis = new RadniDanService();
        public Termin FindOpByPocetak(DateTime poc)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            foreach(Termin t in termini)
            {
                if (t.Pocetak == poc && t.Tip == TipTerminaEnum.Operacija)
                    return t;
            }

            return null;
        }
        public List<Termin> FindPrByPocetak(DateTime poc)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            List<Termin> povratna = new List<Termin>();
            foreach (Termin t in termini)
            {
                if (t.Pocetak == poc && t.Tip == TipTerminaEnum.Pregled)
                    povratna.Add(t);
            }

            return povratna;
        }
        
        public void DodajTermin(TerminDTO dto)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            termini.Add(DTO2Model(dto));
            
        }
        public bool ZakaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            
            termini.Add(termin);
            datoteka.sacuvaj(termini);
            datotekaID.sacuvaj(ids);

            return true;
        }

        public bool AzurirajTermin(Termin termin)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(termin);
                    datoteka.sacuvaj(termini);
                    return true;
                }
            }
            return false;
        }
        

        public bool OtkaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    datoteka.sacuvaj(termini);
                    datotekaID.sacuvaj(ids);

                    return true;
                }
            }
            return false;
        }

        public Termin PregledTermina(int id)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(id))
                {
                    return t;
                }
            }
            return null;
        }
        public List<Termin> PregledSvihTermina()
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            return termini;
        }

        public List<Termin> PregledSvihTermina2Model(List<TerminDTO> dtos)
        {
            List<Termin> modeli = new List<Termin>();
            foreach(TerminDTO tdto in dtos)
            {
                modeli.Add(DTO2Model(tdto));
            }
            return modeli;
        }
        public List<TerminDTO> PregledSvihTermina2DTO(List<Termin> modeli)
        {
            List<TerminDTO> dtos = new List<TerminDTO>();
            if (modeli == null)
                modeli = PregledSvihTermina();
            foreach(Termin model in modeli)
            {
                if(model != null)
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        }


        public Termin InicijalizujTermin(int id, TipTerminaEnum tip,  DateTime pocetak, Pacijent pacijent, Lekar lekar, Prostorija prostorija)
        {
            Termin noviTermin = new Termin();
            noviTermin.Id = id;
            noviTermin.Tip = tip;
            noviTermin.Pocetak = pocetak;
            noviTermin.Lekar = lekar;
            noviTermin.zdravstveniKarton = pacijent.ZdravstveniKarton;
            noviTermin.prostorija = prostorija;
            noviTermin.hitno = false;

            return noviTermin;
        }

        public int MapaTermina(Dictionary<int, int> ids)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }
            return id;
        }
        
       

        public List<Lekar> ProveriDaLiJeNaOdmoru( DateTime pocetakTermina)
        {
            List<Lekar> slobodniLekari = lekarServis.PregledSvihLekara();
            foreach (RadniDan rd in daniServis.PregledSvihRadnihDana())
            {
                if (rd.dan.Date.Equals(pocetakTermina.Date) && rd.odmor == true)
                {
                    slobodniLekari.Remove(lekarServis.NadjiLekaraPoJMBG((long)rd.lekar));
                }
            }
            return slobodniLekari;
        }


        public List<Prostorija> DobaviSlobodneProstorije( Termin termin)
        {
            List<Prostorija> slobodneProstorije = prostorijaServis.PregledSvihProstorija();

            foreach (Termin t in PregledSvihTermina().ToArray())
            {
                if (t.Pocetak.Equals(termin.Pocetak))
                {
                    foreach (Prostorija p in prostorijaServis.PregledSvihProstorija().ToArray())
                    {
                        if (t.prostorija.Id.Equals(p.Id))
                        {
                            slobodneProstorije.Remove(p);
                        }
                    }
                }
            }
            return slobodneProstorije;
        }
     

        public void InicijalizujTerminLekaru(Termin t)
        {
            Termin terminZaLekara = new Termin();
            terminZaLekara.Id = t.Id;
            t.Lekar.AddTermin(terminZaLekara);
        }

        public ZdravstveniKarton ProveriKartonKodZakazivanja(Pacijent pacijent)
        {
            ZdravstveniKarton kartonTermina = new ZdravstveniKarton();

            if (pacijent.ZdravstveniKarton != null)
                kartonTermina = pacijent.ZdravstveniKarton;
            else
            {
                kartonTermina = new ZdravstveniKarton(null, pacijent.GetJmbg(), StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);
                pacijent.ZdravstveniKarton = kartonTermina;
            }

            return kartonTermina;
        }


        public bool ZakaziTerminPacijent(Termin termin, Dictionary<int, int> ids, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    return false;
                }
            }
            termini.Add(termin);
            datoteka.sacuvaj(termini);
            datotekaID.sacuvaj(ids);
            Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
            b.zakazanCnt++;
            BanRepozitorijum.Instance.sacuvaj(b);

            return true;
        }

        public bool AzurirajTerminPacijent(Termin termin, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(termin);
                    datoteka.sacuvaj(termini);
                    Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
                    b.pomerenCnt++;
                    BanRepozitorijum.Instance.sacuvaj(b);
                    return true;
                }
            }
            return false;
        }

        public bool OtkaziTerminPacijent(Termin termin, Dictionary<int, int> ids, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            foreach (Termin t in termini) 
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    datoteka.sacuvaj(termini);
                    datotekaID.sacuvaj(ids);
                    Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
                    b.otkazanCnt++;
                    BanRepozitorijum.Instance.sacuvaj(b);

                    return true;
                }
            }
            return false;
        }
        
        public Termin DTO2Model(TerminDTO dto)
        {
            Termin model = new Termin(dto.Id,  lekarServis.DTO2Model( dto.Lekar ), dto.Tip, dto.Pocetak, dto.Trajanje);
            model.prostorija = prostorijaServis.DTO2Model(dto.prostorija);
            model.zdravstveniKarton = dto.zdravstveniKarton;
            model.hitno = dto.hitno;
            
            return model;
        }
        public Termin DTO2ModelNadji(TerminDTO dto)
        {
            foreach(Termin t in PregledSvihTermina())
            {
                if (dto.Id.Equals(t.Id))
                    return t;
            }
            return null;
        }
        public void DodajTermin(Termin t)
        {
            TerminRepozitorijum tr = new TerminRepozitorijum();
            List<Termin> termini = tr.dobaviSve();
            termini.Add(t);
        }
        public TerminDTO Model2DTO(Termin model)
        {
            TerminDTO dto = new TerminDTO(model.zdravstveniKarton, prostorijaServis.Model2DTO( model.prostorija), lekarServis.Model2DTO(model.Lekar), model.Tip, model.Pocetak, 0.5, model.izvestaj);
            dto.Id = model.Id;
            return dto;
        }
        public List<Termin> NadjiAlternativnePreglede()
        {
            List<Termin> alternative = new List<Termin>();
            foreach(Termin t in PregledSvihTermina())
            {
                if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Pregled && t.hitno == false)
                {
                    alternative.Add(t);
                }
            }
            return alternative;
        }
        public List<Termin> NadjiAlternativneOperacije()
        {
            List<Termin> alternative = new List<Termin>();
            foreach (Termin t in PregledSvihTermina())
            {
                if ((t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(60)) || t.Pocetak == RoundUp(DateTime.Now, TimeSpan.FromMinutes(90))) && t.Tip == TipTerminaEnum.Operacija && t.hitno == false)
                {
                    alternative.Add(t);
                }
            }
            return alternative;
        }
        public List<Lekar> DobaviSlobodneLekareHITNO(SpecijalizacijaEnum specijalizacija)
        {
            List<Lekar> slobodniLekari = new List<Lekar>();
            List<Lekar> lekari = lekarServis.PregledSvihLekara();
            slobodniLekari = lekari;

            foreach (Termin t in PregledSvihTermina())
            {
               string  dateString = DateTime.Now.ToString();
                if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                {
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Jmbg.Equals(t.Lekar.Jmbg))
                        {
                            slobodniLekari.Remove(l);

                        }
                        
                    }
                } else 
                    foreach(Lekar l in lekari.ToArray())
                    {
                         if (l.Specijalizacija != specijalizacija)
                        {

                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).odmor == true)
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == true && dateString.Contains('P'))
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == false && dateString.Contains('A'))
                        {
                            slobodniLekari.Remove(l);
                        }
                    }

            }         
            return slobodniLekari;
        }
        public List<Lekar> DobaviSlobodneLekare(DateTime pocetakTermina, SpecijalizacijaEnum specijalizacija)
        {
            List<Lekar> slobodniLekari = new List<Lekar>();
            List<Lekar> lekari = lekarServis.PregledSvihLekara();
            slobodniLekari = lekari;
            string dateString = pocetakTermina.ToString();
            foreach (Termin t in PregledSvihTermina())
            {
                if (t.Pocetak.Equals(pocetakTermina))
                {
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Jmbg.Equals(t.Lekar.Jmbg))
                        {
                            slobodniLekari.Remove(l);

                        }

                    }
                }
                else
                    foreach (Lekar l in lekari.ToArray())
                    {
                        if (l.Specijalizacija != specijalizacija)
                        {

                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).odmor == true)
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == true && dateString.Contains('P'))
                        {
                            slobodniLekari.Remove(l);
                        }
                        else if (daniServis.NadjiDanZaLekara(DateTime.Now, (double)l.Jmbg).prvaSmena == false && dateString.Contains('A'))
                        {
                            slobodniLekari.Remove(l);
                        }
                    }

            }
            return slobodniLekari;
        }
        public List<Prostorija> DobaviSlobodneProstorijeHITNO()
        {
            List<Prostorija> slobodneProstorije = new List<Prostorija>();
            List<Prostorija> prostorije = prostorijaServis.PregledSvihProstorija();
            slobodneProstorije = prostorije;

            foreach (Termin t in PregledSvihTermina())
            {
                if (t.Pocetak.Equals(RoundUp(DateTime.Now, TimeSpan.FromMinutes(30))))
                {
                    foreach (Prostorija p in prostorije.ToArray())
                    {
                        if (t.prostorija.Id.Equals(p.Id))
                        {
                            slobodneProstorije.Remove(p);
                        }
                    }
                }
            }
            return slobodneProstorije;
        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
    }
    

    }


