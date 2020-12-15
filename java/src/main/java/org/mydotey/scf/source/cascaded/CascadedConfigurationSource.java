package org.mydotey.scf.source.cascaded;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import org.mydotey.scf.AbstractConfigurationSource;
import org.mydotey.scf.DefaultPropertyConfig;
import org.mydotey.scf.PropertyConfig;

/**
 * @author koqizhao
 *
 * May 17, 2018
 * 
 * allow casaded config like:
 *  key
 *  key.a
 *  key.a.b
 * priority:
 *  key.a.b &gt; k.a &gt; key
 */
public class CascadedConfigurationSource
    extends AbstractConfigurationSource<CascadedConfigurationSourceConfig> {

    private List<String> _cascadedKeyParts;

    public CascadedConfigurationSource(CascadedConfigurationSourceConfig config) {
        super(config);

        config.getSource().addChangeListener(s -> CascadedConfigurationSource.this.raiseChangeEvent());

        init();
    }

    protected void init() {
        _cascadedKeyParts = new ArrayList<>();

        StringBuffer keyPart = new StringBuffer("");
        _cascadedKeyParts.add(keyPart.toString());
        for (String factor : getConfig().getCascadedFactors()) {
            keyPart.append(getConfig().getKeySeparator()).append(factor);
            _cascadedKeyParts.add(keyPart.toString());
        }

        Collections.reverse(_cascadedKeyParts);
        _cascadedKeyParts = Collections.unmodifiableList(_cascadedKeyParts);
    }

    @SuppressWarnings("unchecked")
    @Override
    public <K, V> V getPropertyValue(PropertyConfig<K, V> propertyConfig) {
        if (propertyConfig.getKey().getClass() != String.class)
            return getConfig().getSource().getPropertyValue(propertyConfig);

        String key = (String) propertyConfig.getKey();
        for (String keyPart : _cascadedKeyParts) {
            String cascadedKey = getKey(key, keyPart);
            PropertyConfig<K, V> cascadedPropertyConfig = makePropertyConfig((K) cascadedKey, propertyConfig);
            V value = getConfig().getSource().getPropertyValue(cascadedPropertyConfig);
            if (!isNull(value))
                return value;
        }

        return null;
    }

    @Override
    protected Object getPropertyValue(Object key) {
        throw new UnsupportedOperationException();
    }

    /**
     * allow user to override
     * if the key count is limited, can cache the key and have less memory use
     * @param keyParts
     * @return property value
     */
    protected String getKey(String... keyParts) {
        if (keyParts == null)
            return null;

        StringBuilder stringBuilder = new StringBuilder();
        for (String part : keyParts)
            stringBuilder.append(part);
        return stringBuilder.toString();
    }

    protected <K, V> PropertyConfig<K, V> makePropertyConfig(K key, PropertyConfig<K, V> propertyConfig) {
        return new DefaultPropertyConfig.Builder<K, V>()
            .setKey(key)
            .setDefaultValue(propertyConfig.getDefaultValue())
            .setDoc(propertyConfig.getDoc())
            .setRequired(propertyConfig.isRequired())
            .setStatic(propertyConfig.isStatic())
            .setValueComparator(propertyConfig.getValueComparator())
            .setValueFilter(propertyConfig.getValueFilter())
            .setValueType(propertyConfig.getValueType())
            .addValueConverters(propertyConfig.getValueConverters())
            .build();
    }

}
