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

        public bool Azuriraj(ZdravstveniKarton zk)
        {
            KartonRepozitorijum datoteka = new KartonRepozitorijum();
            List<ZdravstveniKarton> kartoni = datoteka.dobaviSve();
            foreach (ZdravstveniKarton t in kartoni)
            {
                if (t.Id.Equals(zk.Id))
                {
                    kartoni.Remove(t);
                    kartoni.Add(zk);
                    datoteka.sacuvaj(kartoni);
                    return true;
                }
            }
            return false;
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
        public ZdravstveniKarton findById(long id) {
            List<ZdravstveniKarton> kartoni = dobaviSve();
            foreach(ZdravstveniKarton zk in kartoni)
            {
                if (zk.Id == id)
                    return zk;
                
            }
            return null;
        }

    }
}
