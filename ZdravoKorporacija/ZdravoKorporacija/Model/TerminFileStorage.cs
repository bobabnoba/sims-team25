using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ZdravoKorporacija.Model
{
    class TerminFileStorage
    {


        public bool ZakaziTermin(Termin termin)
        {
            DatotekaTerminJSON datoteka = new DatotekaTerminJSON();
            List<Termin> termini = datoteka.CitanjeIzFajla();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                   // return false;
                }
            }
            termini.Add(termin);
            datoteka.UpisivanjeUFajl(termini);
            return true;
        }

        public bool AzurirajTermin(Termin termin)
        {
            DatotekaTerminJSON datoteka = new DatotekaTerminJSON();
            List<Termin> termini = datoteka.CitanjeIzFajla();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    termini.Add(termin);
                    datoteka.UpisivanjeUFajl(termini);
                    return true;
                }
            }
            return false;
        }

        public bool OtkaziTermin(Termin termin)
        {
            DatotekaTerminJSON datoteka = new DatotekaTerminJSON();
            List<Termin> termini = datoteka.CitanjeIzFajla();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(termin.Id))
                {
                    termini.Remove(t);
                    datoteka.UpisivanjeUFajl(termini);
                    return true;
                }
            }
            return false;
        }

        public Termin PregledTermina(int id)
        {
            DatotekaTerminJSON datoteka = new DatotekaTerminJSON();
            List<Termin> termini = datoteka.CitanjeIzFajla();
            foreach (Termin t in termini)
            {
                if (t.Id.Equals(id))
                {
                    return t;
                }
            }
            return null;
        }
        public List<Termin> PregledSvihTermina()
        {
            DatotekaTerminJSON datoteka = new DatotekaTerminJSON();
            List<Termin> termini = datoteka.CitanjeIzFajla();
            return termini;
        }
    }
}
