using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Service
{
    public class MagacinService
    {
        public bool DodajOpremu(int id, string naziv, int ukupnaKolicina, string proizvodjac, DateTime datumNabavke,Dictionary<int,int> id_map)
        {

            MagacinRepozitorijum mr = MagacinRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapMagacin");
            datotekaID.sacuvaj(id_map);
            Inventar inventar = new Inventar(id, naziv, ukupnaKolicina, proizvodjac, datumNabavke);

            mr.Sacuvaj(inventar);

            return false;
        }

        public bool ObrisiOpremu(Inventar oprema)
        {
            // TODO: implement
            return false;
        }

        public bool AzurirajOpremu(Inventar oprema)
        {
            // TODO: implement
            return false;
        }

        public Inventar PregledJedneopreme()
        {
            // TODO: implement
            return null;
        }

        public List<Inventar> PregledSveOpreme()
        {
            MagacinRepozitorijum mr = MagacinRepozitorijum.Instance;

            mr.DobaviSve();
            return null;
        }

    }
}
