using System;

namespace MyDotey.SCF.Type.String
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringToUIntConverter : StringConverter<uint?>
    {
        public static readonly StringToUIntConverter Default = new StringToUIntConverter();

        public override uint? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return uint.Parse(source);
        }
    }
}