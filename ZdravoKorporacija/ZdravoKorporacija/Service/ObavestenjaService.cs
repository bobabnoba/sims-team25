using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model;
using ZdravoKorporacija.Model;
using System.Linq;
using ZdravoKorporacija.Repository;
using Service;
using Repository;
namespace ZdravoKorporacija.Service
{

    class ObavestenjaService
    {
        private TerminRepozitorijum datotekaTer = new TerminRepozitorijum();
        private List<Termin> termini;
        private PacijentRepozitorijum datotekaPac = new PacijentRepozitorijum();
        private List<Pacijent> pacijenti;
        private ObservableCollection<Notifikacija> not = new ObservableCollection<Notifikacija>();

        public void generisiObavestenja() // generise obavestenja o zakazanim terminima
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
                        if (n.Tip == TipNotifikacije.Obavestenje)
                            p.notifikacije.Remove(n);
                    }
                }
                foreach (Termin t in termini)
                {
                    if(t != null)
                    if (t.zdravstveniKarton != null)
                        if (p.Jmbg == t.zdravstveniKarton.Id)
                        {

                            Notifikacija obavestenje = new Notifikacija();
                            if (p.notifikacije is null)
                            {
                                obavestenje.Id = 1;
                            }
                            else

                                obavestenje.Id = (p.notifikacije.Count) + 1;
                            obavestenje.Datum = DateTime.Now;
                            obavestenje.Status = "Neprocitano";
                            obavestenje.Tip = TipNotifikacije.Obavestenje;
                            obavestenje.Sadrzaj = "Zakazan termin: " + t.Tip.ToString() + ", vreme: " + t.Pocetak.ToString();

                            if (p.notifikacije != null)
                            {
                                p.notifikacije.Add(obavestenje);
                            }
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
                if (not.Id.Equals(n.Id))
                    return false;
            }
            notifikacije.Add(not);
            datoteka.sacuvaj(notifikacije);
            foreach(Pacijent p in pacijenti)
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
            foreach (Pacijent p in pacijenti) { 
                foreach (Notifikacija n in notifikacije)
                {
                    if (n.Id.Equals(not.Id)) {
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
        
        public bool obrisiObavestenje(String  not)
        {
            PacijentRepozitorijum pr = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = pr.dobaviSve();
            ObavestenjaRep datoteka = new ObavestenjaRep();
            List<Notifikacija> notifikacije = datoteka.dobaviSve();
            PacijentService pc = new PacijentService();
                foreach (Notifikacija n in notifikacije)
                {
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

    }
}

  
    

