package org.mydotey.scf.type.string;

/**
 * @author koqizhao
 *
 * May 21, 2018
 */
public class StringToShortConverter extends StringConverter<Short> {

    public static final StringToShortConverter DEFAULT = new StringToShortConverter();

    public StringToShortConverter() {
        super(Short.class);
    }

    @Override
    public Short convert(String source) {
        return Short.parseShort(source);
    }

}
