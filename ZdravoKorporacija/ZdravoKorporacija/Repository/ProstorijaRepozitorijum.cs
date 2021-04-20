using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    class ProstorijaRepozitorijum
    {
        private string lokacija;

        public ProstorijaRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\prostorije.json";
        }

        public void sacuvaj(List<Prostorija> prostorije)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, prostorije);
            jWriter.Close();
            writer.Close();
        }
        public List<Prostorija> dobaviSve()
        {
            List<Prostorija> prostorije = new List<Prostorija>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    prostorije = JsonConvert.DeserializeObject<List<Prostorija>>(jsonText);
                }
            }
            return prostorije;
        }

    }
}
