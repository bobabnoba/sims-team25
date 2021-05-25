// File:    Doctor.cs
// Author:  User
// Created: Tuesday, March 23, 2021 10:47:16 PM
// Purpose: Definition of Class Doctor


using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Repository
{
    class ReceptRepozitorijum
    {
        private string lokacija;

        private static ReceptRepozitorijum _instance;
        public ObservableCollection<Recept> recepti;

        public static ReceptRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceptRepozitorijum();
                }
                return _instance;
            }
        }
        public ReceptRepozitorijum()
            {
            lokacija = @"..\..\..\Data\recept.json";
            }

       
        public bool Kreiraj()
        {
            // TODO: implement
            return false;
        }

        public bool Obrisi(Recept recept)
        {
            recepti.Remove(recept);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, recepti);
            jWriter.Close();
            writer.Close();
            return true;
        }

        public Recept Dobavi()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Recept> DobaviSve()
        {
            ObservableCollection<Recept> recepti = new ObservableCollection<Recept>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    recepti = JsonConvert.DeserializeObject<ObservableCollection<Recept>>(jsonText);
                }
            }
            if (recepti != null)
            {
                this.recepti = new ObservableCollection<Recept>(recepti);
            }
            return recepti;
        }

        public void Sacuvaj(ObservableCollection<Recept> recepti)
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
