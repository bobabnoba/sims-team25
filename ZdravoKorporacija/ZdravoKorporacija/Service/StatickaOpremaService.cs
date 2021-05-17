using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Repository;
using System.Diagnostics;
using ZdravoKorporacija.Model;
using System.Collections.ObjectModel;

namespace Service
{ 
        public class StatickaOpremaService
        {
            TerminService ts = new TerminService();
            public bool DodajOpremu(StatickaOprema st,DateTime dt,String sati,Prostorija p)
            {
            StatickaOpremaRepozitorijum stRepozitorijum =  StatickaOpremaRepozitorijum.Instance;
            
            String s = dt.ToString();
            String date = s.Split(" ")[0];

            Termin t = new Termin();
            t.Pocetak = dt;
            t.prostorija = p;
           

            
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }

            t.Id = id;
           
            ts.ZakaziTermin(t,ids);
            StatickaOpremaRepozitorijum.Instance.magacinStatickaOprema.Add(st);
            stRepozitorijum.Sacuvaj();
            return false;
            }

            public bool ObrisiOpremu(StatickaOprema oprema)
            {
                // TODO: implement
                return false;
            }

            public bool AzurirajOpremu(StatickaOprema oprema)
            {
                // TODO: implement
                return false;
            }

            public ObservableCollection<StatickaOprema> PregledSveOpreme()
            {
            StatickaOpremaRepozitorijum sor = StatickaOpremaRepozitorijum.Instance;
            return sor.DobaviSve();
        }

            public StatickaOprema PregledJedneOpreme()
            {
                // TODO: implement
                return null;
            }


    }
}
