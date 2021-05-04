using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Repository
{
    class RenoviranjeRepozitorijum
    {
        private static RenoviranjeRepozitorijum _instance;
        public ObservableCollection<ZahtevRenoviranja> zahteviRenoviranja;
        public static RenoviranjeRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RenoviranjeRepozitorijum();

                }
                return _instance;
            }
        }

        private RenoviranjeRepozitorijum()
        {
            zahteviRenoviranja = new ObservableCollection<ZahtevRenoviranja>();
        }

        public int Sacuvaj()
        {
            string lokacija = @"..\..\..\Data\zahteviRenoviranja.json";
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, zahteviRenoviranja);
            jWriter.Close();
            writer.Close();
            return 1;
        }

    }
}
