package org.mydotey.scf.source.stringproperty.memorymap;

import java.util.Map;
import org.junit.Assert;
import org.junit.Test;
import org.mydotey.scf.ConfigurationManager;
import org.mydotey.scf.ConfigurationManagerConfig;
import org.mydotey.scf.Property;
import org.mydotey.scf.PropertyConfig;
import org.mydotey.scf.facade.ConfigurationManagers;
import org.mydotey.scf.facade.ConfigurationProperties;
import org.mydotey.scf.facade.StringProperties;
import org.mydotey.scf.facade.SimpleConfigurationSources;
import org.mydotey.scf.threading.TaskExecutor;

import com.google.common.collect.ImmutableMap;

/**
 * @author koqizhao
 *
 *         May 22, 2018
 */
public class MemoryMapConfigurationSourceTest {

    protected MemoryMapConfigurationSource createSource() {
        MemoryMapConfigurationSource source = SimpleConfigurationSources.newMemoryMapSource("memory-map");
        source.setPropertyValue("exist", "ok");
        return source;
    }

    protected ConfigurationManager createManager(MemoryMapConfigurationSource source) {
        ConfigurationManagerConfig managerConfig = ConfigurationManagers.newConfigBuilder().setName("test")
                .addSource(1, source).setTaskExecutor(new TaskExecutor(1)).build();
        System.out.println("manager config: " + managerConfig + "\n");
        return ConfigurationManagers.newManager(managerConfig);
    }

    @Test
    public void testGetProperties() throws InterruptedException {
        MemoryMapConfigurationSource source = createSource();
        ConfigurationManager manager = createManager(source);
        PropertyConfig<String, String> propertyConfig = ConfigurationProperties.<String, String> newConfigBuilder()
                .setKey("not-exist").setValueType(String.class).build();
        Property<String, String> property = manager.getProperty(propertyConfig);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals(null, property.getValue());

        propertyConfig = ConfigurationProperties.<String, String> newConfigBuilder().setKey("not-exist2")
                .setValueType(String.class).setDefaultValue("default").build();
        property = manager.getProperty(propertyConfig);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("default", property.getValue());

        propertyConfig = ConfigurationProperties.<String, String> newConfigBuilder().setKey("exist")
                .setValueType(String.class).setDefaultValue("default").build();
        property = manager.getProperty(propertyConfig);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok", property.getValue());

        source.setPropertyValue("exist", "ok2");
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok2", property.getValue());
    }

    @Test
    public void testDynamicProperty() throws InterruptedException {
        MemoryMapConfigurationSource source = createSource();
        ConfigurationManager manager = createManager(source);
        PropertyConfig<String, String> propertyConfig = ConfigurationProperties.<String, String> newConfigBuilder()
                .setKey("exist").setValueType(String.class).setDefaultValue("default").build();
        Property<String, String> property = manager.getProperty(propertyConfig);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok", property.getValue());

        source.setPropertyValue("exist", "ok2");
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok2", property.getValue());

        source.setPropertyValue("exist", "ok");
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok", property.getValue());

        source.setPropertyValue("exist", null);
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("default", property.getValue());
    }

    @Test
    public void testDynamicProperty2() throws InterruptedException {
        MemoryMapConfigurationSource source = createSource();
        ConfigurationManager manager = createManager(source);
        StringProperties StringProperties = new StringProperties(manager);
        Property<String, Map<String, String>> property = StringProperties.getMapProperty("map-value");
        System.out.println("property: " + property + "\n");
        Assert.assertNull(property.getValue());

        Map<String, String> mapValue = ImmutableMap.of("k1", "v1", "k2", "v2");
        source.setPropertyValue("map-value", "k1:v1,k2:v2");
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals(mapValue, property.getValue());
        Assert.assertNotSame(mapValue, property.getValue());

        mapValue = property.getValue();

        source.setPropertyValue("map-value", "k1:v1,k2:v2");
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertEquals(mapValue, property.getValue());
        Assert.assertSame(mapValue, property.getValue());

        source.setPropertyValue("map-value", "k3:v3,k4:v4");
        Thread.sleep(10);
        System.out.println("property: " + property + "\n");
        Assert.assertNotEquals(mapValue, property.getValue());
        Assert.assertNotSame(mapValue, property.getValue());
    }

}
