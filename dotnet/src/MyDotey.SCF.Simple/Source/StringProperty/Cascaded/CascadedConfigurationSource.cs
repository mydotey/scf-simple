using System;
using System.Collections.Generic;
using System.Text;

namespace MyDotey.SCF.Source.StringProperty.Cascaded
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     * 
     * allow casaded config like:
     *  key
     *  key.a
     *  key.a.b
     * priority:
     *  key.a.b &gt; k.a &gt; key
     */
    public class CascadedConfigurationSource<C> : StringPropertyConfigurationSource<CascadedConfigurationSourceConfig<C>>
        where C : ConfigurationSourceConfig
    {
        private StringPropertyConfigurationSource<C> _source;
        private List<string> _cascadedKeyParts;

        public CascadedConfigurationSource(CascadedConfigurationSourceConfig<C> config)
            : base(config)
        {
            _source = config.Source;
            _source.AddChangeListener(s => RaiseChangeEvent());

            Init();
        }

        protected virtual void Init()
        {
            _cascadedKeyParts = new List<string>();

            StringBuilder keyPart = new StringBuilder("");
            _cascadedKeyParts.Add(keyPart.ToString());
            foreach (string factor in Config.CascadedFactors)
            {
                keyPart.Append(Config.KeySeparator).Append(factor);
                _cascadedKeyParts.Add(keyPart.ToString());
            }

            _cascadedKeyParts.Reverse();
        }

        public override string GetPropertyValue(string key)
        {
            foreach (string keyPart in _cascadedKeyParts)
            {
                string cascadedKey = GetKey(key, keyPart);
                string value = _source.GetPropertyValue(cascadedKey);
                if (value != null)
                    return value;
            }

            return null;
        }

        /**
         * allow user to override
         * if the key count is limited, can cache the key and have less memory use
         * @param keyParts
         * @return property value
         */
        protected virtual string GetKey(params string[] keyParts)
        {
            if (keyParts == null)
                return null;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string part in keyParts)
                stringBuilder.Append(part);
            return stringBuilder.ToString();
        }
    }
}