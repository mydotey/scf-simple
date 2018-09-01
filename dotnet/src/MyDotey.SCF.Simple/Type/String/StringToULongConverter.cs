using System;

namespace MyDotey.SCF.Type.String
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringToULongConverter : StringConverter<ulong?>
    {
        public static readonly StringToULongConverter Default = new StringToULongConverter();

        public override ulong? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return ulong.Parse(source);
        }
    }
}