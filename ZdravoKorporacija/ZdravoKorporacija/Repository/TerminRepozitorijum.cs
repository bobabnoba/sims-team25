using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace ZdravoKorporacija.Model
{
    class TerminRepozitorijum
    {
        private string lokacija;

        public TerminRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\termini.json";
        }

        public void sacuvaj(List<Termin> termini)
        {
            JsonSerializer serializer = new JsonSerializer();
            //serializer.PreserveReferencesHandling = PreserveReferencesHandling.All;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, termini);
            jWriter.Close();
            writer.Close();
            Serijalizacija(termini);
        }

        string SerializeObjectByJObject(List<Termin> ter)
        {
            string s = "";
            foreach (Termin t in ter)
            {
                var jo = JObject.FromObject(t);

                jo["prostorija"]["inventar"].Parent.Remove();
                jo["prostorija"]["statickaOprema"].Parent.Remove();
                jo["prostorija"]["dinamickaOprema"].Parent.Remove();
                jo["prostorija"]["Naziv"].Parent.Remove();
                jo["prostorija"]["Tip"].Parent.Remove();
                jo["prostorija"]["Slobodna"].Parent.Remove();
                jo["prostorija"]["Sprat"].Parent.Remove();
              
                //jo.Remove("prostorija");
                //jo.Add("prostorija", new JObject());
                //jo["prostorija"].AddAnnotation("Id") ;
                // jo["prostorija"]["Id"] = t.prostorija.Id;
                s += jo.ToString();
            }
            return s;
        }

        public void Serijalizacija(List<Termin> termini)
        {
            string json = SerializeObjectByJObject(termini);
            File.WriteAllText(@"..\..\..\Data\termini2.json", json);
        }


        public List<Termin> dobaviSve()
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
