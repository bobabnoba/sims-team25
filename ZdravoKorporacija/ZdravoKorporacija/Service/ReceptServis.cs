using System;
using Model;
using System.Collections.Generic;
using Repository;
using ZdravoKorporacija.Model;

namespace Service
{
   public class ReceptServis
   {
      public bool DodajRecept(Recept recept, Dictionary<int, int> id_map)
      {

            ReceptRepozitorijum datoteka = new ReceptRepozitorijum();
            List<Recept> recepti = datoteka.DobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRecept");


            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(recept.Id))
                {
                    return false;
                }
            }
            recepti.Add(recept);
            datoteka.Sacuvaj(recepti);
            datotekaID.sacuvaj(id_map);
            return true;
        }
      
      public bool ObrisiRecept(Recept recept, Dictionary<int, int> id_map)
      {
            ReceptRepozitorijum datoteka = new ReceptRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRecepti");
            List<Recept> recepti = datoteka.DobaviSve();
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(recept.Id))
                {
                    recepti.Remove(r);
                    datoteka.Sacuvaj(recepti);
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }
      
      public bool AzurirajRecept(Recept recept)
      {
            ReceptRepozitorijum datoteka = new ReceptRepozitorijum();
            List<Recept> recepti = datoteka.DobaviSve();
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(recept.Id))
                {
                    recepti.Remove(r);
                    recepti.Add(recept);
                    datoteka.Sacuvaj(recepti);
                    return true;
                }
            }
            return false;
        }
      
      public Recept PregledRecept(string id)
      {
            ReceptRepozitorijum datoteka = new ReceptRepozitorijum();
            List<Recept> recepti = datoteka.DobaviSve();
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(id))
                {
                    return r;
                }
            }
            return null;
        }
      
      public List<Recept> PregledSvihRecepata()
      {
            ReceptRepozitorijum datoteka = new ReceptRepozitorijum();
            List<Recept> recepti = datoteka.DobaviSve();
            return recepti;
        }
   
   }
}