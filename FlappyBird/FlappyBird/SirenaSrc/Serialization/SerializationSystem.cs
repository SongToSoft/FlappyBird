using System.IO;
using System.Runtime.Serialization.Json;

namespace SirenaEngineMG.SirenaSrc.Serialization
{
    static class SerializationSystem
    {
        public static void SaveValue<T>(T value)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream("highScore.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, value);
            }
        }

        public static T GetValue<T>(string fileName)
        {
            T value = default;
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
                    value = (T)jsonFormatter.ReadObject(fs);
                }
            }
            return value;
        }
    }
}
