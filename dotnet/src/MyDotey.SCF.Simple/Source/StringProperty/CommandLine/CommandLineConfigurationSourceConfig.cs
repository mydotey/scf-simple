using System;

namespace MyDotey.SCF.Source.StringProperty.CommandLine
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     */
    public class CommandLineConfigurationSourceConfig : DefaultConfigurationSourceConfig
    {
        public virtual string[] CommandLineArgs { get; private set; }

        protected CommandLineConfigurationSourceConfig()
        {

        }

        public override String ToString()
        {
            return String.Format ("{0} {{ name: {1}, args: {2} }}", GetType ().Name, Name, CommandLineArgs);
        }

        public new class Builder
            : DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, CommandLineConfigurationSourceConfig>
        {
            protected override CommandLineConfigurationSourceConfig NewConfig()
            {
                return new CommandLineConfigurationSourceConfig ();
            }

            public virtual Builder SetCommandLineArgs(string[] commandLineArgs)
            {
                Config.CommandLineArgs = commandLineArgs;
                return this;
            }

            public override CommandLineConfigurationSourceConfig Build()
            {
                if (Config.CommandLineArgs == null)
                    Config.CommandLineArgs = Environment.GetCommandLineArgs();

                return base.Build();
            }
        }
    }

    public enum CommandLineType
    {
        // for App.config
        AppConfig,
        // for appsettings.json
        CommandLineJson
    }
}