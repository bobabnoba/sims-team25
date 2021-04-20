using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Repository;
using System.Diagnostics;
using ZdravoKorporacija.Model;

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

            Debug.WriteLine(date + " " + sati);
            Debug.WriteLine("" + s);

            DateTime datum = DateTime.Parse(date + " " + sati);
            st.termin.Pocetak = datum;
            Termin t = new Termin();
            t.Pocetak = datum;
            t.prostorija = p;
            
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            ts.ZakaziTermin(t,ids);

            stRepozitorijum.Sacuvaj(st);
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

            public List<StatickaOprema> PregledSveOpreme()
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
