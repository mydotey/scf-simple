using System;

namespace MyDotey.SCF.Source
{
    /**
     * @author koqizhao
     *
     * Jul 16, 2018
     * 
     * Nothing Done Configuration Source
     */
    public class NullConfigurationSource : IConfigurationSource
    {
        public static readonly NullConfigurationSource Instance = new NullConfigurationSource();

        private NullConfigurationSource()
        {

        }

        /**
         * always null
         */
        public V GetPropertyValue<K, V>(PropertyConfig<K, V> propertyConfig)
        {
            return default(V);
        }

        /**
         * config with name "null-configuration-source"
         */
        public ConfigurationSourceConfig Config { get { return NullConfigurationSourceConfig.Instance; } }

        /**
         * always ignore the listeners
         */
        public event EventHandler<IConfigurationSourceChangeEvent> OnChange
        {
            add
            {

            }

            remove
            {

            }
        }

        public override string ToString()
        {
            return NullConfigurationSourceConfig.Instance.Name;
        }

        private class NullConfigurationSourceConfig : ConfigurationSourceConfig
        {
            public static readonly NullConfigurationSourceConfig Instance = new NullConfigurationSourceConfig();

            private NullConfigurationSourceConfig()
            {

            }

            public override string Name { get { return "null-configuration-source"; } }
        }
    }
}