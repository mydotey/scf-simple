using System;

namespace MyDotey.SCF.Type.String
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringToDecimalConverter : StringConverter<decimal?>
    {
        public static readonly StringToDecimalConverter Default = new StringToDecimalConverter();

        public override decimal? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return decimal.Parse(source);
        }
    }
}