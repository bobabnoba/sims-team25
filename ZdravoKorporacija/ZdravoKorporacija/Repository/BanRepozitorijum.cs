using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Repository
{
    public class BanRepozitorijum
    {
        private static BanRepozitorijum _instance;
        public ObservableCollection<Ban> bans;

        public static BanRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BanRepozitorijum();
                }
                return _instance;
            }
        }

        private BanRepozitorijum()
        {
            bans = new ObservableCollection<Ban>();
        }


        public void sacuvaj(Ban banovi)
        {
            bans.Clear();
            bans.Add(banovi);

            string lokacija = @"..\..\..\Data\banInfo.json";
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


        public Ban dobaviSve()
        {
            string lokacija = @"..\..\..\Data\banInfo.json";
            Ban b = new Ban();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    b = JsonConvert.DeserializeObject<Ban>(jsonText);
                }
            }
            if(b != null)
            {
                bans.Add(b);
            }
            return b;
        }
    }
}
