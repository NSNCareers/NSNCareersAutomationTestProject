using Newtonsoft.Json;
using System.IO;

namespace CoreFramework.JsonReader
{
    public static class GetJson
    {

        public static JsonClass GetJsonString()
        {
        
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string replaceBin = path.Replace(@"\bin","");
            var path1 = $@"{replaceBin}\appConfig.json";

            using (StreamReader file = File.OpenText(path1))
            {
                JsonSerializer serializer = new JsonSerializer();
                JsonClass obj = (JsonClass)serializer.Deserialize(file,typeof(JsonClass));

                return obj;
            }
        }
    }
}
