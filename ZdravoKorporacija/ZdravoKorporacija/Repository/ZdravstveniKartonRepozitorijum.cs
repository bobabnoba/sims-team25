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
    public class ZdravstveniKartonRepozitorijum
    {
        private string lokacija;

        public ZdravstveniKartonRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\zdravstveniKarton.json";
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

        public Model.ZdravstveniKarton Dobavi()
        {
            // TODO: implement
            return null;
        }

        public List<ZdravstveniKarton> DobaviSve()
        {
            List<ZdravstveniKarton> zdravstveniKartoni = new List<ZdravstveniKarton>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    zdravstveniKartoni = JsonConvert.DeserializeObject<List<ZdravstveniKarton>>(jsonText);
                }
            }
            return zdravstveniKartoni;
        }

        public void Sacuvaj(List<ZdravstveniKarton> zdravstveniKartoni)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, zdravstveniKartoni);
            jWriter.Close();
            writer.Close();
        }

    }
}