using System;

namespace MyDotey.SCF.Type.String
{
    /**
    * @author koqizhao
    *
    * May 21, 2018
    */
    public class StringToShortConverter : StringConverter<short?>
    {
        public static readonly StringToShortConverter Default = new StringToShortConverter();

        public override short? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return short.Parse(source);
        }
    }
}