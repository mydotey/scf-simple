package org.mydotey.scf.facade;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.junit.Assert;
import org.junit.Test;
import org.mydotey.scf.ConfigurationManager;
import org.mydotey.scf.ConfigurationManagerConfig;
import org.mydotey.scf.Property;
import org.mydotey.scf.source.stringproperty.propertiesfile.PropertiesFileConfigurationSourceConfig;
import org.mydotey.scf.type.string.StringToIntConverter;
import org.mydotey.scf.type.string.StringToLongConverter;

import com.google.common.collect.Lists;

/**
 * @author koqizhao
 *
 * May 17, 2018
 */
public class StringPropertiesTest {

    protected ConfigurationManager createManager(String fileName) {
        PropertiesFileConfigurationSourceConfig sourceConfig = StringPropertySources
                .newPropertiesFileSourceConfigBuilder().setName("properties-source").setFileName(fileName).build();
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

        property = stringProperties.getStringProperty("exist", "default");
        System.out.println("property: " + property + "\n");
        Assert.assertEquals("ok", property.getValue());
    }

    @SuppressWarnings("rawtypes")
    @Test
    public void testGetTypedProperties() {
        StringProperties stringProperties = createStringProperties("test.properties");

        Property<String, Byte> byteProperty = stringProperties.getByteProperty("byte-value");
        System.out.println("byteProperty: " + byteProperty + "\n");
        Byte byteExpected = Byte.valueOf("1");
        Assert.assertEquals(byteExpected, byteProperty.getValue());

        Property<String, Short> shortProperty = stringProperties.getShortProperty("short-value");
        System.out.println("shortProperty: " + shortProperty + "\n");
        Short shortExpected = Short.valueOf("1");
        Assert.assertEquals(shortExpected, shortProperty.getValue());

        Property<String, Integer> intProperty = stringProperties.getIntProperty("int-value");
        System.out.println("intProperty: " + intProperty + "\n");
        Integer intExpected = Integer.valueOf("1");
        Assert.assertEquals(intExpected, intProperty.getValue());

        Property<String, Long> longProperty = stringProperties.getLongProperty("long-value");
        System.out.println("longProperty: " + longProperty + "\n");
        Long longExpected = Long.valueOf("1");
        Assert.assertEquals(longExpected, longProperty.getValue());

        Property<String, Float> floatProperty = stringProperties.getFloatProperty("float-value");
        System.out.println("floatProperty: " + floatProperty + "\n");
        Float floatExpected = Float.valueOf("1.1");
        Assert.assertEquals(floatExpected, floatProperty.getValue());

        Property<String, Double> doubleProperty = stringProperties.getDoubleProperty("double-value");
        System.out.println("doubleProperty: " + doubleProperty + "\n");
        Double doubleExpected = Double.valueOf("1.1");
        Assert.assertEquals(doubleExpected, doubleProperty.getValue());

        Property<String, Boolean> booleanProperty = stringProperties.getBooleanProperty("boolean-value");
        System.out.println("booleanProperty: " + booleanProperty + "\n");
        Boolean booleanExpected = Boolean.valueOf("true");
        Assert.assertEquals(booleanExpected, booleanProperty.getValue());

        Property<String, Class> classProperty = stringProperties.getClassProperty("class-value");
        System.out.println("classProperty: " + classProperty + "\n");
        Class classExpected = StringPropertiesTest.class;
        Assert.assertEquals(classExpected, classProperty.getValue());
    }

    @Test
    public void testGetTypedProperties2() {
        StringProperties stringProperties = createStringProperties("test.properties");
        Property<String, Integer> property = stringProperties.getIntProperty("int-value");
        System.out.println("property: " + property + "\n");
        Integer expected = Integer.valueOf(1);
        Assert.assertEquals(expected, property.getValue());

        Property<String, List<String>> property2 = stringProperties.getListProperty("list-value");
        System.out.println("property: " + property2 + "\n");
        List<String> expected2 = Lists.newArrayList("s1", "s2", "s3");
        Assert.assertEquals(expected2, property2.getValue());

        Property<String, Map<String, String>> property3 = stringProperties.getMapProperty("map-value");
        System.out.println("property: " + property3 + "\n");
        Map<String, String> expected3 = new HashMap<>();
        expected3.put("k1", "v1");
        expected3.put("k2", "v2");
        expected3.put("k3", "v3");
        Assert.assertEquals(expected3, property3.getValue());

        Property<String, List<Integer>> property4 = stringProperties.getListProperty("int-list-value",
                StringToIntConverter.DEFAULT);
        System.out.println("property: " + property4 + "\n");
        List<Integer> expected4 = Lists.newArrayList(1, 2, 3);
        Assert.assertEquals(expected4, property4.getValue());

        Property<String, Map<Integer, Long>> property5 = stringProperties.getMapProperty("int-long-map-value",
                StringToIntConverter.DEFAULT, StringToLongConverter.DEFAULT);
        System.out.println("property: " + property5 + "\n");
        Map<Integer, Long> expected5 = new HashMap<>();
        expected5.put(1, 2L);
        expected5.put(3, 4L);
        expected5.put(5, 6L);
        Assert.assertEquals(expected5, property5.getValue());
    }

    @Test(expected = IllegalArgumentException.class)
    public void testSameKeyDifferentConfig() {
        StringProperties stringProperties = createStringProperties("test.properties");
        Property<String, Map<String, String>> property = stringProperties.getMapProperty("map-value");
        Map<String, String> expected = new HashMap<>();
        expected.put("k1", "v1");
        expected.put("k2", "v2");
        expected.put("k3", "v3");
        Assert.assertEquals(expected, property.getValue());

        stringProperties.getMapProperty("map-value", StringToIntConverter.DEFAULT, StringToLongConverter.DEFAULT);
    }

    @Test
    public void testSameConfigSameProperty() {
        StringProperties stringProperties = createStringProperties("test.properties");
        Property<String, Map<String, String>> property = stringProperties.getMapProperty("map-value");
        Map<String, String> expected = new HashMap<>();
        expected.put("k1", "v1");
        expected.put("k2", "v2");
        expected.put("k3", "v3");
        Assert.assertEquals(expected, property.getValue());

        Property<String, Map<String, String>> property2 = stringProperties.getMapProperty("map-value");
        System.out.println("property2: " + property + "\n");
        Assert.assertTrue(property == property2);
    }

}
