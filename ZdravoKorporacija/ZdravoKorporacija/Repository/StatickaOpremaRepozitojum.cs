using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Repository
{
    public class StatickaOpremaRepozitorijum
    {

        private static StatickaOpremaRepozitorijum _instance;
        public ObservableCollection<StatickaOprema> magacinStatickaOprema;
        public static StatickaOpremaRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatickaOpremaRepozitorijum();

                }
                return _instance;
            }
        }

        private StatickaOpremaRepozitorijum()
        {
            magacinStatickaOprema = new ObservableCollection<StatickaOprema>();
        }
        public bool Kreiraj()
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(int id)
        {
            // TODO: implement
            return false;
        }

        public StatickaOprema Dobavi()
        {
            // TODO: implement
            return null;
        }

        public Array DobaviSve()
        {
            string lokacija = @"..\..\..\Data\statickaOprema.json";
            List<Inventar> oprema = new List<Inventar>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    oprema = JsonConvert.DeserializeObject<List<Inventar>>(jsonText);
                }
            }
            if (oprema != null)
            {
                magacinOprema = new ObservableCollection<Inventar>(oprema);
            }
            return oprema;
        }

        public int Sacuvaj(StatickaOprema st)
        {
            magacinStatickaOprema.Add(st);

            string lokacija = @"..\..\..\Data\statickaOprema.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, magacinStatickaOprema);
            jWriter.Close();
            writer.Close();
            return 1;
        }

    }
}
