using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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
        public virtual string KeySeparator { get; private set; }
        public virtual IList<string> CascadedFactors { get; private set; }
        public virtual StringPropertyConfigurationSource<C> Source { get; private set; }

        protected CascadedConfigurationSourceConfig()
        {

        }

        public override object Clone()
        {
            CascadedConfigurationSourceConfig<C> copy = (CascadedConfigurationSourceConfig<C>)base.Clone();
            if (CascadedFactors != null)
                copy.CascadedFactors = ImmutableList.CreateRange(CascadedFactors);
            return copy;
        }

        public override string ToString()
        {
            return string.Format("{0} {{ name: {1}, keySeparator: {2}, cascadedFactors: [ {3} ], source {4} }}", GetType().Name,
                Name, KeySeparator, CascadedFactors == null ? null : string.Join(", ", CascadedFactors), Source);
        }

        public new class Builder : DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, CascadedConfigurationSourceConfig<C>>
        {
            protected override CascadedConfigurationSourceConfig<C> NewConfig()
            {
                return new CascadedConfigurationSourceConfig<C>();
            }

            public virtual Builder SetKeySeparator(string keySeparator)
            {
                Config.KeySeparator = keySeparator;
                return this;
            }

            public virtual Builder AddCascadedFactor(string cascadedFactor)
            {
                if (string.IsNullOrWhiteSpace(cascadedFactor))
                    return this;

                cascadedFactor = cascadedFactor.Trim();
                if (Config.CascadedFactors == null)
                    Config.CascadedFactors = new List<string>();
                Config.CascadedFactors.Add(cascadedFactor);

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
                Config.Source = source;

                return this;
            }

            public override CascadedConfigurationSourceConfig<C> Build()
            {
                if (string.IsNullOrWhiteSpace(Config.KeySeparator))
                    throw new ArgumentNullException("keySeparator is null or whitespace");
                Config.KeySeparator = Config.KeySeparator.Trim();

                if (Config.CascadedFactors == null || Config.CascadedFactors.Count == 0)
                    throw new ArgumentNullException("cascadedFactors is null or empty");

                if (Config.Source == null)
                    throw new ArgumentNullException("source is null");

                return base.Build();
            }
        }
    }
}