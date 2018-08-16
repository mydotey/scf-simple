package org.mydotey.scf.source.stringproperty.systemproperties;

import java.util.Objects;
import java.util.Properties;

import org.mydotey.scf.ConfigurationSourceConfig;
import org.mydotey.scf.source.stringproperty.StringPropertyConfigurationSource;

/**
 * @author koqizhao
 *
 * May 17, 2018
 * 
 * Use System.getProperty to get system properties, System.setProperty to change property
 * 
 * dynamic source
 */
public class SystemPropertiesConfigurationSource extends StringPropertyConfigurationSource<ConfigurationSourceConfig> {

    public SystemPropertiesConfigurationSource(ConfigurationSourceConfig config) {
        super(config);
    }

    @Override
    public String getPropertyValue(String key) {
        return System.getProperty(key);
    }

    public void setProperty(String key, String value) {
        String oldValue = System.getProperty(key);
        if (Objects.equals(oldValue, value))
            return;

        System.setProperty(key, value);
        raiseChangeEvent();
    }

    public void setProperties(Properties properties) {
        System.setProperties(properties);

        raiseChangeEvent();
    }

    public String clearProperty(String key) {
        String value = System.clearProperty(key);
        if (value != null)
            raiseChangeEvent();

        return value;
    }

}
