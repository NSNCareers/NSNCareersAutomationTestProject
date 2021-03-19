using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace CoreFramework.Config
{
    public static class JsonConfig
    {
        private static IConfiguration _configuration { get; set; }

        public static string GetJsonValue(string key)
        {
            string value = string.Empty;
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var builder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("appConfig.json").Build();
                value = builder[key];             
            }
            catch (Exception e)
            {
                throw e;
            }

            return value;
        }
    }
}
