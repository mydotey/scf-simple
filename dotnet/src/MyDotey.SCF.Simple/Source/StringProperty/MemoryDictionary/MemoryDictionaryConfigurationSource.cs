using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace MyDotey.SCF.Source.StringProperty.MemoryDictionary
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     * 
     * all properties stored in a memory concurrent Dictionary
     * 
     * dynamic source
     */
    public class MemoryDictionaryConfigurationSource : StringPropertyConfigurationSource<ConfigurationSourceConfig>
    {
        private ConcurrentDictionary<string, string> _properties;

        public MemoryDictionaryConfigurationSource(ConfigurationSourceConfig config)
            : base(config)
        {
            _properties = new ConcurrentDictionary<string, string>();
        }

        public override string GetPropertyValue(string key)
        {
            _properties.TryGetValue(key, out string value);
            return value;
        }

        public virtual void SetPropertyValue(string key, string value)
        {
            _properties.TryGetValue(key, out string oldValue);
            if (Object.Equals(oldValue, value))
                return;

            if (value == null)
                _properties.TryRemove(key, out value);
            else
                _properties[key] = value;

            RaiseChangeEvent();
        }

        public virtual void SetProperties(Dictionary<string, string> properties)
        {
            foreach (KeyValuePair<string, string> p in properties)
                _properties[p.Key] = p.Value;

            RaiseChangeEvent();
        }
    }
}