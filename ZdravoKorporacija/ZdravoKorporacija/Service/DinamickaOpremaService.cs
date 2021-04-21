using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{ 
    public class DinamickaOpremaService
    {
        public bool DodajOpremu(Inventar inv,String dt,Prostorija pr)
        {
            int kolicina = -1;
            try 
            { 
                kolicina = int.Parse(dt);
            }
            catch (FormatException) {
                return false;
            }
            if (pr == null)
            {
                return false;
            }
            
            DinamickaOpremaRepozitorijum dtRepozitorijum = DinamickaOpremaRepozitorijum.Instance;
            MagacinRepozitorijum magacinRepozitorijum = MagacinRepozitorijum.Instance;
            if (kolicina <= inv.UkupnaKolicina) {
                inv.UkupnaKolicina = inv.UkupnaKolicina - kolicina;

                DinamickaOprema din = new DinamickaOprema(inv, kolicina);
                din.Prostorija = pr;
                dtRepozitorijum.Sacuvaj(din);


                List<Inventar> magacin = magacinRepozitorijum.DobaviSve();
                //List<Inventar> magacin = MagacinRepozitorijum.Instance.magacinOprema.Remove(inv);
                foreach (Inventar inventar in magacin)
                {
                    if (inventar.Id.Equals(inv.Id))
                    {
                       MagacinRepozitorijum.Instance.magacinOprema.Remove(inventar);
                       magacin.Add(inv);
                       magacinRepozitorijum.Sacuvaj(inv);
                       return true;
                    }
                }
            }
            return false;

        }

        public bool ObrisiOpremu(DinamickaOprema oprema)
        {
            // TODO: implement
            return false;
        }

        public bool AzurirajOpremu(DinamickaOprema oprema)
        {
            // TODO: implement
            return false;
        }

        public List<DinamickaOprema> PregledSveOpreme()
        {
            DinamickaOpremaRepozitorijum dor = DinamickaOpremaRepozitorijum.Instance;
            return dor.DobaviSve();
            
        }

        public DinamickaOprema PregledJedneOpreme()
        {
            // TODO: implement
            return null;
        }

    }
}
