using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.Model;
using Repository;

namespace Service
{
    class PacijentService
    {

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

        public Pacijent PregledPacijenta(string jmbg)
        {
            PacijentRepozitorijum datoteka = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = datoteka.dobaviSve();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(jmbg))
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


    }
}
