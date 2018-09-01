using System;
using System.Collections.Generic;

namespace MyDotey.SCF.Type
{
    /**
     * @author koqizhao
     *
     * Sep. 1, 2018
     */
    public class ListComparator<T> : IComparer<List<T>>
    {
        public static readonly ListComparator<T> Default = new ListComparator<T>();

        public virtual int Compare(List<T> o1, List<T> o2)
        {
            return o1.Equal(o2) ? 0 : -1;
        }
    }
}