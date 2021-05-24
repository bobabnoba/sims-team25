using System;
using Model;
using System.Collections.Generic;
using Repository;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Repository;
using System.Collections;

namespace Service
{
   public class LekServis
   {
      public bool DodajLek(Lek Lek, Dictionary<int, int> id_map)
      {
           
            LekRepozitorijum datoteka = LekRepozitorijum.Instance;
       

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapLekova");
            LekRepozitorijum.Instance.lekovi.Add(Lek);
            datoteka.Sacuvaj();
            datotekaID.sacuvaj(id_map);
            //dodato
            datoteka.DobaviSve();
            
            return true;
        }

        public bool ObrisiLek(Lek lek, Dictionary<int, int> id_map)
      {
            LekRepozitorijum datoteka = LekRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapLekova");

            foreach (Lek l in LekRepozitorijum.Instance.lekovi)
            {
                if (l.Id.Equals(lek.Id))
                {
                    LekRepozitorijum.Instance.lekovi.Remove(l);
                    datoteka.Sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }
      
      public bool AzurirajLek(Lek lek)
      {
            LekRepozitorijum datoteka = LekRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapLekova");
           
            foreach (Lek l in LekRepozitorijum.Instance.lekovi)
            {
                if (l.Id.Equals(lek.Id))
                {
                    LekRepozitorijum.Instance.lekovi.Remove(l);
                    LekRepozitorijum.Instance.lekovi.Add(lek);
                    datoteka.Sacuvaj();
                    return true;
                }
            }
            return false;
        }
      
      public Lek PregledLeka(string id)
      {
            LekRepozitorijum datoteka = LekRepozitorijum.Instance;
           
            foreach (Lek l in LekRepozitorijum.Instance.lekovi)
            {
                if (l.Id.Equals(id))
                {
                    return l;
                }
            }
            return null;
        }
      
      public List<Lek> PregledSvihLekova()
      {
            LekRepozitorijum datoteka = LekRepozitorijum.Instance;
            List<Lek> lekovi = datoteka.DobaviSve();
            return lekovi;
        }


        public bool DodajZahtevLeka(ZahtevLekDTO zahtevLek)
        {
            ZahtevLekRepozitorijum datoteka = ZahtevLekRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevZaLek");
            datoteka.dobaviSve();
            Dictionary<int, int> id_map = datotekaID.dobaviSve();
            int id = nadjiSlobodanID(id_map);
            id_map[id] = 1;

            Lek lek = new Lek(zahtevLek.Lek.Id,zahtevLek.Lek.Proizvodjac,zahtevLek.Lek.Sastojci,zahtevLek.Lek.NusPojave,zahtevLek.Lek.NazivLeka);
            ZahtevLek zahtevZaLek = new ZahtevLek(lek,zahtevLek.NeophodnihPotvrda,zahtevLek.BrojPotvrda);
            
            foreach (LekDTO lekD in zahtevLek.Lek.alternativniLekovi) {
                Lek l = new Lek(lekD.Id,lekD.NusPojave,lekD.Sastojci,lekD.NusPojave,lekD.NazivLeka);
                zahtevZaLek.Lek.alternativniLekovi.Add(l);
             }

            zahtevZaLek.Setlekari(zahtevLek.lekari);

            zahtevZaLek.Id = zahtevLek.Id;

            ZahtevLekRepozitorijum.Instance.zahteviLek.Add(zahtevZaLek);
            datoteka.sacuvaj();
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool ObrisiZahtevZaLek(ZahtevLek zahtevLek, Dictionary<int, int> id_map)
        {
            ZahtevLekRepozitorijum datoteka = ZahtevLekRepozitorijum.Instance;
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZahtevZaLek");
            datoteka.dobaviSve();
            id_map = datotekaID.dobaviSve();
            id_map[zahtevLek.Id] = 0;


            foreach (ZahtevLek z in ZahtevLekRepozitorijum.Instance.zahteviLek)
            {
                if (z.Id.Equals(zahtevLek.Id))
                {
                    ZahtevLekRepozitorijum.Instance.zahteviLek.Remove(z);
                    datoteka.sacuvaj();
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }

        public List<ZahtevLek> PregledSvihZahtevaLek()

        {
            ZahtevLekRepozitorijum datoteka = ZahtevLekRepozitorijum.Instance;
            List<ZahtevLek> zahteviLekovi = datoteka.dobaviSve();
            return zahteviLekovi;
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