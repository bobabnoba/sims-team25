using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Pkcs;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class PacijentController
    {
        private PacijentService servis;
        private PacijentKonverter pacijentKonverter = new PacijentKonverter();
        private NotifikacijaKonverter notifikacijaKonverter = new NotifikacijaKonverter();

        public PacijentController()
        {
            this.servis = new PacijentService();
        }


        public Pacijent konvertujDTOuEntitet(PacijentDTO pDTO)
        {
            return (Pacijent)servis.PregledSvihPacijenata().FirstOrDefault(p =>
                p.Username.Equals(pDTO.korisnickoIme) && p.Password.Equals(pDTO.lozinka));
        }

        public Boolean pacijentJeBanovan(PacijentDTO pDTO)
        {
            return konvertujDTOuEntitet(pDTO).banovan;
        }

        public void provjeriStatus(PacijentDTO ulogovaniPacijent)
        {
            Pacijent pacijent = (Pacijent)servis.PregledSvihPacijenata()
                .FirstOrDefault(s => ulogovaniPacijent.korisnickoIme.Equals(s.Username));
            servis.provjeriStatus(pacijent);
        }

        public void dodajNotifikaciju(PacijentDTO ulogovaniPacijent)
        {
            Pacijent pacijent = (Pacijent) servis.PregledSvihPacijenata()
                .FirstOrDefault(s => ulogovaniPacijent.korisnickoIme.Equals(s.Username));

            pacijent.notifikacije.Clear();
            foreach(NotifikacijaDTO nDTO in ulogovaniPacijent.notifikacije)
                pacijent.notifikacije.Add(notifikacijaKonverter.KonvertujDTOuEntitet(nDTO));

            servis.AzurirajPacijenta(pacijent);
        }

        public PacijentPodaciDTO konvertujUPodaciDTO(PacijentDTO pacijentDTO)
        {
            Pacijent pacijent = servis.PregledSvihPacijenata().FirstOrDefault(p =>
                p.Username.Equals(pacijentDTO.korisnickoIme) && p.Password.Equals(pacijentDTO.lozinka));

            return new PacijentPodaciDTO(pacijent.Ime, pacijent.Prezime, pacijent.Jmbg, pacijent.BrojTelefona,
                pacijent.Mejl, pacijent.AdresaStanovanja, pacijent.Pol);
        }

    }


}

