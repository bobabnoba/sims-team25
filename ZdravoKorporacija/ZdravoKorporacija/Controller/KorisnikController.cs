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
    public class KorisnikController
    {
        private KorisnikService ks = new KorisnikService();
        private PacijentService pacijentService = new PacijentService();
        private PacijentKonverter pacijentKonverter = new PacijentKonverter();

        public PacijentDTO ulogovaniPacijent(UlogaEnum uloga, string korisnickoIme, string lozinka)
        {
            //Korisnik ulogovan = ks.Uloguj(uloga, korisnickoIme, lozinka);
       
            Pacijent ulogovani = pacijentService.dobaviUlogovanog(korisnickoIme, lozinka);
            return pacijentKonverter.KonvertujEntitetUDTO(ulogovani);
        }

    }

   

}

