using System;
using System.Threading;

using Xunit;
using MyDotey.SCF.Facade;
using MyDotey.SCF.Threading;

namespace MyDotey.SCF.Source.StringProperty.MemoryDictionary
{
    /**
     * @author koqizhao
     *
     * May 22, 2018
     */
    public class MemoryDictionaryConfigurationSourceTest
    {
        protected virtual MemoryDictionaryConfigurationSource CreateSource()
        {
            MemoryDictionaryConfigurationSource source = StringPropertySources.NewMemoryDictionarySource("memory-map");
            source.SetPropertyValue("exist", "ok");
            return source;
        }

        protected virtual IConfigurationManager CreateManager(MemoryDictionaryConfigurationSource source)
        {
            ConfigurationManagerConfig managerConfig = ConfigurationManagers.NewConfigBuilder().SetName("test")
                    .AddSource(1, source).SetTaskExecutor(new TaskExecutor().Run).Build();
            Console.WriteLine("manager config: " + managerConfig + "\n");
            return ConfigurationManagers.NewManager(managerConfig);
        }

        [Fact]
        public virtual void TestGetProperties()
        {
            MemoryDictionaryConfigurationSource source = CreateSource();
            IConfigurationManager manager = CreateManager(source);
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

            propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>().SetKey("exist")
                    .SetDefaultValue("default").Build();
            property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);

            source.SetPropertyValue("exist", "ok2");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok2", property.Value);
        }

        [Fact]
        public virtual void TestDynamicProperty()
        {
            MemoryDictionaryConfigurationSource source = CreateSource();
            IConfigurationManager manager = CreateManager(source);
            PropertyConfig<String, String> propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>()
                    .SetKey("exist").SetDefaultValue("default").Build();
            IProperty<String, String> property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);

            source.SetPropertyValue("exist", "ok2");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok2", property.Value);

            source.SetPropertyValue("exist", "ok");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);

            source.SetPropertyValue("exist", null);
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("default", property.Value);
        }
    }
}