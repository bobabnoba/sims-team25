// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor

using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace Controller
{
    public class TerminController
    {
        TerminService ts = TerminService.Instance;
        private static TerminController _instance;

        public static TerminController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TerminController();
                }
                return _instance;
            }
        }
        public bool IzdajAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            return ts.IzdajAnamnezu(izvestaj, termin);
        }
        public bool ObrisiAnamnezu(IzvestajDTO izvestaj, TerminDTO termin)
        {
            return ts.ObrisiAnamnezu(izvestaj, termin);
        }
        public Termin FindOpByPocetak(DateTime poc)
        {
            return ts.FindOpByPocetak(poc);
        }
        public List<Termin> FindPrByPocetak(DateTime poc)
        {
            return ts.FindPrByPocetak(poc);
        }
        public bool ZakaziTermin(Termin termin, Dictionary<int, int> id_map)
        {
            ts.ZakaziTermin(termin,id_map);
            return true;
        }

        public bool AzurirajTermin(Termin termin)
        {
            ts.AzurirajTermin(termin);
            return true;
        }

        public bool OtkaziTermin(Termin termin, Dictionary<int, int> id_map)
        {
            ts.OtkaziTermin(termin, id_map);
            return true;
        }

        public Termin PregledTermina(int id)
        {
            return ts.PregledTermina(id);
        }

        public List<Termin> PregledSvihTermina()
        {
            return ts.PregledSvihTermina();
        }

        public List<TerminDTO> PregledSvihTermina2()
        {
            return ts.PregledSvihTermina2();
        }

        public Termin NadjiTermin(DateTime datum, Prostorija prostorija)
        {
            return null;
        }

        public Termin InicijalizujTermin(int id, TipTerminaEnum tip, DateTime pocetak, Pacijent pacijent, Lekar lekar, Prostorija prostorija)
        {
            return ts.InicijalizujTermin(id, tip, pocetak, pacijent, lekar, prostorija);
        }

        public int MapaTermina(Dictionary<int, int> ids)
        {
            return ts.MapaTermina(ids);
        }

        public List<Lekar> DobaviSlobodneLekare(List<Lekar> lekari, ObservableCollection<Termin> pregledi, DateTime pocetakTermina)
        {
            return ts.DobaviSlobodneLekare(lekari, pregledi, pocetakTermina);
        }

        public List<Prostorija> DobaviSlobodneProstorije(List<Prostorija> prostorije, ObservableCollection<Termin> pregledi, Termin termin)
        {
            return ts.DobaviSlobodneProstorije(prostorije,pregledi,termin);
        }

        public void InicijalizujTerminLekaru(Termin t)
        {
            ts.InicijalizujTerminLekaru(t);
        }

        public ZdravstveniKarton ProveriKartonKodZakazivanja(Pacijent pacijent)
        {
            return ts.ProveriKartonKodZakazivanja(pacijent);
        }

        public bool ZakaziTerminPacijent(Termin termin, Dictionary<int, int> ids, Pacijent pacijent)
        {
            return ts.ZakaziTerminPacijent(termin,ids,pacijent);
        }

        public bool AzurirajTerminPacijent(Termin termin, Pacijent pacijent)
        {
            return ts.AzurirajTerminPacijent(termin, pacijent);
        }

        public bool OtkaziTerminPacijent(Termin termin, Dictionary<int, int> ids, Pacijent pacijent)
        {
            return ts.OtkaziTerminPacijent(termin, ids, pacijent);
        }
    }
}
