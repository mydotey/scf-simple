using System;
using System.Configuration;

using Xunit;
using MyDotey.SCF.Facade;

namespace MyDotey.SCF.Source.StringProperty.AppSettings
{
    /**koqizhao
     * @author 
     *
     * May 22, 2018
     */
    public class AppSettingsVariableConfigurationSourceTest
    {
        protected virtual IConfigurationManager CreateManager(AppSettingsType type)
        {
            AppSettingsConfigurationSourceConfig sourceConfig = StringPropertySources.NewAppSettingsSourceConfigBuilder()
                .SetName("appsettings").SetType(type).Build();
            AppSettingsConfigurationSource source = StringPropertySources.NewAppSettingsSource(sourceConfig);
            ConfigurationManagerConfig managerConfig = ConfigurationManagers.NewConfigBuilder().SetName("test")
                    .AddSource(1, source).Build();
            Console.WriteLine("manager config: " + managerConfig + "\n");
            return ConfigurationManagers.NewManager(managerConfig);
        }

        [Theory]
        [InlineData(AppSettingsType.AppConfig)]
        [InlineData(AppSettingsType.AppSettingsJson)]
        public virtual void TestGetProperties(AppSettingsType type)
        {
            String propertyValue = ConfigurationManager.AppSettings["not-exist"];
            Assert.Null(propertyValue);

            IConfigurationManager manager = CreateManager(type);
            PropertyConfig<String, String> propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>()
                    .SetKey("not-exist").Build();
            IProperty<String, String> property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Null(property.Value);

            propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>().SetKey("not-exist2")
                    .SetDefaultValue("default").Build();
            property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("default", property.Value);

            if (type == AppSettingsType.AppConfig)
                return;

            propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>().SetKey("exist")
                    .SetDefaultValue("default").Build();
            property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);
        }
    }
}