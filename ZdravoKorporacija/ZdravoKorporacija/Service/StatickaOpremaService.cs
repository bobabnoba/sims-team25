using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Repository;

namespace Service
{ 
        public class StatickaOpremaService
        {
            public bool DodajOpremu(StatickaOprema st)
            {
            StatickaOpremaRepozitorijum stRepozitorijum =  StatickaOpremaRepozitorijum.Instance;

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
                // TODO: implement
                return null;
            }

            public StatickaOprema PregledJedneOpreme()
            {
                // TODO: implement
                return null;
            }


    }
}
