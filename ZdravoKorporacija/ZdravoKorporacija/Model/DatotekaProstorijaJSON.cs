using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class DatotekaProstorijaJSON
    {
        private string lokacija;

        public DatotekaProstorijaJSON()
        {
            this.lokacija = @"..\..\..\Data\prostorije.json";
        }

        public void UpisivanjeUFajl(List<Prostorija> prostorije)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, prostorije);
            jWriter.Close();
            writer.Close();
        }
        public List<Prostorija> CitanjeIzFajla()
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
