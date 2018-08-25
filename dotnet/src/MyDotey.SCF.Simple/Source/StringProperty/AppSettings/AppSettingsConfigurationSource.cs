using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace MyDotey.SCF.Source.StringProperty.AppSettings
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     * 
     * Use System.getenv to get environment variables
     * 
     * non-dynamic source
     */
    public class AppSettingsConfigurationSource : StringPropertyConfigurationSource<AppSettingsConfigurationSourceConfig>
    {
        private IConfigurationRoot _appSettings;

        public AppSettingsConfigurationSource(AppSettingsConfigurationSourceConfig config)
            : base(config)
        {
            if (config.Type == AppSettingsType.AppSettingsJson)
            {
                _appSettings = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
                    .Build();
            }
        }

        public override string GetPropertyValue(string key)
        {
            return Config.Type == AppSettingsType.AppSettingsJson ?
                _appSettings[key] : ConfigurationManager.AppSettings[key];
        }
    }
}