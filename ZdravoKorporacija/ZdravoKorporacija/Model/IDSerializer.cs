using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZdravoKorporacija.Model
{
    class IDSerializer
    {

        private string lokacija;
        public IDSerializer(string nazivID)
        {
            this.lokacija = @"..\..\..\Data\"+nazivID +".json";
        }

    public void UpisivanjeUFajl(Dictionary<int, int> id_map)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;
        StreamWriter writer = new StreamWriter(lokacija);
        JsonWriter jWriter = new JsonTextWriter(writer);
        serializer.Serialize(jWriter, id_map);
        jWriter.Close();
        writer.Close();
    }
    public Dictionary<int, int> CitanjeIzFajla()
    {
        Dictionary<int, int> id_map = new Dictionary<int, int>();
        if (File.Exists(lokacija))
        {
            string jsonText = File.ReadAllText(lokacija);
            if (!string.IsNullOrEmpty(jsonText))
            {
                    id_map = JsonConvert.DeserializeObject<Dictionary<int, int>>(jsonText);
            }
        }
        return id_map;
    }
}
}
