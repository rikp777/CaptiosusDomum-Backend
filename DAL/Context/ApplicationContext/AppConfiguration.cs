using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DAL.Context.ApplicationContext
{
    public class AppConfiguration
    {
        //Get the connectionstring out of the appsettings.Json
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSettings = root.GetSection("ConnectionStrings:CaptiosusDomumDataBase");
            sqlConnectionString = appSettings.Value;
        }

        public string sqlConnectionString { get; set; }
    }
}
