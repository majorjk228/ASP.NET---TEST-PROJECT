using Newtonsoft.Json;

namespace TEST_TPLUS.Domain.Entities
{
    public class JsonOpertaions<T>
    {
            //Чтение из JSON
            public static T Reads(string file) =>
                    JsonConvert.DeserializeObject<T>(File.ReadAllText(file));

            //Запись в JSON
            public static string Write(object root) =>
                    JsonConvert.SerializeObject(root, Formatting.Indented);

    }
}
