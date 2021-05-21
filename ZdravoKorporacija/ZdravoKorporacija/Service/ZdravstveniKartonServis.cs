using System;
using Model;
using System.Collections.Generic;
using Repository;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.DTO;

namespace Service
{
   public class ZdravstveniKartonServis
   {
      public bool KreirajZdravstveniKarton(ZdravstveniKarton ZdravstveniKarton, Dictionary<int, int> id_map)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZdravstveniKarton");


            foreach (ZdravstveniKarton pr in zdravstveniKartoni)
            {
                if (pr.Id.Equals(ZdravstveniKarton.Id))
                {
                    return false;
                }
            }
            zdravstveniKartoni.Add(ZdravstveniKarton);
            datoteka.Sacuvaj(zdravstveniKartoni);
            datotekaID.sacuvaj(id_map);
            return true;
        }

        public bool KreirajZdravstveniKartonJMBG(ZdravstveniKarton ZdravstveniKarton)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();

           


            foreach (ZdravstveniKarton pr in zdravstveniKartoni)
            {
                if (pr.Id.Equals(ZdravstveniKarton.Id))
                {
                    return false;
                }
            }
            zdravstveniKartoni.Add(ZdravstveniKarton);
            datoteka.Sacuvaj(zdravstveniKartoni);
            
            return true;
        }

        public bool ObrisiZdravstveniKarton(ZdravstveniKarton zdravstveniKarton, Dictionary<int, int> id_map)
      {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapZdravstveniKartoni");
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in zdravstveniKartoni)
            {
                if (zk.Id.Equals(zdravstveniKarton.Id))
                {
                    zdravstveniKartoni.Remove(zk);
                    datoteka.Sacuvaj(zdravstveniKartoni);
                    datotekaID.sacuvaj(id_map);
                    return true;
                }
            }
            return false;
        }


        public ZdravstveniKarton findById(long id)
        {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();

            List<ZdravstveniKarton> kartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in kartoni)
            {
                if (zk.Id == id)
                    return zk;

            }
            return null;
        }


      
      public bool AzurirajZdravstveniKarton(ZdravstveniKarton zdravstveniKarton)

      {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in zdravstveniKartoni)
            {
                if (zk.Id.Equals(zdravstveniKarton.Id))
                {
                    zdravstveniKartoni.Remove(zk);
                    zdravstveniKartoni.Add(zdravstveniKarton);
                    datoteka.Sacuvaj(zdravstveniKartoni);
                    return true;
                }
            }
            return false;
        }
      
      public ZdravstveniKarton PregledSvihZdravstvenihKartona(long id)
      {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            foreach (ZdravstveniKarton zk in zdravstveniKartoni)
            {
                if (zk.Id.Equals(id))
                {
                    return zk;
                }
            }
            return null;
        }
      
      public List<ZdravstveniKarton> PregledZdravstvenogKartona()
      {
            ZdravstveniKartonRepozitorijum datoteka = new ZdravstveniKartonRepozitorijum();
            List<ZdravstveniKarton> zdravstveniKartoni = datoteka.DobaviSve();
            return zdravstveniKartoni;
        }

       public ZdravstveniKartonDTO Model2DTO(ZdravstveniKarton model)
        {
            ZdravstveniKartonDTO dto = new ZdravstveniKartonDTO();
            dto.Id = model.Id;
            return dto;
        }
   
   }
}