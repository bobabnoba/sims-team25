﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ZdravoKorporacija.Model
{
    class TerminService
    {

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
