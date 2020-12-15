package org.mydotey.scf.source.pipeline;

import org.mydotey.scf.AbstractConfigurationSource;
import org.mydotey.scf.ConfigurationSource;
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
public class PipelineConfigurationSource
    extends AbstractConfigurationSource<PipelineConfigurationSourceConfig> {

    public PipelineConfigurationSource(PipelineConfigurationSourceConfig config) {
        super(config);

        for (ConfigurationSource source : config.getSources()) {
            source.addChangeListener(e -> PipelineConfigurationSource.this.raiseChangeEvent());
        }
    }

    @Override
    public <K, V> V getPropertyValue(PropertyConfig<K, V> propertyConfig) {
        for (ConfigurationSource source : getConfig().getSources()) {
            V value = source.getPropertyValue(propertyConfig);
            if (!isNull(value))
                return value;
        }
        return null;
    }

    @Override
    protected Object getPropertyValue(Object key) {
        throw new UnsupportedOperationException();
    }

}
