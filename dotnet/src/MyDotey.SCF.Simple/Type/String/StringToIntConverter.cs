using System;

namespace MyDotey.SCF.Type.String
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringToIntConverter : StringConverter<int?>
    {
        public static readonly StringToIntConverter Default = new StringToIntConverter();

        public override int? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return int.Parse(source);
        }
    }
}