using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class UpravnikController
    {
        public Inventar DodajUMagacin(int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke,Dictionary<int,int> id_map)
        {
            MagacinService ms = new MagacinService();
            ms.DodajOpremu(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke,id_map);
            return null;
        }
        public bool DodajIzMagacina()
        {
            MagacinService ms = new MagacinService();
            ms.PregledSveOpreme();
            return true;
        }
        public ObservableCollection<StatickaOprema> PregledMagacinaStaticke()
        {
            StatickaOpremaService sos = new StatickaOpremaService();
            return  sos.PregledSveOpreme();
           
        }
        public ObservableCollection<DinamickaOprema> PregledMagacinaDinamcike()
        {
            DinamickaOpremaService dos = new DinamickaOpremaService();
            return dos.PregledSveOpreme();
        }
        public List<Termin> PregledSvihTermina()
        {
            TerminService tos = new TerminService();
            return tos.PregledSvihTermina();
            
        }

        public bool Registruj(string ime, string prezime, UlogaEnum uloga)
        {
            KorisnikService ks = new KorisnikService();
            ks.DodajKorisnika(ime,prezime,uloga);
            return false;
        }

    }
}
