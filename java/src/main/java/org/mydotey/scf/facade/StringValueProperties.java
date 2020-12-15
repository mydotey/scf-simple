package org.mydotey.scf.facade;

import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.function.Function;

import org.mydotey.java.ObjectExtension;
import org.mydotey.scf.ConfigurationManager;
import org.mydotey.scf.Property;
import org.mydotey.scf.PropertyConfig;
import org.mydotey.scf.filter.RangeValueConfig;
import org.mydotey.scf.type.TypeConverter;
import org.mydotey.scf.type.string.StringInplaceConverter;
import org.mydotey.scf.type.string.StringToBooleanConverter;
import org.mydotey.scf.type.string.StringToByteConverter;
import org.mydotey.scf.type.string.StringToClassConverter;
import org.mydotey.scf.type.string.StringToDoubleConverter;
import org.mydotey.scf.type.string.StringToFloatConverter;
import org.mydotey.scf.type.string.StringToIntConverter;
import org.mydotey.scf.type.string.StringToListConverter;
import org.mydotey.scf.type.string.StringToLongConverter;
import org.mydotey.scf.type.string.StringToMapConverter;
import org.mydotey.scf.type.string.StringToShortConverter;

/**
 * @author koqizhao
 *
 * May 21, 2018
 */
@SuppressWarnings("rawtypes")
public class StringValueProperties<K, M extends ConfigurationManager> {

    private M _manager;

    public StringValueProperties(M manager) {
        Objects.requireNonNull(manager, "manager is null");
        _manager = manager;
    }

    public M getManager() {
        return _manager;
    }

    public Property<K, String> getStringProperty(K key) {
        return getStringProperty(key, null);
    }

    public String getStringPropertyValue(K key) {
        return getStringPropertyValue(key, null);
    }

    public Property<K, String> getStringProperty(K key, String defaultValue) {
        return getStringProperty(key, defaultValue, null);
    }

    public String getStringPropertyValue(K key, String defaultValue) {
        return getStringPropertyValue(key, defaultValue, null);
    }

    public Property<K, String> getStringProperty(K key, String defaultValue, Function<String, String> valueFilter) {
        return getProperty(key, defaultValue, StringInplaceConverter.DEFAULT, valueFilter);
    }

    public String getStringPropertyValue(K key, String defaultValue, Function<String, String> valueFilter) {
        return getPropertyValue(key, defaultValue, StringInplaceConverter.DEFAULT, valueFilter);
    }

    public Property<K, Class> getClassProperty(K key) {
        return getClassProperty(key, null);
    }

    public Class getClassPropertyValue(K key) {
        return getClassPropertyValue(key, null);
    }

    public Property<K, Class> getClassProperty(K key, Class defaultValue) {
        return getClassProperty(key, defaultValue, null);
    }

    public Class getClassPropertyValue(K key, Class defaultValue) {
        return getClassPropertyValue(key, defaultValue, null);
    }

    public Property<K, Class> getClassProperty(K key, Class defaultValue, Function<Class, Class> valueFilter) {
        return getProperty(key, defaultValue, StringToClassConverter.DEFAULT, valueFilter);
    }

    public Class getClassPropertyValue(K key, Class defaultValue, Function<Class, Class> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToClassConverter.DEFAULT, valueFilter);
    }

    public Property<K, Byte> getByteProperty(K key) {
        return getByteProperty(key, ObjectExtension.<Byte>NULL());
    }

    public Byte getBytePropertyValue(K key) {
        return getBytePropertyValue(key, ObjectExtension.<Byte>NULL());
    }

    public Property<K, Byte> getByteProperty(K key, Byte defaultValue) {
        return getByteProperty(key, defaultValue, null);
    }

    public Byte getBytePropertyValue(K key, Byte defaultValue) {
        return getBytePropertyValue(key, defaultValue, null);
    }

    public Property<K, Byte> getByteProperty(K key, RangeValueConfig<Byte> rangeValueConfig) {
        return getProperty(key, rangeValueConfig, StringToByteConverter.DEFAULT);
    }

    public Byte getBytePropertyValue(K key, RangeValueConfig<Byte> rangeValueConfig) {
        return getPropertyValue(key, rangeValueConfig, StringToByteConverter.DEFAULT);
    }

    public Property<K, Byte> getByteProperty(K key, Byte defaultValue, Function<Byte, Byte> valueFilter) {
        return getProperty(key, defaultValue, StringToByteConverter.DEFAULT, valueFilter);
    }

    public Byte getBytePropertyValue(K key, Byte defaultValue, Function<Byte, Byte> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToByteConverter.DEFAULT, valueFilter);
    }

    public Property<K, Short> getShortProperty(K key) {
        return getShortProperty(key, ObjectExtension.<Short>NULL());
    }

    public Short getShortPropertyValue(K key) {
        return getShortPropertyValue(key, ObjectExtension.<Short>NULL());
    }

    public Property<K, Short> getShortProperty(K key, Short defaultValue) {
        return getShortProperty(key, defaultValue, null);
    }

    public Short getShortPropertyValue(K key, Short defaultValue) {
        return getShortPropertyValue(key, defaultValue, null);
    }

    public Property<K, Short> getShortProperty(K key, RangeValueConfig<Short> rangeValueConfig) {
        return getProperty(key, rangeValueConfig, StringToShortConverter.DEFAULT);
    }

    public Short getShortPropertyValue(K key, RangeValueConfig<Short> rangeValueConfig) {
        return getPropertyValue(key, rangeValueConfig, StringToShortConverter.DEFAULT);
    }

    public Property<K, Short> getShortProperty(K key, Short defaultValue, Function<Short, Short> valueFilter) {
        return getProperty(key, defaultValue, StringToShortConverter.DEFAULT, valueFilter);
    }

    public Short getShortPropertyValue(K key, Short defaultValue, Function<Short, Short> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToShortConverter.DEFAULT, valueFilter);
    }

    public Property<K, Integer> getIntProperty(K key) {
        return getIntProperty(key, ObjectExtension.<Integer>NULL());
    }

    public Integer getIntPropertyValue(K key) {
        return getIntPropertyValue(key, ObjectExtension.<Integer>NULL());
    }

    public Property<K, Integer> getIntProperty(K key, Integer defaultValue) {
        return getIntProperty(key, defaultValue, null);
    }

    public Integer getIntPropertyValue(K key, Integer defaultValue) {
        return getIntPropertyValue(key, defaultValue, null);
    }

    public Property<K, Integer> getIntProperty(K key, RangeValueConfig<Integer> rangeValueConfig) {
        return getProperty(key, rangeValueConfig, StringToIntConverter.DEFAULT);
    }

    public Integer getIntPropertyValue(K key, RangeValueConfig<Integer> rangeValueConfig) {
        return getPropertyValue(key, rangeValueConfig, StringToIntConverter.DEFAULT);
    }

    public Property<K, Integer> getIntProperty(K key, Integer defaultValue, Function<Integer, Integer> valueFilter) {
        return getProperty(key, defaultValue, StringToIntConverter.DEFAULT, valueFilter);
    }

    public Integer getIntPropertyValue(K key, Integer defaultValue, Function<Integer, Integer> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToIntConverter.DEFAULT, valueFilter);
    }

    public Property<K, Long> getLongProperty(K key) {
        return getLongProperty(key, ObjectExtension.<Long>NULL());
    }

    public Long getLongPropertyValue(K key) {
        return getLongPropertyValue(key, ObjectExtension.<Long>NULL());
    }

    public Property<K, Long> getLongProperty(K key, Long defaultValue) {
        return getLongProperty(key, defaultValue, null);
    }

    public Long getLongPropertyValue(K key, Long defaultValue) {
        return getLongPropertyValue(key, defaultValue, null);
    }

    public Property<K, Long> getLongProperty(K key, RangeValueConfig<Long> rangeValueConfig) {
        return getProperty(key, rangeValueConfig, StringToLongConverter.DEFAULT);
    }

    public Long getLongPropertyValue(K key, RangeValueConfig<Long> rangeValueConfig) {
        return getPropertyValue(key, rangeValueConfig, StringToLongConverter.DEFAULT);
    }

    public Property<K, Long> getLongProperty(K key, Long defaultValue, Function<Long, Long> valueFilter) {
        return getProperty(key, defaultValue, StringToLongConverter.DEFAULT, valueFilter);
    }

    public Long getLongPropertyValue(K key, Long defaultValue, Function<Long, Long> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToLongConverter.DEFAULT, valueFilter);
    }

    public Property<K, Float> getFloatProperty(K key) {
        return getFloatProperty(key, ObjectExtension.<Float>NULL());
    }

    public Float getFloatPropertyValue(K key) {
        return getFloatPropertyValue(key, ObjectExtension.<Float>NULL());
    }

    public Property<K, Float> getFloatProperty(K key, Float defaultValue) {
        return getFloatProperty(key, defaultValue, null);
    }

    public Float getFloatPropertyValue(K key, Float defaultValue) {
        return getFloatPropertyValue(key, defaultValue, null);
    }

    public Property<K, Float> getFloatProperty(K key, RangeValueConfig<Float> rangeValueConfig) {
        return getProperty(key, rangeValueConfig, StringToFloatConverter.DEFAULT);
    }

    public Float getFloatPropertyValue(K key, RangeValueConfig<Float> rangeValueConfig) {
        return getPropertyValue(key, rangeValueConfig, StringToFloatConverter.DEFAULT);
    }

    public Property<K, Float> getFloatProperty(K key, Float defaultValue, Function<Float, Float> valueFilter) {
        return getProperty(key, defaultValue, StringToFloatConverter.DEFAULT, valueFilter);
    }

    public Float getFloatPropertyValue(K key, Float defaultValue, Function<Float, Float> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToFloatConverter.DEFAULT, valueFilter);
    }

    public Property<K, Double> getDoubleProperty(K key) {
        return getDoubleProperty(key, ObjectExtension.<Double>NULL());
    }

    public Double getDoublePropertyValue(K key) {
        return getDoublePropertyValue(key, ObjectExtension.<Double>NULL());
    }

    public Property<K, Double> getDoubleProperty(K key, Double defaultValue) {
        return getDoubleProperty(key, defaultValue, null);
    }

    public Double getDoublePropertyValue(K key, Double defaultValue) {
        return getDoublePropertyValue(key, defaultValue, null);
    }

    public Property<K, Double> getDoubleProperty(K key, RangeValueConfig<Double> rangeValueConfig) {
        return getProperty(key, rangeValueConfig, StringToDoubleConverter.DEFAULT);
    }

    public Double getDoublePropertyValue(K key, RangeValueConfig<Double> rangeValueConfig) {
        return getPropertyValue(key, rangeValueConfig, StringToDoubleConverter.DEFAULT);
    }

    public Property<K, Double> getDoubleProperty(K key, Double defaultValue, Function<Double, Double> valueFilter) {
        return getProperty(key, defaultValue, StringToDoubleConverter.DEFAULT, valueFilter);
    }

    public Double getDoublePropertyValue(K key, Double defaultValue, Function<Double, Double> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToDoubleConverter.DEFAULT, valueFilter);
    }

    public Property<K, Boolean> getBooleanProperty(K key) {
        return getBooleanProperty(key, null);
    }

    public Boolean getBooleanPropertyValue(K key) {
        return getBooleanPropertyValue(key, null);
    }

    public Property<K, Boolean> getBooleanProperty(K key, Boolean defaultValue) {
        return getBooleanProperty(key, defaultValue, null);
    }

    public Boolean getBooleanPropertyValue(K key, Boolean defaultValue) {
        return getBooleanPropertyValue(key, defaultValue, null);
    }

    public Property<K, Boolean> getBooleanProperty(K key, Boolean defaultValue,
        Function<Boolean, Boolean> valueFilter) {
        return getProperty(key, defaultValue, StringToBooleanConverter.DEFAULT, valueFilter);
    }

    public Boolean getBooleanPropertyValue(K key, Boolean defaultValue, Function<Boolean, Boolean> valueFilter) {
        return getPropertyValue(key, defaultValue, StringToBooleanConverter.DEFAULT, valueFilter);
    }

    public Property<K, List<String>> getListProperty(K key) {
        return getListProperty(key, (List<String>) null);
    }

    public List<String> getListPropertyValue(K key) {
        return getListPropertyValue(key, (List<String>) null);
    }

    public Property<K, List<String>> getListProperty(K key, List<String> defaultValue) {
        return getProperty(key, defaultValue, StringToListConverter.DEFAULT);
    }

    public List<String> getListPropertyValue(K key, List<String> defaultValue) {
        return getPropertyValue(key, defaultValue, StringToListConverter.DEFAULT);
    }

    public <V> Property<K, List<V>> getListProperty(K key, TypeConverter<String, V> typeConverter) {
        return getListProperty(key, null, typeConverter);
    }

    public <V> List<V> getListPropertyValue(K key, TypeConverter<String, V> typeConverter) {
        return getListPropertyValue(key, null, typeConverter);
    }

    public <V> Property<K, List<V>> getListProperty(K key, List<V> defaultValue,
        TypeConverter<String, V> typeConverter) {
        return getListProperty(key, defaultValue, typeConverter, null);
    }

    public <V> List<V> getListPropertyValue(K key, List<V> defaultValue, TypeConverter<String, V> typeConverter) {
        return getListPropertyValue(key, defaultValue, typeConverter, null);
    }

    public <V> Property<K, List<V>> getListProperty(K key, List<V> defaultValue, TypeConverter<String, V> typeConverter,
        Function<List<V>, List<V>> valueFilter) {
        return getProperty(key, defaultValue, new StringToListConverter<>(typeConverter), valueFilter);
    }

    public <V> List<V> getListPropertyValue(K key, List<V> defaultValue, TypeConverter<String, V> typeConverter,
        Function<List<V>, List<V>> valueFilter) {
        return getPropertyValue(key, defaultValue, new StringToListConverter<>(typeConverter), valueFilter);
    }

    public Property<K, Map<String, String>> getMapProperty(K key) {
        return getMapProperty(key, null);
    }

    public Map<String, String> getMapPropertyValue(K key) {
        return getMapPropertyValue(key, null);
    }

    public Property<K, Map<String, String>> getMapProperty(K key, Map<String, String> defaultValue) {
        return getProperty(key, defaultValue, StringToMapConverter.DEFAULT);
    }

    public Map<String, String> getMapPropertyValue(K key, Map<String, String> defaultValue) {
        return getPropertyValue(key, defaultValue, StringToMapConverter.DEFAULT);
    }

    public <MK, MV> Property<K, Map<MK, MV>> getMapProperty(K key, TypeConverter<String, MK> keyConverter,
        TypeConverter<String, MV> valueConverter) {
        return getMapProperty(key, null, keyConverter, valueConverter);
    }

    public <MK, MV> Map<MK, MV> getMapPropertyValue(K key, TypeConverter<String, MK> keyConverter,
        TypeConverter<String, MV> valueConverter) {
        return getMapPropertyValue(key, null, keyConverter, valueConverter);
    }

    public <MK, MV> Property<K, Map<MK, MV>> getMapProperty(K key, Map<MK, MV> defaultMValue,
        TypeConverter<String, MK> keyConverter, TypeConverter<String, MV> valueConverter) {
        return getMapProperty(key, defaultMValue, keyConverter, valueConverter, null);
    }

    public <MK, MV> Map<MK, MV> getMapPropertyValue(K key, Map<MK, MV> defaultMValue,
        TypeConverter<String, MK> keyConverter, TypeConverter<String, MV> valueConverter) {
        return getMapPropertyValue(key, defaultMValue, keyConverter, valueConverter, null);
    }

    public <MK, MV> Property<K, Map<MK, MV>> getMapProperty(K key, Map<MK, MV> defaultMValue,
        TypeConverter<String, MK> keyConverter, TypeConverter<String, MV> valueConverter,
        Function<Map<MK, MV>, Map<MK, MV>> valueFilter) {
        return getProperty(key, defaultMValue, new StringToMapConverter<>(keyConverter, valueConverter), valueFilter);
    }

    public <MK, MV> Map<MK, MV> getMapPropertyValue(K key, Map<MK, MV> defaultValue,
        TypeConverter<String, MK> keyConverter, TypeConverter<String, MV> valueConverter,
        Function<Map<MK, MV>, Map<MK, MV>> valueFilter) {
        return getPropertyValue(key, defaultValue, new StringToMapConverter<>(keyConverter, valueConverter),
            valueFilter);
    }

    public <V> Property<K, V> getProperty(K key, TypeConverter<String, V> valueConverter) {
        return getProperty(key, null, valueConverter);
    }

    public <V> V getPropertyValue(K key, TypeConverter<String, V> valueConverter) {
        return getPropertyValue(key, null, valueConverter);
    }

    public <V> Property<K, V> getProperty(K key, V defaultValue, TypeConverter<String, V> valueConverter) {
        return getProperty(key, defaultValue, valueConverter, null);
    }

    public <V> V getPropertyValue(K key, V defaultValue, TypeConverter<String, V> valueConverter) {
        return getPropertyValue(key, defaultValue, valueConverter, null);
    }

    public <V extends Comparable<V>> Property<K, V> getProperty(K key, RangeValueConfig<V> rangeValueConfig,
        TypeConverter<String, V> valueConverter) {
        Objects.requireNonNull(rangeValueConfig, "rangeValueConfig is null");
        Objects.requireNonNull(valueConverter, "valueConverter is null");

        return getProperty(key, rangeValueConfig.defaultValue(), valueConverter, rangeValueConfig.toRangeValueFilter());
    }

    public <V extends Comparable<V>> V getPropertyValue(K key, RangeValueConfig<V> rangeValueConfig,
        TypeConverter<String, V> valueConverter) {
        Objects.requireNonNull(rangeValueConfig, "rangeValueConfig is null");
        Objects.requireNonNull(valueConverter, "valueConverter is null");

        return getPropertyValue(key, rangeValueConfig.defaultValue(), valueConverter,
            rangeValueConfig.toRangeValueFilter());
    }

    public <V> Property<K, V> getProperty(K key, V defaultValue, TypeConverter<String, V> valueConverter,
        Function<V, V> valueFilter) {
        Objects.requireNonNull(valueConverter, "valueConverter is null");

        return getProperty(key, valueConverter.getTargetType(), defaultValue, valueConverter, valueFilter);
    }

    public <V> V getPropertyValue(K key, V defaultValue, TypeConverter<String, V> valueConverter,
        Function<V, V> valueFilter) {
        Objects.requireNonNull(valueConverter, "valueConverter is null");

        return getPropertyValue(key, valueConverter.getTargetType(), defaultValue, valueConverter, valueFilter);
    }

    public <V> Property<K, V> getProperty(K key, Class<V> valueType, V defaultValue,
        TypeConverter<String, V> valueConverter, Function<V, V> valueFilter) {
        return getProperty(key, valueType, defaultValue, valueConverter, valueFilter, null);
    }

    public <V> V getPropertyValue(K key, Class<V> valueType, V defaultValue, TypeConverter<String, V> valueConverter,
        Function<V, V> valueFilter) {
        return getPropertyValue(key, valueType, defaultValue, valueConverter, valueFilter, null);
    }

    public <V> Property<K, V> getProperty(K key, Class<V> valueType, V defaultValue,
        TypeConverter<String, V> valueConverter, Function<V, V> valueFilter, Comparator<V> valueComparator) {
        PropertyConfig<K, V> propertyConfig = createPropertyConfig(key, valueType, defaultValue, valueConverter,
            valueFilter, valueComparator);
        return _manager.getProperty(propertyConfig);
    }

    public <V> V getPropertyValue(K key, Class<V> valueType, V defaultValue, TypeConverter<String, V> valueConverter,
        Function<V, V> valueFilter, Comparator<V> valueComparator) {
        PropertyConfig<K, V> propertyConfig = createPropertyConfig(key, valueType, defaultValue, valueConverter,
            valueFilter, valueComparator);
        return _manager.getPropertyValue(propertyConfig);
    }

    protected <V> PropertyConfig<K, V> createPropertyConfig(K key, Class<V> valueType, V defaultValue,
        TypeConverter<String, V> valueConverter, Function<V, V> valueFilter) {
        return createPropertyConfig(key, valueType, defaultValue, valueConverter, valueFilter, null);
    }

    protected <V> PropertyConfig<K, V> createPropertyConfig(K key, Class<V> valueType, V defaultValue,
        TypeConverter<String, V> valueConverter, Function<V, V> valueFilter, Comparator<V> valueComparator) {
        return ConfigurationProperties.<K, V>newConfigBuilder().setKey(key).setValueType(valueType)
            .setDefaultValue(defaultValue).addValueConverter(valueConverter).setValueFilter(valueFilter)
            .setValueComparator(valueComparator).build();
    }

}
