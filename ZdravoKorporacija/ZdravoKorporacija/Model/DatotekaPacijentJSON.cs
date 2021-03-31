using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class DatotekaPacijentJSON
    {

        private string lokacija;

        public DatotekaPacijentJSON()
        {
            this.lokacija = @"..\..\..\Data\pacijent.json";
        }

        public void UpisivanjeUFajl(List<Pacijent> pacijenti)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, pacijenti);
            jWriter.Close();
            writer.Close();
        }
        public List<Pacijent> CitanjeIzFajla()
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    pacijenti = JsonConvert.DeserializeObject<List<Pacijent>>(jsonText);
                }
            }
            return pacijenti;
        }
    }
}
