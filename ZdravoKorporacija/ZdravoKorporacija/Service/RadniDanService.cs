using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Repository;
using ZdravoKorporacija.DTO;

namespace Service
{
    class RadniDanService
    {
        private PacijentService pacijentServis = new PacijentService();
        private RadniDanRepozitorijum datoteka = new RadniDanRepozitorijum();
        private LekarService lekarServis = new LekarService();
        public RadniDan NadjiDanZaLekara(DateTime dan, double lekar)
        {
            
            foreach(RadniDan rd in datoteka.dobaviSve())
            {
                if(rd.dan.Date.CompareTo( dan.Date ) == 0 && rd.lekar == lekar)
                {
                    return rd;
                }
                
            }
            return null;
        }
        public List<RadniDan> NadjiSveDaneZaLekara(double lekar)
        {
            List < RadniDan > dani = new List<RadniDan>();
            foreach(RadniDan rd in PregledSvihRadnihDana())
            {
                if (rd.lekar.Equals(lekar))
                    dani.Add(rd);
            }
            return dani;
        }

        public void InicijalizujRadneDane()
        {
            List<RadniDan> sviDani = PregledSvihRadnihDana();
            foreach(Lekar l in lekarServis.PregledSvihLekara())
            {
                List<RadniDan> dani = new List<RadniDan>();
                foreach(RadniDan rd in PregledSvihRadnihDana())
                {
                    if (rd.lekar.Equals(l.Jmbg))
                        dani.Add(rd);
                }
                if(dani.Count() == 0)
                {
                    for (DateTime date = DateTime.Now.Date; date <= DateTime.Now.AddDays(150); date = date.AddDays(1))
                    {
                        
                        //l.radniDani.Add(new RadniDan(date, l.Jmbg, false, true));
                        dani.Add(new RadniDan(date.Date, l.Jmbg, false,true));
                        
                    }
                    foreach(RadniDan dan in dani)
                    {
                        sviDani.Add(dan);
                        datoteka.sacuvaj(sviDani);
                    }
                }
            }
        }

        public bool AzurirajRadniDan(RadniDan dan)
        {
            List<RadniDan> dani = datoteka.dobaviSve();
            if(dan != null)
                foreach(RadniDan rd in dani)
                {
                    if(rd.dan.Date.Equals(dan.dan.Date) && rd.lekar.Equals(dan.lekar))
                    {
                        dani.Remove(rd);
                        dani.Add(dan);
                        datoteka.sacuvaj(dani);
                        return true;
                    }
                }
            return false;
        }
        public List<RadniDanDTO> PregledSvihRadnihDana2DTO(List<RadniDan> modeli)
        {
            if(modeli == null)
                modeli = PregledSvihRadnihDana();
            List<RadniDanDTO> dtos = new List<RadniDanDTO>();
            foreach(RadniDan model in modeli)
            {
                dtos.Add(Model2DTO(model));
            }
            return dtos;
        }
        public List<RadniDan> PregledSvihRadnihDana2Model(List<RadniDanDTO> dtos)
        {
            List<RadniDan> modeli = new List<RadniDan>();
            foreach(RadniDanDTO rddto in dtos)
            {
                modeli.Add(DTO2Model(rddto));
            }
            return modeli;
        }
        public List<RadniDan> PregledSvihRadnihDana()
        {
            List<RadniDan> dani = datoteka.dobaviSve();
            return dani;
        }
        public void DodajSlobodneDane(DateTime Od, DateTime Do, double lekar)
        {
            List<RadniDan> dani = datoteka.dobaviSve();
            foreach(RadniDan rd in dani.ToArray())
            {
                if (rd.dan.CompareTo(Od) >= 0 && rd.dan.CompareTo(Do) <= 0 && rd.lekar.Equals(lekar))
                {
                    RadniDan novi = rd;
                    novi.odmor = true;
                    if (AzurirajRadniDan(novi))
                    {
                        dani.Remove(rd);
                        dani.Add(novi);
                        datoteka.sacuvaj(dani);
                    }
                }
             
            }
        }

        public void DrugaSmena(DateTime Od, DateTime Do, double lekar, bool prva)
        {
            List<RadniDan> dani = datoteka.dobaviSve();
            foreach(RadniDan rd in dani.ToArray())
            {
                if (rd.dan.Date.CompareTo(Od.Date) >= 0 && rd.dan.Date.CompareTo(Do.Date) <= 0 && rd.lekar.Equals(lekar))
                {
                    RadniDan novi = rd;
                    if (prva == false)
                        novi.prvaSmena = false;
                    else
                        novi.prvaSmena = true;
                    if (AzurirajRadniDan(novi))
                    {
                        dani.Remove(rd);
                        dani.Add(novi);
                        datoteka.sacuvaj(dani);
                    }
                }
            }
        }
        public RadniDan DTO2Model(RadniDanDTO dto)
        {
            foreach(RadniDan rd in PregledSvihRadnihDana())
            {
                if(rd.dan.Date.Equals(dto.dan.Date) && rd.lekar.Equals(dto.lekar))
                {
                    return rd;
                }
            }
            return null;
        }
        public RadniDanDTO Model2DTO(RadniDan model)
        {
            RadniDanDTO dto = new RadniDanDTO(model.dan, model.lekar, model.odmor, model.prvaSmena);
            return dto;
        }
        public List<RadniDan> PregledOdDo(DateTime Od, DateTime Do, double lekar)
        {
            List<RadniDan> dani = new List<RadniDan>();
            foreach(RadniDan rd in PregledSvihRadnihDana())
            {
                if(rd.dan.Date >= Od.Date && rd.dan.Date <= Do.Date && rd.lekar.Equals(lekar))
                {
                    dani.Add(rd);
                }
            }
            return dani;
        }
    }
}
