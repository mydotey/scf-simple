package org.mydotey.scf.source.stringproperty.propertiesfile;

import org.mydotey.scf.DefaultConfigurationSourceConfig;
import org.mydotey.scf.source.FileSourceType;

/**
 * @author koqizhao
 *
 * May 17, 2018
 */
public class PropertiesFileConfigurationSourceConfig extends DefaultConfigurationSourceConfig {

    private String _fileName;
    private FileSourceType _type;

    protected PropertiesFileConfigurationSourceConfig() {

    }

    public String getFileName() {
        return _fileName;
    }

    public FileSourceType getType() {
        return _type;
    }

    @Override
    public String toString() {
        return String.format("%s { name: %s, fileName: %s, type: %s }", getClass().getSimpleName(), getName(),
            getFileName(), getType());
    }

    public static class Builder extends
            DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, PropertiesFileConfigurationSourceConfig> {

        @Override
        protected PropertiesFileConfigurationSourceConfig newConfig() {
            return new PropertiesFileConfigurationSourceConfig();
        }

        public Builder setFileName(String fileName) {
            getConfig()._fileName = fileName;
            return this;
        }

        public Builder setType(FileSourceType type) {
            getConfig()._type = type;
            return this;
        }

        @Override
        public PropertiesFileConfigurationSourceConfig build() {
            if (getConfig().getFileName() == null || getConfig().getFileName().trim().isEmpty())
                throw new IllegalArgumentException("fileName is null or empty");

            getConfig()._fileName = getConfig()._fileName.trim();
            if (!getConfig()._fileName.endsWith(".properties"))
                getConfig()._fileName += ".properties";

            if (getConfig().getType() == null)
                getConfig()._type = FileSourceType.CLASS_PATH;

            return super.build();
        }

    }

}
