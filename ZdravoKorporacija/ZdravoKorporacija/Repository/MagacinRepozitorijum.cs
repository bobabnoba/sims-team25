using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using ZdravoKorporacija.Stranice.Magacin;
using System.Collections.ObjectModel;
using ZdravoKorporacija.DTO;

namespace Repository
{
    public class MagacinRepozitorijum
    {
        private static MagacinRepozitorijum _instance;
        public  ObservableCollection<Inventar> magacinOprema;
        public ObservableCollection<InventarDTO> magacinOpremaDTO;
        public static MagacinRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MagacinRepozitorijum();

                }
                return _instance;
            }
        }

        private MagacinRepozitorijum() {
            magacinOprema = new ObservableCollection<Inventar>();
            magacinOpremaDTO = new ObservableCollection<InventarDTO>();
        }

        public bool Kreiraj()
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(int id)
        {
            // TODO: implement
            return false;
        }

        public Inventar Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Inventar> DobaviSve()
        {
            string lokacija = @"..\..\..\Data\inventar.json";
            List<Inventar> oprema = new List<Inventar>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    oprema = JsonConvert.DeserializeObject<List<Inventar>>(jsonText);
                }
            }
            if (oprema != null)
            {
                magacinOprema = new ObservableCollection<Inventar>(oprema);
            }
                return oprema;
            
        }

        public int Sacuvaj(Inventar inventar)
        {
            
            magacinOprema.Add(inventar);
         
            string lokacija = @"..\..\..\Data\inventar.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, magacinOprema);
            jWriter.Close();
            writer.Close();
            return 1;
        }

        public List<InventarDTO> DobaviSveDTO()
        {
            string lokacija = @"..\..\..\Data\inventar.json";
            List<InventarDTO> oprema = new List<InventarDTO>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    oprema = JsonConvert.DeserializeObject<List<InventarDTO>>(jsonText);
                }
            }
            if (oprema != null)
            {
                magacinOpremaDTO = new ObservableCollection<InventarDTO>(oprema);
            }
            return oprema;

        }


    }
}
