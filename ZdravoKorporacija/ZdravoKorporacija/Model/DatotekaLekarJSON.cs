using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class DatotekaLekarJSON
    {
        private string lokacija;

        public DatotekaLekarJSON()
        {
            this.lokacija = @"..\..\..\Data\lekar.json";
        }

        public void UpisivanjeUFajl(List<Lekar> lekari)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, lekari);
            jWriter.Close();
            writer.Close();
        }
        public List<Lekar> CitanjeIzFajla()
        {
            List<Lekar> lekari = new List<Lekar>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    lekari = JsonConvert.DeserializeObject<List<Lekar>>(jsonText);
                }
            }
            return lekari;
        }
    }
}
