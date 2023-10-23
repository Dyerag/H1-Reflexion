using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaldursStarGate2dot0
{
    internal class Io
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void Save<T>(T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            //todo try-catch
            using (StreamWriter writer = new StreamWriter(Path.Combine(path, $"{obj.GetType()}.json")))
            {
                writer.WriteLine(json);
            }
        }

        public static T? Load<T>()
        {
            string file = Path.Combine(path, $"{typeof(T)}.json");
            //Prevention before exception
            if (!File.Exists(file)) return default(T);

            //todo try-catch
            string json;
            using (StreamReader reader = new StreamReader(Path.Combine(path, file)))
            {
                json = reader.ReadToEnd();
            }
            T? pc = JsonSerializer.Deserialize<T>(json);
            return pc;
        }
    }
}