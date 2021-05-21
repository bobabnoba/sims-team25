using Model;
using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using System.Transactions;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace Service
{
   public  class LekarService
    {
        public List<Lekar> PregledSvihLekara()
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            List<Lekar> lekovi = datoteka.dobaviSve();
            return lekovi;
        }

        public Lekar DTO2Model(LekarDTO dto)
        {
            if (dto != null)
            foreach(Lekar l in PregledSvihLekara())
            {
                if (dto.Jmbg.Equals(l.Jmbg)) 
                    return l;
            }
            return null;
        }
        public LekarDTO Model2DTO(Lekar model)
        {

            LekarDTO dto = new LekarDTO(model.Ime, model.Prezime, model.Jmbg, model.BrojTelefona, model.Mejl, model.AdresaStanovanja, model.Pol, model.Username, model.Password, model.Uloga);
            return dto;
        }
        public List<Lekar> PregledSvihLekaraModel(List<LekarDTO> dtos)
        {
            List<Lekar> modeli = new List<Lekar>();
            foreach(LekarDTO ldto in dtos)
            {
                modeli.Add(DTO2Model(ldto));
            }
            return modeli;
        }

        public List<LekarDTO> PregledSvihLekaraDTO(List<Lekar> modeli)
        {
            List<LekarDTO> dtos = new List<LekarDTO>();
            foreach(Lekar l in modeli)
            {
                dtos.Add(Model2DTO(l));
            }
            return dtos;
        }
        public void AzurirajLekare(List<Lekar> lekari)
        {
            LekarRepozitorijum datoteka = new LekarRepozitorijum();
            datoteka.sacuvaj(lekari);
        }
      
    }

}
