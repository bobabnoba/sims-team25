using System;
using Model;
using System.Collections.Generic;
using Repository;
using ZdravoKorporacija.Model;

namespace Service
{
   public class IzvestajService
   {
      public bool DodajIzvestaj(Izvestaj izvestaj, Dictionary<int, int> id_map)
      {
            IzvestajRepozitorijum datoteka = new IzvestajRepozitorijum();
            List<Izvestaj> izvestaji = datoteka.DobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapIzvestaji");


            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    return false;
                }
            }
            izvestaji.Add(izvestaj);
            datoteka.Sacuvaj(izvestaji);
            datotekaID.sacuvaj(id_map);
            return true;
        }
      
      public bool ObrisiIzvestaj(Izvestaj izvestaj, Dictionary<int, int> id_map)
      {
            IzvestajRepozitorijum datoteka = new IzvestajRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapIzvestaj");
            List<Izvestaj> izvestaji = datoteka.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    izvestaji.Remove(iz);
                    datoteka.Sacuvaj(izvestaji);
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }
      
      public bool AzurirajIzvestaj(Izvestaj izvestaj)
      {
            IzvestajRepozitorijum datoteka = new IzvestajRepozitorijum();
            List<Izvestaj> izvestaji = datoteka.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(izvestaj.Id))
                {
                    izvestaji.Remove(iz);
                    izvestaji.Add(izvestaj);
                    datoteka.Sacuvaj(izvestaji);
                    return true;
                }
            }
            return false;
        }
      
      public Izvestaj PregledIzvestaj(string id)
      {
            IzvestajRepozitorijum datoteka = new IzvestajRepozitorijum();
            List<Izvestaj> izvestaji = datoteka.DobaviSve();
            foreach (Izvestaj iz in izvestaji)
            {
                if (iz.Id.Equals(id))
                {
                    return iz;
                }
            }
            return null;
        }
      
      public List<Izvestaj> PregledSvihIzvestaja()
      {
            IzvestajRepozitorijum datoteka = new IzvestajRepozitorijum();
            List<Izvestaj> izvestaji = datoteka.DobaviSve();
            return izvestaji;
        }
   
   }
}