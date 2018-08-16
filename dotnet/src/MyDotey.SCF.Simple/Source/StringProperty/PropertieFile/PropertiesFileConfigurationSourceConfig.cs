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
        private String _fileName;

        protected PropertiesFileConfigurationSourceConfig()
        {

        }

        public virtual String FileName { get { return _fileName; } }

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
                Config._fileName = fileName;
                return this;
            }

            public override PropertiesFileConfigurationSourceConfig Build()
            {
                if (string.IsNullOrWhiteSpace(Config._fileName))
                    throw new ArgumentNullException("fileName is null or empty");

                Config._fileName = Config._fileName.Trim();
                if (!Config._fileName.EndsWith(".properties"))
                    Config._fileName += ".properties";

                return base.Build();
            }
        }
    }
}