using System;

using Xunit;
using MyDotey.SCF.Facade;

namespace MyDotey.SCF.Source.StringProperty.CommandLine
{
    /**koqizhao
     * @author 
     *
     * May 22, 2018
     */
    public class CommandLineVariableConfigurationSourceTest
    {
        protected virtual IConfigurationManager CreateManager(string[] commandLineArgs)
        {
            CommandLineConfigurationSourceConfig sourceConfig = StringPropertySources.NewCommandLineSourceConfigBuilder()
                .SetName("commandline").SetCommandLineArgs(commandLineArgs).Build();
            CommandLineConfigurationSource source = StringPropertySources.NewCommandLineSource(sourceConfig);
            ConfigurationManagerConfig managerConfig = ConfigurationManagers.NewConfigBuilder().SetName("test")
                    .AddSource(1, source).Build();
            Console.WriteLine("manager config: " + managerConfig + "\n");
            return ConfigurationManagers.NewManager(managerConfig);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("exist=ok")]
        public virtual void TestGetProperties(string kv)
        {
            string[] commandLineArgs = kv == null ? null : new string[] { kv };
            IConfigurationManager manager = CreateManager(commandLineArgs);
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

            if (commandLineArgs == null)
                return;

            propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>().SetKey("exist")
                    .SetDefaultValue("default").Build();
            property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);
        }
    }
}