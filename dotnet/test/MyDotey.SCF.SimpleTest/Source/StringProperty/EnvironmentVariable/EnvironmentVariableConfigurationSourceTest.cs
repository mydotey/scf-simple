using System;

using Xunit;
using MyDotey.SCF.Facade;

namespace MyDotey.SCF.Source.StringProperty.EnvironmentVariable
{
    /**koqizhao
     * @author 
     *
     * May 22, 2018
     */
    public class EnvironmentVariableConfigurationSourceTest
    {
        protected virtual IConfigurationManager CreateManager()
        {
            ConfigurationManagerConfig managerConfig = ConfigurationManagers.NewConfigBuilder().SetName("test")
                    .AddSource(1, StringPropertySources.NewEnvironmentVariableSource("environment-variable")).Build();
            Console.WriteLine("manager config: " + managerConfig + "\n");
            return ConfigurationManagers.NewManager(managerConfig);
        }

        [Fact]
        public virtual void TestGetProperties()
        {
            IConfigurationManager manager = CreateManager();
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

            propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>().SetKey("PATH")
                    .SetDefaultValue("default").Build();
            property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.NotNull(property.Value);
            Assert.NotEqual("default", property.Value);
        }
    }
}