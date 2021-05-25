using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.Model;
using Repository;
using ZdravoKorporacija.DTO;
using System.Diagnostics;

namespace Service
{
    class PacijentService
    {

        private static PacijentService _instance;

        public static PacijentService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PacijentService();
                }
                return _instance;
            }
        }

        PacijentRepozitorijum pr = PacijentRepozitorijum.Instance;
        ReceptRepozitorijum rr = ReceptRepozitorijum.Instance;
        ReceptServis rs = ReceptServis.Instance;
        IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRecept");
 

        public bool IzdajRecept(PacijentDTO pacijent, ReceptDTO recept, Dictionary<int, int> ids)
        { 
            rs.DodajRecept(recept,ids);
            Pacijent p = new Pacijent(pacijent);
            datotekaID.sacuvaj(ids);
            p.ZdravstveniKarton.recept.Add(new Recept(recept));
            AzurirajPacijenta(p);
            return true;
        }

        public bool ObrisiRecept(PacijentDTO pacijent, ReceptDTO recept, Dictionary<int, int> ids)
        {
            Pacijent p = new Pacijent(pacijent);
            foreach(Recept rec in p.ZdravstveniKarton.recept.ToArray())
            {
            if (recept.Id.Equals(rec.Id))
                p.ZdravstveniKarton.recept.Remove(rec);
            }
            AzurirajPacijenta(p);
            rs.ObrisiRecept(recept,ids);
            datotekaID.sacuvaj(ids);
            return true;
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

        public bool AzurirajPacijenta(PacijentDTO pacijent)
        {
            List<Pacijent> pacijenti = pr.dobaviSve2();
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    pacijenti.Remove(p);
                    pacijenti.Add(new Pacijent(pacijent));
                    pr.sacuvaj(pacijenti);
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

        public List<PacijentDTO> PregledSvihPacijenata2()
        {
            List<Pacijent> pacijenti = pr.dobaviSve2();
            List < PacijentDTO > pacijentiDTO = new List<PacijentDTO>();
            foreach (Pacijent pacijent in pacijenti)
            {
                pacijentiDTO.Add(convertToDTO(pacijent));
            }
            return pacijentiDTO;
        }

        public List<Pacijent> PregledSvihPacijenata()
        {
            return pr.dobaviSve2();
        }

        public PacijentDTO convertToDTO(Pacijent pacijent)
        {
            return new PacijentDTO(pacijent);
        }

    }
}
