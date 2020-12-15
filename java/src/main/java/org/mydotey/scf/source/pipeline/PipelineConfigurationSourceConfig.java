package org.mydotey.scf.source.pipeline;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import org.mydotey.java.ObjectExtension;
import org.mydotey.scf.ConfigurationSource;
import org.mydotey.scf.DefaultConfigurationSourceConfig;

/**
 * @author koqizhao
 *
 * May 17, 2018
 */
public class PipelineConfigurationSourceConfig
    extends DefaultConfigurationSourceConfig {

    private List<ConfigurationSource> _sources;

    protected PipelineConfigurationSourceConfig() {

    }

    public List<ConfigurationSource> getSources() {
        return _sources;
    }

    @Override
    public PipelineConfigurationSourceConfig clone() {
        PipelineConfigurationSourceConfig copy = (PipelineConfigurationSourceConfig) super.clone();

        if (_sources != null)
            copy._sources = Collections.unmodifiableList(new ArrayList<>(_sources));

        return copy;
    }

    @Override
    public String toString() {
        return "PipelineConfigurationSourceConfig [_sources=" + _sources + ", getName()=" + getName() + "]";
    }

    public static class Builder extends
        DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, PipelineConfigurationSourceConfig> {

        @Override
        protected PipelineConfigurationSourceConfig newConfig() {
            return new PipelineConfigurationSourceConfig();
        }

        public Builder addSource(ConfigurationSource source) {
            if (source == null)
                return this;

            if (getConfig()._sources == null)
                getConfig()._sources = new ArrayList<>();
            getConfig()._sources.add(source);

            return this;
        }

        public Builder addSources(List<ConfigurationSource> sources) {
            if (sources != null)
                sources.forEach(this::addSource);

            return this;
        }

        @Override
        public PipelineConfigurationSourceConfig build() {
            ObjectExtension.requireNonEmpty(getConfig()._sources, "sources");

            if (getConfig().getName() == null)
                setName("pipeline-sources");

            return super.build();
        }
    }

}
