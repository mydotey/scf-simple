using System;

namespace MyDotey.SCF.Source.StringProperty
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     */
    public abstract class StringPropertyConfigurationSource<C> : AbstractConfigurationSource<C>
        where C : ConfigurationSourceConfig
    {
        public StringPropertyConfigurationSource(C config)
            : base(config)
        {
        }

        protected override object GetPropertyValue(object key)
        {
            if (!(key is string))
                return null;

            return GetPropertyValue((string)key);
        }

        public abstract string GetPropertyValue(string key);
    }
}