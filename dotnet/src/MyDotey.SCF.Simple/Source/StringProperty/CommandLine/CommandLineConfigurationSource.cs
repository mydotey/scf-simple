using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;

namespace MyDotey.SCF.Source.StringProperty.CommandLine
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
    public class CommandLineConfigurationSource : StringPropertyConfigurationSource<CommandLineConfigurationSourceConfig>
    {
        private IConfigurationRoot _appSettings;

        public CommandLineConfigurationSource(CommandLineConfigurationSourceConfig config)
            : base(config)
        {
            if (config.CommandLineArgs != null)
                _appSettings = new ConfigurationBuilder().AddCommandLine(config.CommandLineArgs).Build();
        }

        public override string GetPropertyValue(string key)
        {
            return _appSettings == null ? null : _appSettings[key];
        }
    }
}