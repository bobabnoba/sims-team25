using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Service;

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

    }
}
