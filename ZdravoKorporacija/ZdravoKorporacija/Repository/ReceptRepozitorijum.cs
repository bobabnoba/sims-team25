// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor


using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class ReceptRepozitorijum
    {
        private string lokacija;

        public ReceptRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\Recept.json";
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

        public Recept Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<Recept> DobaviSve()
        {
            List<Recept> recepti = new List<Recept>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    recepti = JsonConvert.DeserializeObject<List<Recept>>(jsonText);
                }
            }
            return recepti;
        }

        public void Sacuvaj(List<Recept> recepti)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, recepti);
            jWriter.Close();
            writer.Close();
        }

    }
}
