using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class DatotekaTerminJSON
    {
        private string lokacija;

        public DatotekaTerminJSON()
        {
            this.lokacija = @"..\..\..\Data\termini.json";
        }

        public void UpisivanjeUFajl(List<Termin> termini)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, termini);
            jWriter.Close();
            writer.Close();
        }
        public List<Termin> CitanjeIzFajla()
        {
            List<Termin> termini = new List<Termin>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    termini = JsonConvert.DeserializeObject<List<Termin>>(jsonText);
                }
            }
            return termini;
        }
    }
}
