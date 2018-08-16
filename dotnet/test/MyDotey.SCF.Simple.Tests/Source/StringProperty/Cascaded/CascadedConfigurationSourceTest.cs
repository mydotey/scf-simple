using System;
using System.Threading;

using Xunit;
using MyDotey.SCF.Facade;
using MyDotey.SCF.Threading;
using MyDotey.SCF.Source.StringProperty.MemoryDictionary;

namespace MyDotey.SCF.Source.StringProperty.Cascaded
{
    /**
     * @author koqizhao
     *
     * May 22, 2018
     */
    public class CascadedConfigurationSourceTest
    {
        protected virtual MemoryDictionaryConfigurationSource CreateSource()
        {
            return StringPropertySources.NewMemoryDictionarySource("memory-map");
        }

        protected virtual IConfigurationManager CreateManager(MemoryDictionaryConfigurationSource source)
        {
            CascadedConfigurationSourceConfig<ConfigurationSourceConfig> sourceConfig = StringPropertySources.NewCascadedSourceConfigBuilder<ConfigurationSourceConfig>()
                    .SetName("cascaded-memory-map").SetKeySeparator(".").AddCascadedFactor("part1")
                    .AddCascadedFactor("part2").SetSource(source).Build();
            CascadedConfigurationSource<ConfigurationSourceConfig> cascadedSource = StringPropertySources.NewCascadedSource<ConfigurationSourceConfig>(sourceConfig);
            TaskExecutor taskExecutor = new TaskExecutor();
            ConfigurationManagerConfig managerConfig = ConfigurationManagers.NewConfigBuilder().SetName("test")
                    .AddSource(1, cascadedSource).SetTaskExecutor(taskExecutor.Run).Build();
            Console.WriteLine("manager config: " + managerConfig + "\n");
            return ConfigurationManagers.NewManager(managerConfig);
        }

        protected virtual IConfigurationManager CreateKeyCachedManager(MemoryDictionaryConfigurationSource source)
        {
            CascadedConfigurationSourceConfig<ConfigurationSourceConfig> sourceConfig = StringPropertySources.NewCascadedSourceConfigBuilder<ConfigurationSourceConfig>()
                    .SetName("cascaded-memory-map").SetKeySeparator(".").AddCascadedFactor("part1")
                    .AddCascadedFactor("part2").SetSource(source).Build();
            CascadedConfigurationSource<ConfigurationSourceConfig> cascadedSource = new KeyCachedCascadedConfigurationSource<ConfigurationSourceConfig>(sourceConfig);
            TaskExecutor taskExecutor = new TaskExecutor();
            ConfigurationManagerConfig managerConfig = ConfigurationManagers.NewConfigBuilder().SetName("test")
                    .AddSource(1, cascadedSource).SetTaskExecutor(taskExecutor.Run).Build();
            Console.WriteLine("manager config: " + managerConfig + "\n");
            return ConfigurationManagers.NewManager(managerConfig);
        }

        [Fact]
        public virtual void TestGetProperties()
        {
            MemoryDictionaryConfigurationSource source = CreateSource();
            source.SetPropertyValue("exist", "ok");

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
            source.SetPropertyValue("exist", "ok");

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

            source.SetPropertyValue("exist", "ok3");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok3", property.Value);

            source.SetPropertyValue("exist", "ok4");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok4", property.Value);
        }

        [Fact]
        public virtual void TestCascadedProperty()
        {
            MemoryDictionaryConfigurationSource source = CreateSource();
            source.SetPropertyValue("exist", "ok");

            IConfigurationManager manager = CreateManager(source);

            PropertyConfig<String, String> propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>()
                         .SetKey("exist").SetDefaultValue("default").Build();
            IProperty<String, String> property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);

            source.SetPropertyValue("exist.part1", "ok1");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok1", property.Value);

            source.SetPropertyValue("exist.part1.part2", "ok2");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok2", property.Value);

            source.SetPropertyValue("exist", null);
            source.SetPropertyValue("exist.part1.part2", null);
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok1", property.Value);
        }

        [Fact]
        public virtual void TestKeyCachedCascadedProperty()
        {
            MemoryDictionaryConfigurationSource source = CreateSource();
            source.SetPropertyValue("exist", "ok");

            IConfigurationManager manager = CreateKeyCachedManager(source);

            PropertyConfig<String, String> propertyConfig = ConfigurationProperties.NewConfigBuilder<String, String>()
                         .SetKey("exist").SetDefaultValue("default").Build();
            IProperty<String, String> property = manager.GetProperty(propertyConfig);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok", property.Value);

            source.SetPropertyValue("exist.part1", "ok1");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok1", property.Value);

            source.SetPropertyValue("exist.part1.part2", "ok2");
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok2", property.Value);

            source.SetPropertyValue("exist", null);
            source.SetPropertyValue("exist.part1.part2", null);
            Thread.Sleep(10);
            Console.WriteLine("property: " + property + "\n");
            Assert.Equal("ok1", property.Value);
        }
    }
}