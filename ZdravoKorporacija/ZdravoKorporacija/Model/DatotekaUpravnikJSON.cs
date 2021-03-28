using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class DatotekaUpravnikJSON
    {

        private string lokacija;

        public DatotekaUpravnikJSON()
        {
            this.lokacija = @"..\..\..\Data\upravnik.json";
        }

        public void UpisivanjeUFajl(List<Upravnik> upravnici)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, upravnici);
            jWriter.Close();
            writer.Close();
        }
        public List<Upravnik> CitanjeIzFajla()
        {
            List<Upravnik>  upravnici = new List<Upravnik>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    upravnici = JsonConvert.DeserializeObject<List<Upravnik>>(jsonText);
                }
            }
            return upravnici;
        }
    }
}
