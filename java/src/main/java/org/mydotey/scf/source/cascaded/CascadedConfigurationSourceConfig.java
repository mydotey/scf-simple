package org.mydotey.scf.source.cascaded;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

import org.mydotey.scf.ConfigurationSource;
import org.mydotey.scf.DefaultConfigurationSourceConfig;

/**
 * @author koqizhao
 *
 * May 17, 2018
 */
public class CascadedConfigurationSourceConfig extends DefaultConfigurationSourceConfig {

    private String _keySeparator;
    private List<String> _cascadedFactors;

    private ConfigurationSource _source;

    protected CascadedConfigurationSourceConfig() {

    }

    public String getKeySeparator() {
        return _keySeparator;
    }

    public List<String> getCascadedFactors() {
        return _cascadedFactors;
    }

    public ConfigurationSource getSource() {
        return _source;
    }

    @Override
    public CascadedConfigurationSourceConfig clone() {
        CascadedConfigurationSourceConfig copy = (CascadedConfigurationSourceConfig) super.clone();

        if (_cascadedFactors != null)
            copy._cascadedFactors = Collections.unmodifiableList(new ArrayList<>(_cascadedFactors));

        return copy;
    }

    @Override
    public String toString() {
        return String.format("%s { name: %s, keySeparator: %s, cascadedFactors: %s }", getClass().getSimpleName(),
            getName(), _keySeparator, _cascadedFactors);
    }

    public static class Builder extends
        DefaultConfigurationSourceConfig.DefaultAbstractBuilder<Builder, CascadedConfigurationSourceConfig> {

        @Override
        protected CascadedConfigurationSourceConfig newConfig() {
            return new CascadedConfigurationSourceConfig();
        }

        public Builder setKeySeparator(String keySeparator) {
            getConfig()._keySeparator = keySeparator;
            return this;
        }

        public Builder addCascadedFactor(String cascadedFactor) {
            if (cascadedFactor == null)
                return this;

            cascadedFactor = cascadedFactor.trim();
            if (cascadedFactor.isEmpty())
                return this;

            if (getConfig()._cascadedFactors == null)
                getConfig()._cascadedFactors = new ArrayList<>();
            getConfig()._cascadedFactors.add(cascadedFactor);

            return this;
        }

        public Builder setSource(ConfigurationSource source) {
            getConfig()._source = source;
            if (getConfig().getName() == null)
                setName("cascaded-" + getConfig().getSource().getConfig().getName());
            return this;
        }

        public Builder addCascadedFactors(List<String> cascadedFactors) {
            if (cascadedFactors != null)
                cascadedFactors.forEach(this::addCascadedFactor);

            return this;
        }

        @Override
        public CascadedConfigurationSourceConfig build() {
            Objects.requireNonNull(getConfig()._keySeparator, "keySeparator is null");
            getConfig()._keySeparator = getConfig().getKeySeparator().trim();
            if (getConfig().getKeySeparator().isEmpty())
                throw new IllegalArgumentException("keySeparator is empty");

            Objects.requireNonNull(getConfig()._cascadedFactors, "cascadedFactors is null");
            if (getConfig().getCascadedFactors().isEmpty())
                throw new IllegalArgumentException("cascadedFactors is empty");

            Objects.requireNonNull(getConfig()._source, "source is null");

            return super.build();
        }
    }

}
