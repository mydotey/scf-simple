package org.mydotey.scf.source.stringproperty.propertiesfile;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

public class LocalPropertiesFileConfigurationSource extends PropertiesFileConfigurationSource {

    public LocalPropertiesFileConfigurationSource(PropertiesFileConfigurationSourceConfig config) {
        super(config);
    }

    @Override
    protected InputStream loadFile(String fileName) throws IOException {
        return new FileInputStream(fileName);
    }

}
