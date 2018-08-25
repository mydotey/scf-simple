using System;

using MyDotey.SCF.Source.StringProperty;
using MyDotey.SCF.Source.StringProperty.AppSettings;
using MyDotey.SCF.Source.StringProperty.Cascaded;
using MyDotey.SCF.Source.StringProperty.EnvironmentVariable;
using MyDotey.SCF.Source.StringProperty.MemoryDictionary;
using MyDotey.SCF.Source.StringProperty.PropertiesFile;

namespace MyDotey.SCF.Facade
{
    /**
     * @author koqizhao
     *
     * May 22, 2018
     */
    public class StringPropertySources
    {
        protected StringPropertySources()
        {

        }

        public static AppSettingsConfigurationSourceConfig.Builder NewAppSettingsSourceConfigBuilder()
        {
            return new AppSettingsConfigurationSourceConfig.Builder();
        }

        public static AppSettingsConfigurationSource NewAppSettingsSource(AppSettingsConfigurationSourceConfig config)
        {
            return new AppSettingsConfigurationSource(config);
        }

        public static EnvironmentVariableConfigurationSource NewEnvironmentVariableSource(string name)
        {
            ConfigurationSourceConfig config = ConfigurationSources.NewConfig(name);
            return new EnvironmentVariableConfigurationSource(config);
        }

        public static MemoryDictionaryConfigurationSource NewMemoryDictionarySource(string name)
        {
            ConfigurationSourceConfig config = ConfigurationSources.NewConfig(name);
            return new MemoryDictionaryConfigurationSource(config);
        }

        public static PropertiesFileConfigurationSourceConfig.Builder NewPropertiesFileSourceConfigBuilder()
        {
            return new PropertiesFileConfigurationSourceConfig.Builder();
        }

        public static PropertiesFileConfigurationSource NewPropertiesFileSource(
                PropertiesFileConfigurationSourceConfig config)
        {
            return new PropertiesFileConfigurationSource(config);
        }

        public static CascadedConfigurationSourceConfig<C>.Builder NewCascadedSourceConfigBuilder<C>()
            where C : ConfigurationSourceConfig
        {
            return new CascadedConfigurationSourceConfig<C>.Builder();
        }

        public static CascadedConfigurationSource<C> NewCascadedSource<C>(CascadedConfigurationSourceConfig<C> config)
            where C : ConfigurationSourceConfig
        {
            return new CascadedConfigurationSource<C>(config);
        }
    }
}