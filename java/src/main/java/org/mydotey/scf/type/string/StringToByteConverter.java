package org.mydotey.scf.type.string;

/**
 * @author koqizhao
 *
 * May 21, 2018
 */
public class StringToByteConverter extends StringConverter<Byte> {

    public static final StringToByteConverter DEFAULT = new StringToByteConverter();

    public StringToByteConverter() {
        super(Byte.class);
    }

    @Override
    public Byte convert(String source) {
        return Byte.parseByte(source);
    }

}
