using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class BanRepozitorijum
    {
        private string lokacija;

        public BanRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\banInfo.json";
        }

        public void sacuvaj(List<Ban> banovi)
        {
            JsonSerializer serializer = new JsonSerializer();
            //serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, banovi);
            jWriter.Close();
            writer.Close();
        }
        public List<Ban> dobaviSve()
        {
            List<Ban> banovi = new List<Ban>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    banovi = JsonConvert.DeserializeObject<List<Ban>>(jsonText);
                }
            }
            return banovi;
        }
    }
}
