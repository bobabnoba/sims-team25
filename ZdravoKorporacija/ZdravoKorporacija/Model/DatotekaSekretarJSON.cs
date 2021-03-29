using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class DatotekaSekretarJSON
    {
        private string lokacija;

        public DatotekaSekretarJSON()
        {
            this.lokacija = @"..\..\..\Data\sekretar.json";
        }

        public void UpisivanjeUFajl(List<Sekretar> sekretari)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, sekretari);
            jWriter.Close();
            writer.Close();
        }
        public List<Sekretar> CitanjeIzFajla()
        {
            List<Sekretar> sekretari = new List<Sekretar>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    sekretari = JsonConvert.DeserializeObject<List<Sekretar>>(jsonText);
                }
            }
            return sekretari;
        }
    }
}
