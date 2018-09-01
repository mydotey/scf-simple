package org.mydotey.scf.type.string;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * @author koqizhao
 *
 * May 21, 2018
 */
@SuppressWarnings("rawtypes")
public class StringToClassConverter extends StringConverter<Class> {

    private static final Logger _logger = LoggerFactory.getLogger(StringToClassConverter.class);

    public static final StringToClassConverter DEFAULT = new StringToClassConverter();

    public StringToClassConverter() {
        super(Class.class);
    }

    @Override
    public Class convert(String source) {
        try {
            return Class.forName(source);
        } catch (ClassNotFoundException e) {
            _logger.warn("class " + source + " is not found", e);
            return null;
        }
    }

}
