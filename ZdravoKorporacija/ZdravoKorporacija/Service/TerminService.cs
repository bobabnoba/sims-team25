using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Model
{
    class TerminService
    {
        TerminRepozitorijum tr = TerminRepozitorijum.Instance;
        IzvestajService iz = IzvestajService.Instance;
        PacijentService pacijentServis = PacijentService.Instance;
        ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        LekarRepozitorijum lekariDat = LekarRepozitorijum.Instance;
        List<Lekar> lekari = LekarRepozitorijum.Instance.dobaviSve();
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapIzvestaj");
        Dictionary<int, int> id_map = new Dictionary<int, int>();

        IDRepozitorijum uputDat = new IDRepozitorijum("iDMapTermin");
        Dictionary<int, int> id_uput = new Dictionary<int, int>();


        private static TerminService _instance;

        public static TerminService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TerminService();
                }
                return _instance;
            }
        }


        public bool izdajUput(PacijentDTO pac, TerminDTO termin)
        {
            id_uput = uputDat.dobaviSve();
            
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_uput[i] == 0)
                {
                    id = i;
                    id_uput[i] = 1;
                    break;
                }
            }
            termin.Id = id;
            if (ZakaziTermin(termin, id_uput))
            {
                lekariDat.sacuvaj(lekari);
            }
            pac.AddTermin(termin);
            pacijentServis.AzurirajPacijenta(pac);
          
            return true;
        }

        public bool IzdajAnamnezu(IzvestajDTO izvestaj,TerminDTO termin)
        {
            List < PacijentDTO > pacijenti = new List<PacijentDTO>(pacijentServis.PregledSvihPacijenata2());
            id_map = datotekaID.dobaviSve();

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    break;
                }
            }
            izvestaj.Id = id;
            foreach (PacijentDTO p in pacijenti)
            {
                if (termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                {
                    foreach (TerminDTO t in p.termin)
                    {
                        if (t.Id.Equals(termin.Id))
                        {

                            t.izvestaj = izvestaj;
                        }
                    }
                    pacijentServis.AzurirajPacijenta(p);
                    break;
                }
                    
            }
            iz.DodajIzvestaj(izvestaj,id_map);
            termin.izvestaj = izvestaj;
            AzurirajTermin(termin);
            return true;
        }

        public bool ObrisiAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            List<PacijentDTO> pacijenti = new List<PacijentDTO>(pacijentServis.PregledSvihPacijenata2());
            PacijentDTO pac = new PacijentDTO();
            foreach (PacijentDTO p in pacijenti)
            {
                if (termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                {
                    foreach (TerminDTO t in p.termin)
                    {
                        if (t.Id.Equals(termin.Id))
                        {
                            t.izvestaj = null;
                            id_map = datotekaID.dobaviSve();
                            id_map[izvestaj.Id] = 0;
                            datotekaID.sacuvaj(id_map);
                            break;
                        }
                    }
                }
            }
            
            termin.izvestaj = null;
            AzurirajTermin(termin);
            pacijentServis.AzurirajPacijenta(pac);
            iz.ObrisiIzvestaj(izvestaj,id_map);
            return true;
        }
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

        public bool ZakaziTermin(TerminDTO termin, Dictionary<int, int> ids)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            termini.Add(new Termin(termin));
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

        public bool AzurirajTermin(TerminDTO termin)
        {
            List<Termin> termini = tr.dobaviSve();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(new Termin(termin));
                    tr.sacuvaj(termini);
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

        public List<TerminDTO> PregledSvihTermina2()
        {
            List<Termin> termini = tr.dobaviSve();
            List<TerminDTO> terminiDTO = new List<TerminDTO>();
            foreach (Termin termin in termini)
            {
                terminiDTO.Add(convertToDTO(termin));
            }
            return terminiDTO;
        }

        public TerminDTO convertToDTO(Termin pacijent)
        {
            return new TerminDTO(pacijent);
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
        
        public List<Lekar> DobaviSlobodneLekare(List<Lekar> lekari, ObservableCollection<Termin> pregledi, DateTime pocetakTermina)
        {
            List<Lekar> slobodniLekari = lekari;

            foreach (Termin t in pregledi)
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
            }
            return slobodniLekari;
        }

        public List<Prostorija> DobaviSlobodneProstorije(List<Prostorija> prostorije, ObservableCollection<Termin> pregledi, Termin termin)
        {
            List<Prostorija> slobodneProstorije = prostorije;

            foreach (Termin t in pregledi)
            {
                if (t.Pocetak.Equals(termin.Pocetak))
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
        }

    }


