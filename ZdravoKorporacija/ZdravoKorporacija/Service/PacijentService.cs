using Model;
using System.Collections.Generic;
using System.Linq;
using ZdravoKorporacija.Model;
using Repository;
using System;
using ZdravoKorporacija.DTO;

namespace Service
{
    class PacijentService
    {
        private PacijentRepozitorijum pacRepo = new PacijentRepozitorijum();

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
        
       public Pacijent dobaviUlogovanog(string imeTextText, string lozinkaTextPassword)
       {
           return (Pacijent) pacRepo.dobaviSve()
               .FirstOrDefault(p => p.Username.Equals(imeTextText) && p.Password.Equals(lozinkaTextPassword));
       }

       public void provjeriStatus(Pacijent pacijent)
       {
           Ban b = BanRepozitorijum.Instance.dobavi(pacijent.Jmbg);

           if (b.otkazanCnt >= 3 || b.zakazanCnt >= 3 || b.pomerenCnt >= 3)
           {
               pacijent.banovan = true;
               b.trenutakBanovanja = DateTime.Now.ToString();

               b.otkazanCnt = 0;
               b.pomerenCnt = 0;
               b.zakazanCnt = 0;
           }

           // DateTime.Compare(DateTime.Now, DateTime.Parse(b.trenutakBanovanja).AddMinutes(3)) >= 0
           if (pacijent.banovan && DateTime.Compare(DateTime.Now, DateTime.Parse(b.trenutakBanovanja).AddMinutes(3)) >= 0)
           {
               pacijent.banovan = false;
           }

           this.AzurirajPacijenta(pacijent);
           BanRepozitorijum.Instance.sacuvaj(b);

       }

       public Pacijent pronadjiEntitetZaDTO(PacijentDTO dto)
       {
           return pacRepo.dobaviSve()
               .FirstOrDefault(p => p.Username.Equals(dto.korisnickoIme) && p.Password.Equals(dto.lozinka));
       }
    }
}
