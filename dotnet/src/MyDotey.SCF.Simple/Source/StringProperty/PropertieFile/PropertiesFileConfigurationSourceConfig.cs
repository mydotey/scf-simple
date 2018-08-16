using System;

namespace MyDotey.SCF.Source.StringProperty.PropertiesFile
{
    /**
     * @author koqizhao
     *
     * May 17, 2018
     */
    public class PropertiesFileConfigurationSourceConfig : DefaultConfigurationSourceConfig
    {
        public virtual String FileName { get; private set; }

        protected PropertiesFileConfigurationSourceConfig()
        {

        }

        public override String ToString()
        {
            return String.Format("{0} {{ name: {1}, fileName: {2} }}", GetType().Name, Name, FileName);
        }

        public new class Builder
            : DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, PropertiesFileConfigurationSourceConfig>
        {
            protected override PropertiesFileConfigurationSourceConfig NewConfig()
            {
                return new PropertiesFileConfigurationSourceConfig();
            }

            public virtual Builder SetFileName(String fileName)
            {
                Config.FileName = fileName;
                return this;
            }

            public override PropertiesFileConfigurationSourceConfig Build()
            {
                if (string.IsNullOrWhiteSpace(Config.FileName))
                    throw new ArgumentNullException("fileName is null or empty");

                Config.FileName = Config.FileName.Trim();
                if (!Config.FileName.EndsWith(".properties"))
                    Config.FileName += ".properties";

                return base.Build();
            }
        }
    }
}