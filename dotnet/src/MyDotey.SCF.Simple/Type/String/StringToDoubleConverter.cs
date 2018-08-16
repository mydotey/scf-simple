using System;

namespace MyDotey.SCF.Type.String
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringToDoubleConverter : StringConverter<double?>
    {
        public static readonly StringToDoubleConverter Default = new StringToDoubleConverter();

        public override double? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return double.Parse(source);
        }
    }
}