using System;
using Model;
using System.Collections.Generic;
using Repository;
using ZdravoKorporacija.Model;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
   public class ReceptServis
   {
      ReceptRepozitorijum rr = ReceptRepozitorijum.Instance;
      public static ObservableCollection<Recept> recepti =  ReceptRepozitorijum.Instance.DobaviSve();

        private static ReceptServis _instance;

        public static ReceptServis Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceptServis();
                }
                return _instance;
            }
        }
        public bool DodajRecept(ReceptDTO recept, Dictionary<int, int> id_map)
      {

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRecept");


            foreach (Recept r in rr.DobaviSve())
            {
                if (r.Id.Equals(recept.Id))
                {
                    return false;
                }
            }
            
            recepti.Add(ConvertToModel(recept));
            rr.Sacuvaj(recepti);
            datotekaID.sacuvaj(id_map);
            return true;
        }
      
      public bool ObrisiRecept(ReceptDTO recept, Dictionary<int, int> id_map)
      {
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapRecept");
            foreach (Recept r in rr.DobaviSve())
            {
                if (r.Id.Equals(recept.Id))
                {
                    recepti.Remove(r);
                    rr.Sacuvaj(recepti);
                }
            }
            datotekaID.sacuvaj(id_map);
            return true ;
        }
      
      public bool AzurirajRecept(ReceptDTO recept)
      {
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(recept.Id))
                {
                    recepti.Remove(r);
                    recepti.Add(new Recept(recept));
                    rr.Sacuvaj(recepti);
                    return true;
                }
            }
            return false;
        }
      
      public ReceptDTO PregledRecept(string id)
      {
            foreach (Recept r in recepti)
            {
                if (r.Id.Equals(id))
                {
                    return new ReceptDTO(r);
                }
            }
            return null;
        }

      public ObservableCollection<ReceptDTO> PregledSvihRecepata()
      {
            ObservableCollection < Recept > recepti = rr.DobaviSve();
            ObservableCollection<ReceptDTO> receptDTOs = new ObservableCollection<ReceptDTO>();
            foreach(Recept r in recepti)
            {
                receptDTOs.Add(new ReceptDTO(r));
            }
            return receptDTOs;
      }

      public ReceptDTO ConvertToDTO(Recept recept)
        {
            return new ReceptDTO(recept);
        }
      
        public Recept ConvertToModel(ReceptDTO recept)
        {
            return new Recept(recept);
        }
   
   }
}