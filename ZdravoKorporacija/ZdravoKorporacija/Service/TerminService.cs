using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Service;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Model
{
    class TerminService
    {
        public static int TA_ZAKAZIVANJE = 0;
        public static int TA_POMJERANJE = 1;
        public static int TA_OTKAZIVANJE = 2;


        private TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();
        private IDRepozitorijum idRepozitorijum = new IDRepozitorijum("iDMapTermin");


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

        public List<Termin> PregledSvihTerminaPacijenta(Pacijent p)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> sviTermini = datoteka.dobaviSve();
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (termin.zdravstveniKarton != null && termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id) && termin.Pocetak > DateTime.Parse(DateTime.Now.ToString()))
                {
                    termini.Add(termin);
                }
            }

            return termini;

        }

        public List<Termin> PregledIstorijeTerminaPacijenta(Pacijent p)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> sviTermini = datoteka.dobaviSve();
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in sviTermini)
            {
                if (termin.zdravstveniKarton != null && termin.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id) && termin.Pocetak < DateTime.Parse(DateTime.Now.ToString()))
                {
                    termini.Add(termin);
                }
            }

            return termini;

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
                    azurirajBanInfo(pacijent, TA_POMJERANJE);
                    return true;
                }
            }
            return false;
        }

        public bool OtkaziTerminPacijent(Termin termin, Pacijent pacijent)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            Dictionary<int, int> ids = datotekaID.dobaviSve();

            PacijentRepozitorijum pr = new PacijentRepozitorijum();
           // Pacijent p = (Pacijent) pr.dobaviSve()
           //     .FirstOrDefault(p => p.ZdravstveniKarton.Equals(termin.zdravstveniKarton)); // jedan param manje

            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    ids[termin.Id] = 0;
                    termini.Remove(t);
                    datoteka.sacuvaj(termini);
                    datotekaID.sacuvaj(ids);
                    azurirajBanInfo(pacijent, TA_OTKAZIVANJE);

                    return true;
                }
            }
            return false;
        }

        public Boolean zakaziPregled(Termin termin, Pacijent pacijent)
        {
            List<Termin> termini = terminRepozitorijum.dobaviSve();
            termin.Id = dodijeliID();
            termin.Tip = TipTerminaEnum.Pregled;
            termin.Trajanje = 30;
            termin.zdravstveniKarton = pacijent.ZdravstveniKarton;
            //termin.prostorija = end me :))

            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                    return false;
            }
            termini.Add(termin);
            terminRepozitorijum.sacuvaj(termini);
           

            // zakazivanje ZAKAZUJE, ovo odvojiti u posebnu metodu ban servisa (ako je zakazi uspjesno izvrseno!)
            azurirajBanInfo(pacijent, TA_ZAKAZIVANJE);

            return true;
        }

        private void azurirajBanInfo(Pacijent pacijent, int tipAktivnosti)
        {
            Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);
            switch (tipAktivnosti)
            {
                case 0:
                    b.zakazanCnt++;
                    break;
                case 1:
                    b.pomerenCnt++;
                    break;
                case 2:
                    b.otkazanCnt++;
                    break;
                default:
                    break;
            }
            BanRepozitorijum.Instance.sacuvaj(b);
        }


        private int dodijeliID()
        {
            Dictionary<int, int> ids = idRepozitorijum.dobaviSve();

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
            idRepozitorijum.sacuvaj(ids);
            return id;
        }

        public Termin pronadjiEntitetZaDTO(TerminDTO dto)
        {
            return terminRepozitorijum.dobaviSve()
                .FirstOrDefault(t => dto.Id.Equals(t.Id));
        }
    }

    }


