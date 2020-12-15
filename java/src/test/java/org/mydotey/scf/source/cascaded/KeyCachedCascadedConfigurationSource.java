package org.mydotey.scf.source.cascaded;

import org.mydotey.collection.CascadedKeyMap;

/**
 * @author koqizhao
 *
 * Jul 20, 2018
 * 
 * use CascadedKeyMap to cache the keys so as to prevent temp string creation and have better young gc
 */
public class KeyCachedCascadedConfigurationSource
    extends CascadedConfigurationSource {

    private CascadedKeyMap<String, String> _cascadedKeyMap;

    public KeyCachedCascadedConfigurationSource(CascadedConfigurationSourceConfig config) {
        super(config);

        _cascadedKeyMap = new CascadedKeyMap<>();
    }

    @Override
    protected String getKey(String... keyParts) {
        return _cascadedKeyMap.getOrAdd(super::getKey, keyParts);
    }

}
