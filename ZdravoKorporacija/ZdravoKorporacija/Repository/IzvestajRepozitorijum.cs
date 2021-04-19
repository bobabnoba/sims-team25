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
    public class IzvestajRepozitorijum
    {
        private string lokacija;

        public IzvestajRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\izvestaj.json";
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

        public List<Izvestaj> DobaviSve()
        {
            List<Izvestaj> izvestaji = new List<Izvestaj>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    izvestaji = JsonConvert.DeserializeObject<List<Izvestaj>>(jsonText);
                }
            }
            return izvestaji;
        }

        public void Sacuvaj(List<Izvestaj> izvestaji)
        {

            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, izvestaji);
            jWriter.Close();
            writer.Close();
        }

    }
}