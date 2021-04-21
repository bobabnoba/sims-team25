// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Newtonsoft.Json;

namespace Repository
{
   public class LekRepozitorijum
   {
        private string lokacija;

        public LekRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\lek.json";
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
      
      public Lek Dobavi()
      {
         // TODO: implement
         return null;
      }
      
      public List<Lek> DobaviSve()
      {
            List<Lek> lekovi = new List<Lek>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    lekovi = JsonConvert.DeserializeObject<List<Lek>>(jsonText);
                }
            }
            return lekovi;
        }
      
      public void Sacuvaj(List<Lek> lekovi)
      {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, lekovi);
            jWriter.Close();
            writer.Close();
        }
   
   }
}