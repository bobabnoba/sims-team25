﻿using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;

namespace Controller
{
    class NeodobreniLekController
    {
        NeodobreniLekService neodobreniLekService = new NeodobreniLekService();
        public bool DodajNeodobreniLek(ZahtevLek zahtevLek)
        {
            LekDTO lek = new LekDTO(zahtevLek.Lek.Id, zahtevLek.Lek.Proizvodjac, zahtevLek.Lek.Sastojci, zahtevLek.Lek.NusPojave, zahtevLek.Lek.NazivLeka);
            ZahtevLekDTO zahtevZaNeodobreniLek = new ZahtevLekDTO(lek, zahtevLek.NeophodnihPotvrda, zahtevLek.BrojPotvrda);
            return this.neodobreniLekService.DodajNeodobreniZahtevLeka(zahtevZaNeodobreniLek);
        }

        public ObservableCollection<ZahtevLek> PregledNeodobrenihLekova()
        {
            return this.neodobreniLekService.PregledNeodobrenihLekova();
        }

        public ObservableCollection<ZahtevLekDTO> PregledNeodobrenihLekovaDTO()
        {
            return this.neodobreniLekService.PregledNeodobrenihLekovaDTO();
        }
    }
}
