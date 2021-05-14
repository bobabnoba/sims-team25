using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    class ProstorijaRepozitorijum
    {
        private static ProstorijaRepozitorijum _instance;
        public ObservableCollection<Prostorija> prostorije;
        public static ProstorijaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProstorijaRepozitorijum();

                }
                return _instance;
            }
        }

        private ProstorijaRepozitorijum()
        {
           prostorije = new ObservableCollection<Prostorija>();
        }

        public string lokacija = @"..\..\..\Data\prostorije.json";
        public void sacuvaj()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, prostorije);
            jWriter.Close();
            writer.Close();
        }
        public ObservableCollection<Prostorija> dobaviSve()
        {
            string lokacija = @"..\..\..\Data\prostorije.json";
            List<Prostorija> ucitaneProstorije = new List<Prostorija>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    ucitaneProstorije = JsonConvert.DeserializeObject<List<Prostorija>>(jsonText);
                }
            }
            if (ucitaneProstorije != null)
            {
                prostorije = new ObservableCollection<Prostorija>(ucitaneProstorije);
            }
            return prostorije;
        }

    }
}
