package org.mydotey.scf.source.stringproperty.propertiesfile;

import org.junit.Assert;
import org.junit.Test;
import org.mydotey.scf.ConfigurationManager;
import org.mydotey.scf.ConfigurationManagerConfig;
import org.mydotey.scf.Property;
import org.mydotey.scf.facade.ConfigurationManagers;
import org.mydotey.scf.facade.StringProperties;
import org.mydotey.scf.facade.StringPropertySources;
import org.mydotey.scf.source.FileSourceType;

/**
 * @author koqizhao
 *
 * May 22, 2018
 */
public class PropertiesFileConfigurationSourceTest {

    protected ConfigurationManager createManager(String fileName) {
        PropertiesFileConfigurationSourceConfig sourceConfig = StringPropertySources
                .newPropertiesFileSourceConfigBuilder().setName("properties-source").setFileName(fileName)
                .setType(FileSourceType.LOCAL_SYSTEM).build();
        System.out.println("source config: " + sourceConfig + "\n");
        ConfigurationManagerConfig managerConfig = ConfigurationManagers.newConfigBuilder().setName("test")
                .addSource(1, StringPropertySources.newPropertiesFileSource(sourceConfig)).build();
        System.out.println("manager config: " + managerConfig + "\n");
        return ConfigurationManagers.newManager(managerConfig);
    }

    protected StringProperties createStringProperties(String fileName) {
        ConfigurationManager manager = createManager(fileName);
        return new StringProperties(manager);
    }

    @Test
    public void testGetProperties() {
        StringProperties stringProperties = createStringProperties("test.properties");
        Property<String, String> property = stringProperties.getStringProperty("not-exist");
        System.out.println("property: " + property + "\n");
        Assert.assertEquals(null, property.getValue());

        property = stringProperties.getStringProperty("not-exist2", "default");
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("default", property.getValue());

        property = stringProperties.getStringProperty("local-system-exist", "default");
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok", property.getValue());
    }

}
