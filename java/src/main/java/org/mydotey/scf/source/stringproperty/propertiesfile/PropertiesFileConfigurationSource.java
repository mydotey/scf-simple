package org.mydotey.scf.source.stringproperty.propertiesfile;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

import org.mydotey.scf.source.stringproperty.StringPropertyConfigurationSource;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * @author koqizhao
 *
 * May 17, 2018
 */
public class PropertiesFileConfigurationSource
        extends StringPropertyConfigurationSource<PropertiesFileConfigurationSourceConfig> {

    private static final Logger LOGGER = LoggerFactory.getLogger(PropertiesFileConfigurationSource.class);

    private Properties _properties;

    public PropertiesFileConfigurationSource(PropertiesFileConfigurationSourceConfig config) {
        super(config);

        _properties = new Properties();
        try (InputStream is = loadFile(config.getFileName())) {
            if (is == null) {
                LOGGER.warn("file not found: {}", config);
                return;
            }

            _properties.load(is);
        } catch (Exception e) {
            LOGGER.warn("failed to load properties file: " + config, e);
        }
    }

    protected InputStream loadFile(String fileName) throws IOException {
        return Thread.currentThread().getContextClassLoader().getResourceAsStream(fileName);
    }

    @Override
    public String getPropertyValue(String key) {
        if (_properties == null)
            return null;

        return _properties.getProperty(key);
    }

}
