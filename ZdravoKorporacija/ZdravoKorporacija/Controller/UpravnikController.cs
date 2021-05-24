﻿using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Controller
{
    public class UpravnikController
    {
        MagacinService magacinServis = new MagacinService();
        DinamickaOpremaService dinamickaOpremaServis = new DinamickaOpremaService();
        public bool DodajUMagacin(InventarDTO opremaDTO)
        {
         return  magacinServis.DodajOpremu(opremaDTO);
        }
        public bool DodajIzMagacina()
        {
            magacinServis.PregledSveOpreme();
            return true;
        }

        public ObservableCollection<InventarDTO> DodajIzMagacinaDTO()
        {
            return magacinServis.PregledSveOpremeDTO();
        }
        public ObservableCollection<StatickaOprema> PregledMagacinaStaticke()
        {
            StatickaOpremaService sos = new StatickaOpremaService();
            return  sos.PregledSveOpreme();
           
        }
        public ObservableCollection<DinamickaOprema> PregledMagacinaDinamcike()
        {
            return dinamickaOpremaServis.PregledSveOpreme();
        }

        public ObservableCollection<DinamickaOpremaDTO> PregledMagacinaDinamcikeDTO()
        {
            return dinamickaOpremaServis.PregledSveOpremeDTO();
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
