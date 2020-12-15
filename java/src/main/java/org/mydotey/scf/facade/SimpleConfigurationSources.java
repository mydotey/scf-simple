package org.mydotey.scf.facade;

import java.util.Arrays;
import java.util.List;

import org.mydotey.scf.ConfigurationSource;
import org.mydotey.scf.ConfigurationSourceConfig;
import org.mydotey.scf.source.cascaded.CascadedConfigurationSource;
import org.mydotey.scf.source.cascaded.CascadedConfigurationSourceConfig;
import org.mydotey.scf.source.pipeline.PipelineConfigurationSource;
import org.mydotey.scf.source.pipeline.PipelineConfigurationSourceConfig;
import org.mydotey.scf.source.stringproperty.environmentvariable.EnvironmentVariableConfigurationSource;
import org.mydotey.scf.source.stringproperty.memorymap.MemoryMapConfigurationSource;
import org.mydotey.scf.source.stringproperty.propertiesfile.LocalPropertiesFileConfigurationSource;
import org.mydotey.scf.source.stringproperty.propertiesfile.PropertiesFileConfigurationSource;
import org.mydotey.scf.source.stringproperty.propertiesfile.PropertiesFileConfigurationSourceConfig;
import org.mydotey.scf.source.stringproperty.systemproperties.SystemPropertiesConfigurationSource;
import org.mydotey.scf.util.PropertyKeyGenerator;

/**
 * @author koqizhao
 *
 * May 22, 2018
 */
public interface SimpleConfigurationSources {

    static SystemPropertiesConfigurationSource newSystemPropertiesSource() {
        return newSystemPropertiesSource("system-properties");
    }

    static SystemPropertiesConfigurationSource newSystemPropertiesSource(String name) {
        ConfigurationSourceConfig config = ConfigurationSources.newConfig(name);
        return new SystemPropertiesConfigurationSource(config);
    }

    static EnvironmentVariableConfigurationSource newEnvironmentVariableSource() {
        return newEnvironmentVariableSource("environment-variables");
    }

    static EnvironmentVariableConfigurationSource newEnvironmentVariableSource(String name) {
        ConfigurationSourceConfig config = ConfigurationSources.newConfig(name);
        return new EnvironmentVariableConfigurationSource(config);
    }

    static MemoryMapConfigurationSource newMemoryMapSource() {
        return newMemoryMapSource("memory-map");
    }

    static MemoryMapConfigurationSource newMemoryMapSource(String name) {
        ConfigurationSourceConfig config = ConfigurationSources.newConfig(name);
        return new MemoryMapConfigurationSource(config);
    }

    static PropertiesFileConfigurationSource newPropertiesFileSource(String fileName) {
        PropertiesFileConfigurationSourceConfig config = new PropertiesFileConfigurationSourceConfig.Builder()
            .setFileName(fileName).build();
        return newPropertiesFileSource(config);
    }

    static PropertiesFileConfigurationSourceConfig.Builder newPropertiesFileSourceConfigBuilder() {
        return new PropertiesFileConfigurationSourceConfig.Builder();
    }

    static PropertiesFileConfigurationSource newPropertiesFileSource(
        PropertiesFileConfigurationSourceConfig config) {
        return new PropertiesFileConfigurationSource(config);
    }

    static PropertiesFileConfigurationSource newLocalPropertiesFileSource(String fileName) {
        PropertiesFileConfigurationSourceConfig config = new PropertiesFileConfigurationSourceConfig.Builder()
            .setFileName(fileName).build();
        return newLocalPropertiesFileSource(config);
    }

    static LocalPropertiesFileConfigurationSource newLocalPropertiesFileSource(
        PropertiesFileConfigurationSourceConfig config) {
        return new LocalPropertiesFileConfigurationSource(config);
    }

    static CascadedConfigurationSource newCascadedSource(
        ConfigurationSource source, String... cascadedFactors) {
        return newCascadedSource(source, Arrays.asList(cascadedFactors));
    }

    static CascadedConfigurationSource newCascadedSource(
        ConfigurationSource source, List<String> cascadedFactors) {
        CascadedConfigurationSourceConfig.Builder builder = new CascadedConfigurationSourceConfig.Builder();
        CascadedConfigurationSourceConfig config = builder.setSource(source)
            .setKeySeparator(PropertyKeyGenerator.KEY_SEPARATOR)
            .addCascadedFactors(cascadedFactors).build();
        return new CascadedConfigurationSource(config);
    }

    static CascadedConfigurationSourceConfig.Builder newCascadedSourceConfigBuilder() {
        return new CascadedConfigurationSourceConfig.Builder();
    }

    static CascadedConfigurationSource newCascadedSource(
        CascadedConfigurationSourceConfig config) {
        return new CascadedConfigurationSource(config);
    }

    static PipelineConfigurationSource newPipelineSource(ConfigurationSource... sources) {
        return newPipelineSource(Arrays.asList(sources));
    }

    static PipelineConfigurationSource newPipelineSource(List<ConfigurationSource> sources) {
        PipelineConfigurationSourceConfig config = new PipelineConfigurationSourceConfig.Builder()
            .addSources(sources).build();
        return newPipelineSource(config);
    }

    static PipelineConfigurationSourceConfig.Builder newPipelineSourceConfigBuilder() {
        return new PipelineConfigurationSourceConfig.Builder();
    }

    static PipelineConfigurationSource newPipelineSource(
        PipelineConfigurationSourceConfig config) {
        return new PipelineConfigurationSource(config);
    }

}
