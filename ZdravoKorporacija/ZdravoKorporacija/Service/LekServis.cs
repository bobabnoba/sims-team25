using System;
using Model;
using System.Collections.Generic;
using Repository;
using ZdravoKorporacija.Model;

namespace Service
{
   public class LekServis
   {
      public bool DodajLek(Lek Lek, Dictionary<int, int> id_map)
      {
            LekRepozitorijum datoteka = new LekRepozitorijum();
            List<Lek> lekovi = datoteka.DobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapLekova");


            foreach (Lek pr in lekovi)
            {
                if (pr.Id.Equals(Lek.Id))
                {
                    return false;
                }
            }
            lekovi.Add(Lek);
            datoteka.Sacuvaj(lekovi);
            datotekaID.sacuvaj(id_map);
            return true;
        }
      
      public bool ObrisiLek(Lek lek, Dictionary<int, int> id_map)
      {
            LekRepozitorijum datoteka = new LekRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapLek");
            List<Lek> lekovi = datoteka.DobaviSve();
            foreach (Lek l in lekovi)
            {
                if (l.Id.Equals(lek.Id))
                {
                    lekovi.Remove(l);
                    datoteka.Sacuvaj(lekovi);
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }
      
      public bool AzurirajLek(Lek lek)
      {
            LekRepozitorijum datoteka = new LekRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapLek");
            List<Lek> lekovi = datoteka.DobaviSve();
            foreach (Lek l in lekovi)
            {
                if (l.Id.Equals(lek.Id))
                {
                    lekovi.Remove(l);
                    lekovi.Add(lek);
                    datoteka.Sacuvaj(lekovi);
                    return true;
                }
            }
            return false;
        }
      
      public Lek PregledLeka(string id)
      {
            LekRepozitorijum datoteka = new LekRepozitorijum();
            List<Lek> lekovi = datoteka.DobaviSve();
            foreach (Lek l in lekovi)
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
            LekRepozitorijum datoteka = new LekRepozitorijum();
            List<Lek> lekovi = datoteka.DobaviSve();
            return lekovi;
        }
   
   }
}