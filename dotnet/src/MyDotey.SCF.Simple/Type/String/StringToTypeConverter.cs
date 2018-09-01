using System;
using sType = System.Type;

namespace MyDotey.SCF.Type.String
{
    /**
    * @author koqizhao
    *
    * May 21, 2018
    */
    public class StringToTypeConverter : StringConverter<sType>
    {
        public static readonly StringToTypeConverter Default = new StringToTypeConverter();

        public override sType Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return sType.GetType(source);
        }
    }
}