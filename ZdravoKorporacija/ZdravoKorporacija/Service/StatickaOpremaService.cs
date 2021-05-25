using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Repository;
using System.Diagnostics;
using ZdravoKorporacija.Model;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Service
{
    public class StatickaOpremaService
        {
        StatickaOpremaRepozitorijum statickaRepozitorijum = StatickaOpremaRepozitorijum.Instance;
        TerminService ts = new TerminService();
        public bool DodajOpremu(StatickaOpremaDTO statickaOpremaDTO,DateTime dt,String sati,ProstorijaDTO p)
            {  
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            Dictionary<int, int> ids = datotekaID.dobaviSve();
            int slobodanId = nadjiSlobodanID(ids);
            ids[slobodanId] = 1;


            String s = dt.ToString();
            String date = s.Split(" ")[0];

            TerminDTO t = new TerminDTO();
            t.Id = slobodanId;
            t.Pocetak = dt;
            t.prostorija = p;

           
            ts.ZakaziTerminDTO(t,ids);
            StatickaOprema statickaOprema = new StatickaOprema(statickaOpremaDTO);

            StatickaOpremaRepozitorijum.Instance.magacinStatickaOprema.Add(statickaOprema);
            statickaRepozitorijum.Sacuvaj();
            return true;
            }

        private int nadjiSlobodanID(Dictionary<int, int> id_map)
        {
            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (id_map[i] == 0)
                {
                    id = i;
                    id_map[i] = 1;
                    return id;
                }
            }
            return id;
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
            return statickaRepozitorijum.DobaviSve();
            }

            public ObservableCollection<StatickaOpremaDTO> PregledSveOpremeDTO()
             {
            ObservableCollection<StatickaOprema> statickaOprema = statickaRepozitorijum.DobaviSve();
            ObservableCollection<StatickaOpremaDTO> statickaOpremaDTO = new ObservableCollection<StatickaOpremaDTO>();
            foreach (StatickaOprema oprema in statickaOprema)
            {
                statickaOpremaDTO.Add(konvertujEntitetUDTO(oprema));
            }
            return statickaOpremaDTO;

        }

        public StatickaOpremaDTO konvertujEntitetUDTO(StatickaOprema zahtevLek)
        {
            return new StatickaOpremaDTO(zahtevLek);
        }

        public StatickaOprema PregledJedneOpreme()
            {
                // TODO: implement
                return null;
            }


    }
}
