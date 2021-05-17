using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Repository;

namespace Service
{
    class NeodobreniLekService
    {
        private NeodobreniLekRepository datoteka = NeodobreniLekRepository.Instance;
        public bool DodajNeodobreniZahtevLeka(ZahtevLekDTO zahtevLek)
        {
            ObservableCollection<ZahtevLek> zahteviNeodobreniLekovi = NeodobreniLekRepository.Instance.neodobreniLekovi;
            IDRepozitorijum datotekaNeodobreniId = new IDRepozitorijum("iDMapNeodobreniLek");
            Dictionary<int, int> id_map = datotekaNeodobreniId.dobaviSve();

            int id = nadjiSlobodanID(id_map);
            id_map[id] = 1;


            Lek lek = new Lek(zahtevLek.Lek.Id, zahtevLek.Lek.Proizvodjac, zahtevLek.Lek.Sastojci, zahtevLek.Lek.NusPojave, zahtevLek.Lek.NazivLeka);
            ZahtevLek zahtevZaNeodobreniLek = new ZahtevLek(lek, zahtevLek.NeophodnihPotvrda, zahtevLek.BrojPotvrda);

            foreach (LekDTO lekD in zahtevLek.Lek.alternativniLekovi)
            {
                Lek l = new Lek(lekD.Id, lekD.NusPojave, lekD.Sastojci, lekD.NusPojave, lekD.NazivLeka);
                zahtevZaNeodobreniLek.Lek.alternativniLekovi.Add(l);
            }

            zahtevZaNeodobreniLek.Setlekari(zahtevLek.lekari);
            zahtevZaNeodobreniLek.Id = id;

            NeodobreniLekRepository.Instance.neodobreniLekovi.Add(zahtevZaNeodobreniLek);
            this.datoteka.sacuvaj();
            datotekaNeodobreniId.sacuvaj(id_map);
            return true;
        }

        public ObservableCollection<ZahtevLek> PregledNeodobrenihLekova()
        {
            return this.datoteka.dobaviSve();
        }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
        }
    }
}
