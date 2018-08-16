using System;
using System.Collections.Generic;

namespace MyDotey.SCF.Source.StringProperty.Cascaded
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     */
    public class CascadedConfigurationSourceConfig<C> : DefaultConfigurationSourceConfig
        where C : ConfigurationSourceConfig
    {
        private string _keySeparator;
        private List<string> _cascadedFactors;
        private StringPropertyConfigurationSource<C> _source;

        protected CascadedConfigurationSourceConfig()
        {

        }

        public virtual string KeySeparator { get { return _keySeparator; } }

        public virtual List<string> CascadedFactors { get { return _cascadedFactors; } }

        public virtual StringPropertyConfigurationSource<C> Source { get { return _source; } }

        public override object Clone()
        {
            CascadedConfigurationSourceConfig<C> copy = (CascadedConfigurationSourceConfig<C>)base.Clone();
            if (_cascadedFactors != null)
                copy._cascadedFactors = new List<string>(_cascadedFactors);
            return copy;
        }

        public override string ToString()
        {
            return string.Format("{0} {{ name: {1}, keySeparator: {2}, cascadedFactors: [ {3} ], source {4} }}", GetType().Name,
                Name, _keySeparator, _cascadedFactors == null ? null : string.Join(", ", _cascadedFactors), _source);
        }

        public new class Builder : DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, CascadedConfigurationSourceConfig<C>>
        {
            protected override CascadedConfigurationSourceConfig<C> NewConfig()
            {
                return new CascadedConfigurationSourceConfig<C>();
            }

            public virtual Builder SetKeySeparator(string keySeparator)
            {
                Config._keySeparator = keySeparator;
                return this;
            }

            public virtual Builder AddCascadedFactor(string cascadedFactor)
            {
                if (string.IsNullOrWhiteSpace(cascadedFactor))
                    return this;

                cascadedFactor = cascadedFactor.Trim();
                if (Config._cascadedFactors == null)
                    Config._cascadedFactors = new List<string>();
                Config._cascadedFactors.Add(cascadedFactor);

                return this;
            }

            public virtual Builder AddCascadedFactors(List<string> cascadedFactors)
            {
                if (cascadedFactors != null)
                    cascadedFactors.ForEach(f => AddCascadedFactor(f));

                return this;
            }

            public virtual Builder SetSource(StringPropertyConfigurationSource<C> source)
            {
                Config._source = source;

                return this;
            }

            public override CascadedConfigurationSourceConfig<C> Build()
            {
                if (string.IsNullOrWhiteSpace(Config._keySeparator))
                    throw new ArgumentNullException("keySeparator is null or whitespace");
                Config._keySeparator = Config._keySeparator.Trim();

                if (Config._cascadedFactors == null || Config._cascadedFactors.Count == 0)
                    throw new ArgumentNullException("cascadedFactors is null or empty");

                if (Config._source == null)
                    throw new ArgumentNullException("source is null");

                return base.Build();
            }
        }
    }
}