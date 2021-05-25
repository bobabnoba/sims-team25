using System;
using System.Collections.Generic;
using System.Text;
using Service;
using Model;
using DTO;

namespace ZdravoKorporacija.Controller
{
    class RadniDaniController

    {
        private RadniDanService danServis = new RadniDanService();

        public RadniDan NadjiDanZaLekara(DateTime dan, double lekar)
        {
            return danServis.NadjiDanZaLekara(dan, lekar);
        }

        public void InicijalizujRadneDane()
        {
            danServis.InicijalizujRadneDane();
        }
        public bool AzurirajRadniDan(RadniDan dan)
        {
            return danServis.AzurirajRadniDan(dan);
        }
        public List<RadniDanDTO> PregledSvihRadnihDana2DTO(List<RadniDan> modeli)
        {
            return danServis.PregledSvihRadnihDana2DTO(modeli);
        }
        public void DodajSlobodneDane(DateTime Od, DateTime Do, double lekar)
        {
             danServis.DodajSlobodneDane(Od, Do, lekar);
        }
        public void DrugaSmena(DateTime Od, DateTime Do, double lekar, bool prva)
        {
            danServis.DrugaSmena(Od, Do, lekar,  prva);
        }
        public List<RadniDan> PregledSvihRadnihDana2Model(List<RadniDanDTO> dtos)
        {
            return danServis.PregledSvihRadnihDana2Model(dtos);
        }
        public List<RadniDan> NadjiSveDaneZaLekara(double lekar)
        {
            return danServis.NadjiSveDaneZaLekara(lekar);
        }
        public List<RadniDan> PregledSvihRadnihDana()
        {
            return danServis.PregledSvihRadnihDana();
        }
        public RadniDanDTO Model2DTO(RadniDan model)
        {
            return danServis.Model2DTO(model);
        }
        public RadniDan DTO2Model(RadniDanDTO dto)
        {
            return danServis.DTO2Model(dto);
        }
        public List<RadniDan> PregledOdDo(DateTime Od, DateTime Do, double lekar)
        {
            return danServis.PregledOdDo(Od, Do, lekar);
        }
    }
}
