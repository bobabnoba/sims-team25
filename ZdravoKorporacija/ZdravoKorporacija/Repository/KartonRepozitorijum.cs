using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Model;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ZdravoKorporacija.Repository
{
    class KartonRepozitorijum
    {
        private string lokacija;
        public KartonRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\kartoni.json";
        }
        
        public void sacuvaj(List<ZdravstveniKarton> kartoni)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, kartoni);
            jWriter.Close();
            writer.Close();
        }
        
        public List<ZdravstveniKarton> dobaviSve()
        {
            List<ZdravstveniKarton> kartoni = new List<ZdravstveniKarton>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    kartoni= JsonConvert.DeserializeObject<List<ZdravstveniKarton>>(jsonText);
                }
            }
            return kartoni;
        }

    }
}
