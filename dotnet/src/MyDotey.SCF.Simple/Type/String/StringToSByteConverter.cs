using System;

namespace MyDotey.SCF.Type.String
{
    /**
    * @author koqizhao
    *
    * May 21, 2018
    */
    public class StringToSByteConverter : StringConverter<sbyte?>
    {
        public static readonly StringToSByteConverter Default = new StringToSByteConverter();

        public override sbyte? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return sbyte.Parse(source);
        }
    }
}