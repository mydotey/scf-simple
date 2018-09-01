using System;
using System.Collections.Generic;

namespace MyDotey.SCF.Type
{
    /**
     * @author koqizhao
     *
     * Sep. 1, 2018
     */
    public class DictionaryComparator<K, V> : IComparer<Dictionary<K, V>>
    {
        public static readonly DictionaryComparator<K, V> Default = new DictionaryComparator<K, V>();

        public virtual int Compare(Dictionary<K, V> o1, Dictionary<K, V> o2)
        {
            return o1.Equal(o2) ? 0 : -1;
        }
    }
}