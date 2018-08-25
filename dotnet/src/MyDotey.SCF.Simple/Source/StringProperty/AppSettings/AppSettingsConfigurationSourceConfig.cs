using System;

namespace MyDotey.SCF.Source.StringProperty.AppSettings
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     */
    public class AppSettingsConfigurationSourceConfig : DefaultConfigurationSourceConfig
    {
        public virtual AppSettingsType Type { get; private set; }

        protected AppSettingsConfigurationSourceConfig()
        {

        }

        public override String ToString()
        {
            return String.Format ("{0} {{ name: {1}, type: {2} }}", GetType ().Name, Name, Type);
        }

        public new class Builder
            : DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, AppSettingsConfigurationSourceConfig>
        {
            protected override AppSettingsConfigurationSourceConfig NewConfig()
            {
                return new AppSettingsConfigurationSourceConfig ();
            }

            public virtual Builder SetType(AppSettingsType type)
            {
                Config.Type = type;
                return this;
            }

            public override AppSettingsConfigurationSourceConfig Build()
            {
                return base.Build();
            }
        }
    }

    public enum AppSettingsType
    {
        // for App.config
        AppConfig,
        // for appsettings.json
        AppSettingsJson
    }
}