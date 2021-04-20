using Model;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class TerminService
    {

        public List<Lekar> slobodniLekari(DateTime pocetak, ObservableCollection<Termin> termini)
        {


            TerminRepozitorijum terminDat = new TerminRepozitorijum();
            LekarRepozitorijum lekarDat = new LekarRepozitorijum();


            List<Lekar> lekari = lekarDat.dobaviSve();

            List<Lekar> slobodniLekari = new List<Lekar>();
            slobodniLekari = lekari;


            foreach (Termin t in termini)
            {
                if (t.Pocetak.Equals(pocetak))
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

        public List<Prostorija> slobodneProstorije(DateTime pocetak)
        {
            TerminRepozitorijum terminDat = new TerminRepozitorijum();
            ProstorijaRepozitorijum prostorijaDat = new ProstorijaRepozitorijum();

            List<Prostorija> prostorije = prostorijaDat.dobaviSve();
            List<Prostorija> slobodneProstorije = new List<Prostorija>();
            slobodneProstorije = prostorije;

            foreach (Prostorija p in prostorije)
            {
                if (!p.Slobodna)
                    slobodneProstorije.Remove(p);
            }
            return slobodneProstorije;
        }


        public bool ZakaziTermin(Termin termin, Dictionary<int, int> ids)
        {
            TerminRepozitorijum datoteka = new TerminRepozitorijum();
            List<Termin> termini = datoteka.dobaviSve();
           // IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    return false;
                }
            }
            termini.Add(termin);
            datoteka.sacuvaj(termini);
           // datotekaID.sacuvaj(ids);

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
           //IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");

            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    datoteka.sacuvaj(termini);
                    //datotekaID.sacuvaj(ids);

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
    }
}
