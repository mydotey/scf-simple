package org.mydotey.scf.util;

import java.util.Arrays;

import org.mydotey.java.ObjectExtension;
import org.mydotey.java.StringExtension;
import org.mydotey.java.collection.CollectionExtension;

/**
 * Created by Qiang Zhao on 10/05/2016.
 */
public interface PropertyKeyGenerator {

    String KEY_SEPARATOR = ".";

    static String generatePropertyKey(String... parts) {
        return generateKey(KEY_SEPARATOR, parts);
    }

    static String generateKey(String keySeparator, String... parts) {
        if (CollectionExtension.isEmpty(parts))
            return null;

        if (parts.length == 1)
            return StringExtension.trim(parts[0]);

        if (parts.length == 2)
            return generateKey(keySeparator, parts[0], parts[1]);

        String subKey = generateKey(keySeparator, Arrays.copyOfRange(parts, 1, parts.length));
        return generateKey(keySeparator, parts[0], subKey);
    }

    static String generateKey(String keySeparator, String part1, String part2) {
        ObjectExtension.requireNonBlank(keySeparator, "keySeparator");

        if (part2 == null)
            return null;

        part2 = StringExtension.trim(part2);
        if (part2.isEmpty())
            return StringExtension.EMPTY;

        if (part1 == null)
            return part2;

        part1 = StringExtension.trim(part1);
        if (part1.isEmpty())
            return part2;

        return part1 + keySeparator + part2;
    }

}
