using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Service
{
    class KorisnikService
    {
        KorisnikRepozitorijum kr = KorisnikRepozitorijum.Instance;

        public bool DodajKorisnika(string ime, string sifra, UlogaEnum uloga)
        {
            Korisnik k = new Korisnik();
            k.Username = ime;
            k.Password = sifra;
            //default pacijent !!! test samo
            k.Uloga = UlogaEnum.Pacijent;
            //  ObservableCollection<Korisnik> korisnici = KorisnikRepozitorijum.Instance.korisnici;
            //  korisnici.Add(k);
            //  kr.Sacuvaj()

            kr.korisnici.Add(k);
            kr.Sacuvaj();

            return false;
        }
            public Korisnik Uloguj(UlogaEnum uloga, string ime, string sifra)
        {
         
            Korisnik unos = new Korisnik();
            unos.Username = ime;
            unos.Password = sifra;


            if (uloga == UlogaEnum.Upravnik)
            {
                ObservableCollection<Korisnik> lista = new ObservableCollection<Korisnik>(kr.DobaviSve());
                Korisnik upravnik = (Korisnik)lista.First(s => s.Username.Equals(unos.Username));
                if (upravnik != null) {
                    return upravnik;
                }
            }

            if (uloga == UlogaEnum.Pacijent)
            {
                ObservableCollection<Korisnik> lista = new ObservableCollection<Korisnik>(kr.DobaviSve());
                Korisnik pacijent = (Korisnik)lista.First(s => s.Username.Equals(unos.Username));
                if (pacijent != null)
                {
                    return pacijent;
                }
            }

            if (uloga == UlogaEnum.Lekar)
            {
                ObservableCollection<Korisnik> lista = new ObservableCollection<Korisnik>(kr.DobaviSve());
                Korisnik lekar = (Korisnik)lista.First(s => s.Username.Equals(unos.Username));
                if (lekar != null)
                {
                    return lekar;
                }
            }

            if (uloga == UlogaEnum.Sekretar)
            {
                ObservableCollection<Korisnik> lista = new ObservableCollection<Korisnik>(kr.DobaviSve());
                Korisnik sekretar = (Korisnik)lista.First(s => s.Username.Equals(unos.Username));
                if (sekretar != null)
                {
                    return sekretar;
                }
            }



            return null;
        }
    }
}
